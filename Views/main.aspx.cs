using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

//using Connection.ServiceReference1;


namespace Connection.Views
{
    public partial class main : System.Web.UI.Page
    {

        public static Connection.Models.AccessConnection connObj = null;
        public static string moveUser;

        Service1 client = new Service1();


        // checks for an existing user in the db
        protected void btn_confirm_Click(object sender, EventArgs e)
        {
            bool isVerify = false;

            if (connObj == null)
            {
                connObj = new Models.AccessConnection();

            }

            UserTable ut = new UserTable();
            ut.Username = txt_name.Text;
            ut.Password = txt_pass.Text;
            isVerify = connObj.Verify(ut.Username, ut.Password);

            if (isVerify)
            {
                moveUser = ut.Username;
                Response.Redirect("PassChange.aspx");
            }
            else
            {
                lbl_res.Text = "wrong password / user does not exist";
                connObj = null;
            }
        }

        /// <summary>
        /// creates new user in db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_NewUser_Click(object sender, EventArgs e)
        {
            bool isVerify = false;

            if (connObj == null)
            {
                connObj = new Models.AccessConnection();
            }

            UserTable ut = new UserTable();
            string msg;
            ut.Username = txt_name.Text;
            ut.Password = txt_pass.Text;

            bool checkName= client.GetData(ut);
            if (checkName)
            {
                Response.Redirect("main.aspx");
            }
            else
            {
                lbl_res.Text = "Username already exists";
                connObj = null;
            }
        }
    }
}

