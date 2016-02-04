using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Connection.Views
{
    public partial class PassChange : System.Web.UI.Page
    {
        /// <summary>
        /// checks whether the old password is correct and makes sure the new password is the one the user intended to change it into
        /// </summary>
        /// <param movedName="sender"></param>
        /// <param movedName="e"></param>
        protected void ButtonChangePass_Click(object sender, EventArgs e)
        {
            string movedUser = Views.main.moveUser;
            string oldPass = txtOldPass.Text;
            string newPass = txtNewPass.Text;
            string confirmPass = txtConfirmPass.Text;
            bool isVerify = false;

            // creates a new connObj if none exists
            if (main.connObj == null)
            {
                main.connObj = new Models.AccessConnection();
            }
            else
            {
                // sends parameters to the service to check if correct and replaces the data in the db
                isVerify = main.connObj.ChangePass(movedUser, oldPass, newPass, confirmPass);
                if (isVerify == true)
                {                    
               Response.Redirect("main.aspx");                    
                }
                else
                {
                    lbl_changePass.Text = "wrong password!";
                    Views.main.connObj = null;
                }
            }
        }
    }
}