using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Connection.ServiceReference1;

namespace Connection.Models
{
    public class AccessConnection
    {

        Service1 client = new Service1();

        /// <summary>
        /// verifies the username and password with the db returns true if user exists
        /// </summary>
        /// <param name="p_name"></param>
        /// <param name="p_password"></param>
        /// <returns></returns>
        internal bool Verify(string p_name, string p_password)
        {
            bool isVerified;
            isVerified = client.PutData(p_name, p_password);
            
            if (isVerified)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// sends parameters from the main class and the passChange class to the service
        /// </summary>
        /// <param name="username"></param>
        /// <param name="p_oldPass"></param>
        /// <param name="p_newPass"></param>
        /// <param name="p_confirmPass"></param>
        /// <returns></returns>
        internal bool ChangePass(string username, string p_oldPass, string p_newPass, string p_confirmPass)
        {            
            bool pass = client.CheckData(p_oldPass);
            bool retVal = false;

            if (pass && p_newPass == p_confirmPass)
            {
                client.updateData(username, p_newPass);
                retVal = true;
            }
            return retVal;
        }
    }
}