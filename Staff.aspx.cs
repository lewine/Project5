using System;
using System.Web;
using System.Web.UI;
using System.Xml;
using System.IO;


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
                string hashword = CryptoUtils.HashString(password);

                    if (attrUsername != null && attrPassword != null && attrRole != null)
                {
                    if (attrUsername.Value == username && attrPassword.Value == hashword)
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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter a username and password.";
                lblMessage.Visible = true;
                return;
            }

            string hashword = CryptoUtils.HashString(password);

            XmlDocument doc = new XmlDocument();
            string xmlPath = Server.MapPath("~/App_Data/Staff.xml");

            if (File.Exists(xmlPath))
            {
                doc.Load(xmlPath);
            }
            else
            {
                XmlElement root = doc.CreateElement("Staff");
                doc.AppendChild(root);
            }

            XmlNodeList users = doc.SelectNodes("/Staff/User");

            // Check if username already exists
            foreach (XmlNode user in users)
            {
                if (user.Attributes["username"]?.Value == username)
                {
                    lblMessage.Text = "Username already exists.";
                    lblMessage.Visible = true;
                    return;
                }
            }

            XmlElement newUser = doc.CreateElement("User");
            newUser.SetAttribute("username", username);
            newUser.SetAttribute("password", hashword);
            newUser.SetAttribute("role", "staff");

            doc.DocumentElement.AppendChild(newUser);
            doc.Save(xmlPath);

            lblMessage.Text = "Staff registration successful!";
            lblMessage.Visible = true;
        }




    }
}
