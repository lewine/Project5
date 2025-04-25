using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5_CSE445_Group_62
{
    //ALTHOUGH THIS IS IN THE USERCONTROLS IT IS STILL TECHNICALLY A SESSION CONTROL ELEMENT
	public partial class LoginControl : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;

            // Simulated login logic
            if ((user == "jason" && pass == "pass123") || (user == "admin" && pass == "admin123"))
            {
                Session["username"] = user;
                if (user == "admin")
                {
                    Session["role"] = "admin";
                }
                else
                {
                    Session["role"] = "member";
                }

                lblResult.Text = "";
                lblSessionStatus.Text = $"Logged in as: {user} (Role: {Session["role"]})";
            }
            else
            {
                lblResult.Text = "Invalid username or password.";
                lblSessionStatus.Text = "";
            }
        }

    }
}