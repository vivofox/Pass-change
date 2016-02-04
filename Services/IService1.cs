using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Connection
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool GetData(UserTable ut);  //accepts values for UserId and UserPassword from users and updates it in the Database

        [OperationContract]
        bool PutData(string p_name, string p_password); //fetches values from the Database and displays it

        [OperationContract]
        bool CheckData(string p_oldPass); //checks for  password

    }

    [DataContract]
    public class UserTable // Database tables.
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}
