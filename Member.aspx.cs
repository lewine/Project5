using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;

namespace Assignment5_CSE445_Group_62
{
    public partial class Member : System.Web.UI.Page
    {
        string xmlPath = HttpContext.Current.Server.MapPath("~/App_Data/Member.xml");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (captcha.Text.Trim() != "4")
            {
                message.Text = "Dumbass. Go get your smarts up before hooping";
                return;
            }
            string user = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();
            string hashword = CryptoUtils.HashString(password);

            XmlDocument doc = new XmlDocument();
            if (File.Exists(xmlPath))
            {
                doc.Load(xmlPath);
            }
            else
            {
                XmlElement root = doc.CreateElement("Members");
                doc.AppendChild(root);
            }

            XmlElement newUser = doc.CreateElement("Member");
            newUser.SetAttribute("username", user);
            newUser.SetAttribute("password", hashword);

            doc.DocumentElement.AppendChild(newUser);
            doc.Save(xmlPath);

            message.Text = "Success! Registration Complete";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();
            string hashword = CryptoUtils.HashString(password);

            XmlDocument doc = new XmlDocument();
            if (!File.Exists(xmlPath))
            {
                message.Text = "We ain't got any userz";
                return;
            }

            doc.Load(xmlPath);
            XmlNodeList members = doc.SelectNodes("/Members/Member");
            bool found = false;

            foreach (XmlNode member in members)
            {
                var uss = member.Attributes["username"];
                var pss = member.Attributes["password"];

                if(uss != null && pss != null)
                {
                    if(uss.Value == user && pss.Value == hashword)
                    {
                        found = true;
                        Session["username"] = user;
                        Session["role"] = "member";
                        Response.Redirect("Default.aspx");
                        return;
                    }
                }
            }
            if (!found)
            {
                message.Text = "Username or Password Invalid.";
            }

        }

    }
}