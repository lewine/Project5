using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Assignment5_CSE445_Group_62
{
    public partial class StaffPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"]?.ToString() != "staff")
            {
                Response.Redirect("Default.aspx"); // Block access if not staff
                return;
            }

        }

        protected void btnAddGame_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/App_Data/Games.xml");
            doc.Load(path);

            XmlNode gamesNode = doc.SelectSingleNode("/Games");

            XmlElement game = doc.CreateElement("Game");

            XmlElement date = doc.CreateElement("Date");
            date.InnerText = txtDate.Text;
            game.AppendChild(date);

            XmlElement league = doc.CreateElement("League");
            league.InnerText = txtLeague.Text;
            game.AppendChild(league);

            XmlElement team1 = doc.CreateElement("Team1");
            team1.InnerText = txtTeam1.Text;
            game.AppendChild(team1);

            XmlElement team2 = doc.CreateElement("Team2");
            team2.InnerText = txtTeam2.Text;
            game.AppendChild(team2);

            XmlElement score1 = doc.CreateElement("Score1");
            score1.InnerText = txtScore1.Text;
            game.AppendChild(score1);

            XmlElement score2 = doc.CreateElement("Score2");
            score2.InnerText = txtScore2.Text;
            game.AppendChild(score2);

            XmlElement boxScore = doc.CreateElement("BoxScore");

            XmlElement player1 = doc.CreateElement("Player");
            player1.SetAttribute("name", txtPlayer1.Text);
            player1.SetAttribute("team", txtTeam1.Text);
            player1.SetAttribute("pts", txtPts1.Text);
            player1.SetAttribute("reb", txtReb1.Text);
            player1.SetAttribute("ast", txtAst1.Text);
            boxScore.AppendChild(player1);

            XmlElement player2 = doc.CreateElement("Player");
            player2.SetAttribute("name", txtPlayer2.Text);
            player2.SetAttribute("team", txtTeam2.Text);
            player2.SetAttribute("pts", txtPts2.Text);
            player2.SetAttribute("reb", txtReb2.Text);
            player2.SetAttribute("ast", txtAst2.Text);
            boxScore.AppendChild(player2);

            game.AppendChild(boxScore);
            gamesNode.AppendChild(game);

            doc.Save(path);

            lblAddGameStatus.Text = "Game successfully added!";
        }


    }
}