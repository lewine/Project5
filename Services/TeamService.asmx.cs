using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Linq;

namespace HoopHupTeamService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TeamService : System.Web.Services.WebService
    {
        //this is the data
        private string gamesPath => Server.MapPath("~/App_Data/Games.xml");
        private string schedulePath => Server.MapPath("~/App_Data/Schedule.xml");


        [WebMethod]
        public string GetTeamRecord(string team)
        {
            int wins = 0;
            int losses = 0;
            XDocument doc = XDocument.Load(gamesPath);

            foreach (var game in doc.Descendants("Game"))
            {
                string team1 = game.Element("Team1")?.Value;
                string team2 = game.Element("Team2")?.Value;

                int score1 = int.Parse(game.Element("Score1")?.Value ?? "0");
                int score2 = int.Parse(game.Element("Score2")?.Value ?? "0");

                if (team == team1 || team == team2)
                {
                    if ((team == team1 && score1 > score2) || (team == team2 && score2 > score1))
                    {
                        wins++;
                    }
                    else
                    {
                        losses++;
                    }
                }
            }
            return $"{team} Record: {wins} Wins - {losses} Losses";
        }

        [WebMethod]
        public double GetTeamAveragePoints(string team)
        {
            int totalPoints = 0;
            int gamesPlayed = 0;

            XDocument doc = XDocument.Load(gamesPath);
            foreach (var game in doc.Descendants("Game"))
            {
                string team1 = game.Element("Team1")?.Value;
                string team2 = game.Element("Team2")?.Value;
                int score1 = int.Parse(game.Element("Score1")?.Value ?? "0");
                int score2 = int.Parse(game.Element("Score2")?.Value ?? "0");

                if (team == team1)
                {
                    totalPoints += score1;
                    gamesPlayed++;
                }
                else if (team == team2)
                {
                    totalPoints += score2;
                    gamesPlayed++;
                }
            }

            if(gamesPlayed == 0)
            {
                return 0;
            }
            else
            {
                double avg = totalPoints / gamesPlayed;
                return avg;
            }
        }

        [WebMethod]
        public string GetNextGame(string team)
        {

            List<string> upcoming = new List<string>();

            XDocument doc = XDocument.Load(schedulePath);
            foreach (var matchup in doc.Descendants("Matchup"))
            {
                if (matchup.Element("Played")?.Value == "true")
                {
                    continue;
                }
                else
                {
                    string team1 = matchup.Element("Team1")?.Value;
                    string team2 = matchup.Element("Team2")?.Value;
                    string date = matchup.Element("Date")?.Value;

                    if (team == team1 || team == team2)
                    {
                        upcoming.Add($"{team1} vs {team2}, {date}");
                    }
                }
            }
            if (upcoming.Count == 0)
            {
                return $"Could not find any games on schedule remaining for {team}";
            }
            else
            {
                string returner = "";
                for (int i = 0; i < Math.Min(5, upcoming.Count); i++)
                {
                    returner += upcoming[i];
                    returner += ", ";
                }
                returner = returner.Substring(0, returner.Length - 2);
                return returner;
            }
        }
    }
}
