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
                        complexMessage = (ComplexMessage)SerializeAndDeserialize.Deserialize(message);
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

                            using (UserContainer db = new UserContainer())
                            {
                                user = (User)SerializeAndDeserialize.Deserialize(complexMessage.Second);
                                Bonus newBonus = new Bonus() { AmountBonus = bonus.AmountBonus };
                                User newUser = new User() { Login = user.Login, Email = user.Email, Balance = user.Balance, Password = user.Password, Role = user.Role, Bonus = newBonus };
                                db.UserSet.Add(newUser);
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

                                    if (db.UserSet.ToList()[i].Login == Convert.ToString(SerializeAndDeserialize.Deserialize(complexMessage.First)) && db.UserSet.ToList()[i].Password == CryptoService.GetHashString(Convert.ToString(SerializeAndDeserialize.Deserialize(complexMessage.Second))))
                                    {
                                        Bonus bonus1 = db.UserSet.ToList()[i].Bonus;
                                        Bonus bonus2 = new Bonus()
                                        {
                                            Id = bonus1.Id,
                                            AmountBonus = bonus1.AmountBonus
                                        };
                                        User user1 = db.UserSet.ToList()[i];
                                        User user2 = new User() { Id=user1.Id, Login = user1.Login, Password = user1.Password, Role = user1.Role, Balance = user1.Balance, basket = user1.basket, Email = user1.Email, Bonus = bonus2 };
                                        m1 = SerializeAndDeserialize.Serialize(user2);
                                        
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
                        // Восстановление пароля
                        else if (complexMessage.NumberStatus == 2)
                        {

                            // First - новый пароль, Second - почта
                            string newPassword = Convert.ToString(SerializeAndDeserialize.Deserialize(complexMessage.First));
                            using (UserContainer db = new UserContainer())
                            {
                                byte[] responseData;
                                foreach (User usr in db.UserSet)
                                {
                                    if (usr.Email == Convert.ToString(SerializeAndDeserialize.Deserialize(complexMessage.Second)))
                                    { 
                                        usr.Password = CryptoService.GetHashString(newPassword);
                                        cm.First = m1;
                                        cm.Second = m2;
                                        cm.NumberStatus = 2;
                                        m = SerializeAndDeserialize.Serialize(cm);
                                        responseData = m.Data;
                                        Stream.Write(responseData, 0, responseData.Length);
                                        goto labelSucess;
                                    }
                                }
                                cm.NumberStatus = 3;
                                m = SerializeAndDeserialize.Serialize(cm);

                                responseData = m.Data;
                                Stream.Write(responseData, 0, responseData.Length);
                                labelSucess:
                                responseData = null;
                                db.SaveChanges();

                            }
                        }
                    }
                }
            
        }
        

    }
}
