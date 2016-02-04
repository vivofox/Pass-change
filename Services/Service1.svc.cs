using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.OleDb;


namespace Connection
{
    public class Service1 : IService1
    {
        /// <summary>
        /// inserts a new users into the db, in case of exception the user already exists so Getdata returns false
        /// </summary>
        /// <param name="ut"></param>
        /// <returns></returns>
        public bool GetData(UserTable ut)
        {
            bool RetVal = true; ;

            try
            {
                OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\C#_Projs\\DB\\UserDB1.accdb'");
                OleDbCommand cmd = new OleDbCommand("INSERT INTO UPTable([Username], [Password]) VALUES(@Username , @password)");
                cmd.Parameters.AddWithValue("@Username", ut.Username);
                cmd.Parameters.AddWithValue("@Password", ut.Password);
                cmd.Connection = con1;

                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();

            }
            catch (Exception ex)
            {
                RetVal = false;
            }
            return RetVal;
        }
        /// <summary>
        /// updates the password in the db
        /// </summary>
        /// <param name="p_username"></param>
        /// <param name="p_newPass"></param>
        /// <returns></returns>
        public bool updateData(string p_username, string p_newPass)
        {
            string movedName = Views.main.moveUser;
            OleDbConnection con2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\C#_Projs\\DB\\UserDB1.accdb'");
            OleDbCommand cmd = new OleDbCommand("UPDATE UPTable SET [Password] = ? WHERE [Username] = ?");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@Password", p_newPass);
            cmd.Parameters.AddWithValue("@Username", movedName);
            cmd.Connection = con2;

            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();
            return true;
        }

        /// <summary>
        /// checks if the username and password inserted by the user equal the data in the db
        /// </summary>
        /// <param name="p_name"></param>
        /// <param name="p_password"></param>
        /// <returns></returns>
        public bool PutData(string p_name, string p_password)
        {
            bool retVal = false;
            UserTable ut1 = new UserTable();
            OleDbDataReader rd;

            OleDbConnection con3 = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\C#_Projs\\DB\\UserDB1.accdb");
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select * from UPTable";
            cmd.Connection = con3;

            con3.Open();
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                ut1.ID = (int)rd["ID"];
                ut1.Username = rd["Username"].ToString();
                ut1.Password = rd["Password"].ToString();
                if (ut1.Username == p_name && ut1.Password == p_password)
                {
                    retVal = true;
                }
            }
            con3.Close();
            return retVal;
        }

        /// <summary>
        /// confirms the password sent from the ChangePass object
        /// </summary>
        /// <param name="p_oldPass"></param>
        /// <returns></returns>
        public bool CheckData(string p_oldPass)
        {
            UserTable ut1 = new UserTable();
            bool retVal = false;
            OleDbDataReader rd;
            
            OleDbConnection con4 = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\C#_Projs\\DB\\UserDB1.accdb");
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select * from UPTable";
            cmd.Connection = con4;

            con4.Open();
            rd = cmd.ExecuteReader();

            if (rd != null)
            {
                while (rd.Read())
                {
                    ut1.ID = (int)rd["ID"];
                    ut1.Username = rd["Username"].ToString();
                    ut1.Password = rd["Password"].ToString();

                    if (ut1.Password == p_oldPass)
                    {
                        retVal = true;
                        break;
                    }
                    else
                    {
                        retVal = false;
                    }
                }
            }
            else
            {
                ut1 = null;
            }
            con4.Close();
            return retVal;
            }
        }
    }


