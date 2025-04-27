using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using Assignment5_CSE445_Group_62.Services;

namespace Assignment5_CSE445_Group_62
{
    public partial class Member : System.Web.UI.Page
    {
        string xmlPath = HttpContext.Current.Server.MapPath("~/App_Data/Member.xml");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null && Session["role"]?.ToString() == "member")
                {
                    pnlLogin.Visible = false;
                    pnlWelcome.Visible = true;
                    lblWelcomeUser.Text = Session["username"].ToString();
                    if (Session["favoriteTeam"] != null)
                    {
                        lblFavoriteTeam.Text = "Your favorite team: " + Session["favoriteTeam"].ToString();
                    }

                }
                else
                {
                    pnlLogin.Visible = true;
                    pnlWelcome.Visible = false;
                }
            }
        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (captcha.Text.Trim() != "4")
            {
                message.Text = "Go get your smarts up before hooping";
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
                    if (uss.Value == user && pss.Value == hashword)
                    {
                        found = true;
                        Session["username"] = user;
                        Session["role"] = "member";
                        var favTeamAttr = member.Attributes["favoriteTeam"];
                        if (favTeamAttr != null)
                        {
                            Session["favoriteTeam"] = favTeamAttr.Value;
                        }

                        Response.Redirect("Member.aspx");
                        return;
                    }
                }
            }
            if (!found)
            {
                message.Text = "Username or Password Invalid.";
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }

        protected void btnSaveTeam_Click(object sender, EventArgs e)
        {
            string favorite = txtFavoriteTeam.Text.Trim();
            if (string.IsNullOrEmpty(favorite))
            {
                lblFavoriteTeam.Text = "Please enter a team name.";
                return;
            }

            if (Session["username"] == null)
            {
                lblFavoriteTeam.Text = "You must be logged in.";
                return;
            }

            string user = Session["username"].ToString();
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);

            XmlNodeList members = doc.SelectNodes("/Members/Member");

            foreach (XmlNode member in members)
            {
                var uss = member.Attributes["username"];
                if (uss != null && uss.Value == user)
                {
                    if (member.Attributes["favoriteTeam"] == null)
                    {
                        XmlAttribute newAttr = doc.CreateAttribute("favoriteTeam");
                        member.Attributes.Append(newAttr);
                    }
                    member.Attributes["favoriteTeam"].Value = favorite;
                    break;
                }
            }

            doc.Save(xmlPath);

            Session["favoriteTeam"] = favorite;
            lblFavoriteTeam.Text = "Your favorite team is now saved: " + favorite;
        }

        protected void btnAvg_Click(object sender, EventArgs e)
        {
            PlayerService svc = new PlayerService();
            double avg = svc.GetPlayerAveragePoints(txtPlayerAvg.Text);
            lblAvg.Text = "Avg PPG: " + avg.ToString("F1");
        }

        protected void btnGames_Click(object sender, EventArgs e)
        {
            PlayerService svc = new PlayerService();
            int total = svc.GetTotalGamesPlayed(txtPlayerGames.Text);
            lblGames.Text = "Games Played: " + total.ToString();
        }

        protected void btnSummary_Click(object sender, EventArgs e)
        {
            PlayerService svc = new PlayerService();
            string summary = svc.GetPlayerStatsSummary(txtPlayerSummary.Text);
            lblSummary.Text = summary;
        }

        protected void btnHashInput_Click(object sender, EventArgs e)
        {
            string input = txtInputToHash.Text;
            string hash = CryptoUtils.HashString(input);
            lblHashResult.Text = "Hashed Value: " + hash;
        }



    }
}