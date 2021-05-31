using labaEntity;
using MyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SERVER_LABA
{
    public class ClientObject
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream { get; private set; }
        TcpClient client;
        ServerObject server;
        MyLib.Message m, m1, m2;
        MyLib.ComplexMessage cm = new ComplexMessage();
        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
            Stream = client.GetStream();
        }
        public void Process()
        {

            while (true)
            {
                if (Stream.CanRead)
                {
                    byte[] myReadBuffer = new byte[6297630];
                    do
                    {
                        Stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                    }
                    while (Stream.DataAvailable);
                    Bonus bonus;
                    User user;
                    MyLib.ComplexMessage complexMessage = new ComplexMessage();
                    MyLib.Message message = new MyLib.Message();
                    message.Data = myReadBuffer;
                    complexMessage = (ComplexMessage)
                    SerializeAndDeserialize.Deserialize(message);
                    // Регистрация
                    if (complexMessage.NumberStatus == 0)
                    {

                        try
                        {
                            bonus = (Bonus)SerializeAndDeserialize.Deserialize(complexMessage.First);
                        }
                        catch
                        {
                            bonus = null;
                        }
                        user = (User)SerializeAndDeserialize.Deserialize(complexMessage.Second);

                        using (UserContainer db = new UserContainer())
                        {
                            db.UserSet.Add(user);
                            db.SaveChanges();
                        }
                    }
                    // Авторизация
                    else if (complexMessage.NumberStatus == 1)
                    {
                        using (UserContainer db = new UserContainer())
                        {
                            byte[] responseData;
                            for (int i = 0; i < db.UserSet.ToList().Count; i++)
                            {
                                if (db.UserSet.ToList()[i].Login == Convert.ToString(SerializeAndDeserialize.Deserialize(complexMessage.First)) && db.UserSet.ToList()[i].Password ==
                                Convert.ToString(SerializeAndDeserialize.Deserialize(complexMessage.Second)))
                                {
                                    User user1 = db.UserSet.ToList()[i];
                                    User user2 = new User() { Login = user1.Login, Password = user1.Password, Role = user1.Role };
                                    m1 = SerializeAndDeserialize.Serialize(user2);
                                    Bonus bonus1 = db.UserSet.ToList()[i].Bonus;
                                    Bonus bonus2 = new Bonus()
                                    {
                                        AmountBonus = "0"
                                    };
                                    m2 = SerializeAndDeserialize.Serialize(bonus2);

                                    cm.First = m1;
                                    cm.Second = m2;
                                    cm.NumberStatus = 2;
                                    m = SerializeAndDeserialize.Serialize(cm);
                                    responseData = m.Data;
                                    Stream.Write(responseData, 0, responseData.Length);
                                    goto label;
                                }
                            }
                            cm.NumberStatus = 3;
                            m = SerializeAndDeserialize.Serialize(cm);

                            responseData = m.Data;
                            Stream.Write(responseData, 0, responseData.Length);
                        label:
                            responseData = null;
                        }
                    }
                }
            }
        }

    }
}
