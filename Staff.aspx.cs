using System;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace Assignment5_CSE445_Group_62
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"]?.ToString() == "staff")
            {
                pnlAdmin.Visible = true;
                lblAdminWelcome.Text = "Welcome, " + Session["username"];
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/App_Data/Staff.xml"));

            XmlNodeList users = doc.SelectNodes("/Staff/User");

            bool matchFound = false;
            foreach (XmlNode user in users)
            {
                var attrUsername = user.Attributes["username"];
                var attrPassword = user.Attributes["password"];
                var attrRole = user.Attributes["role"];
                if (attrUsername != null && attrPassword != null && attrRole != null)
                {
                    if (attrUsername.Value == username && attrPassword.Value == password)
                    {
                        matchFound = true;
                        if (attrRole.Value == "staff")
                        {
                            Session["username"] = username;
                            Session["role"] = "staff";
                            Response.Redirect("StaffPage.aspx");
                            return;
                        }
                        else
                        {
                            lblMessage.Text = "You do not have staff access.";
                            lblMessage.Visible = true;
                            return;
                        }
                    }
                }
            }
            if (!matchFound)
            {
                lblMessage.Text = "Invalid username or password.";
                lblMessage.Visible = true;
            }

        }

    }
}
