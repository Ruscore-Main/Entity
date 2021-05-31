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
                    Student student;
                    Professor professor;
                    User user;
                    MyLib.ComplexMessage complexMessage = new ComplexMessage();
                    MyLib.Message message = new MyLib.Message();
                    message.Data = myReadBuffer;
                    complexMessage = (ComplexMessage)
                    SerializeAndDeserialize.Deserialize(message);
                    if (complexMessage.NumberStatus == 0)
                    {

                        try
                        {
                            student = (Student)SerializeAndDeserialize.Deserialize(complexMessage.First);
                        }
                        catch
                        {
                            student = null;
                        }
                        try
                        {
                            professor = (Professor)SerializeAndDeserialize.Deserialize(complexMessage.First);
                        }
                        catch
                        {
                            professor = null;
                        }
                        user = (User)SerializeAndDeserialize.Deserialize(complexMessage.Second);

                        using (EntityModelContainer db = new EntityModelContainer())
                        {
                            db.UserSet.Add(user);
                            db.SaveChanges();
                        }
                    }
                    else if (complexMessage.NumberStatus == 1)
                    {
                        using (EntityModelContainer db = new EntityModelContainer())
                        {
                            byte[] responseData;
                            for (int i = 0; i < db.UserSet.ToList().Count; i++)
                            {
                                if (db.UserSet.ToList()[i].Login == Convert.ToString(SerializeAndDeserialize.Deserialize(complexMessage.First)) && db.UserSet.ToList()[i].Password ==
                                Convert.ToString(SerializeAndDeserialize.

                                Deserialize(complexMessage.Second)))
                                {
                                    User user1 = db.UserSet.ToList()[i];
                                    User user2 = new User() { Login = user1.Login, Password = user1.Password, Role = user1.Role };
                                    m1 = SerializeAndDeserialize.Serialize(user2);
                                    if (db.UserSet.ToList()[i].Role == "Студент")
                                    {
                                        Student student1 = db.UserSet.ToList()[i].Student;
                                        Student student2 = new Student()
                                        {
                                            Name =
                                        student1.Name,
                                            NumberGroup = student1.NumberGroup,
                                            PersonalData = student1.PersonalData,
                                            Photo = student1.Photo,
                                            Specialty = student1.Specialty
                                        };
                                        m2 = SerializeAndDeserialize.Serialize(student2);
                                    }

                                    else if (db.UserSet.ToList()[i].Role == "Преподаватель")
                                    {
                                        Professor professor1 =
                                        db.UserSet.ToList()[i].Professor;
                                        Professor professor2 = professor1;
                                        m2 =
                                        SerializeAndDeserialize.Serialize(professor1);
                                    }
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
