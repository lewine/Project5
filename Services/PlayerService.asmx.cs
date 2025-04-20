using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace Assignment5_CSE445_Group_62.Services
{
    [WebService(Namespace = "http://hoophub.com/")]
    public class PlayerService : System.Web.Services.WebService
    {
        [WebMethod]
        public double GetPlayerAveragePoints(string playerName)     //gets the average of a specified player
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/App_Data/Games.xml"));

            int totalPoints = 0;
            int gamesPlayed = 0;

            XmlNodeList games = doc.SelectNodes("/Games/Game");
            foreach (XmlNode game in games)
            {
                XmlNodeList players = game.SelectNodes("BoxScore/Player");
                foreach (XmlNode player in players)
                {
                    string name = player.Attributes["name"].Value;
                    if (name.Equals(playerName, StringComparison.OrdinalIgnoreCase))
                    {
                        int pts = int.Parse(player.Attributes["pts"].Value);
                        totalPoints += pts;
                        gamesPlayed++;
                    }
                }
            }

            if (gamesPlayed == 0)
            {
                return 0.0;
            }

            return (double)totalPoints / gamesPlayed;
        }

        [WebMethod]
        public int GetTotalGamesPlayed(string playerName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/App_Data/Games.xml"));

            int gamesPlayed = 0;

            XmlNodeList games = doc.SelectNodes("/Games/Game");
            foreach (XmlNode game in games)
            {
                XmlNodeList players = game.SelectNodes("BoxScore/Player");
                foreach (XmlNode player in players)
                {
                    string name = player.Attributes["name"].Value;
                    if (name.Equals(playerName, StringComparison.OrdinalIgnoreCase))
                    {
                        gamesPlayed++;
                        break;
                    }
                }
            }

            return gamesPlayed;
        }


        [WebMethod]
        public string GetPlayerStatsSummary(string playerName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/App_Data/Games.xml"));

            int totalPoints = 0;
            int totalRebounds = 0;
            int totalAssists = 0;
            int gamesPlayed = 0;

            XmlNodeList games = doc.SelectNodes("/Games/Game");
            foreach (XmlNode game in games)
            {
                XmlNodeList players = game.SelectNodes("BoxScore/Player");
                foreach (XmlNode player in players)
                {
                    if (player.Attributes["name"].Value.Equals(playerName, StringComparison.OrdinalIgnoreCase))
                    {
                        totalPoints += int.Parse(player.Attributes["pts"].Value);
                        totalRebounds += int.Parse(player.Attributes["reb"].Value);
                        totalAssists += int.Parse(player.Attributes["ast"].Value);
                        gamesPlayed++;
                    }
                }
            }

            if (gamesPlayed == 0)
            {
                return "Player not found or no stats recorded.";
            }

            double ppg = (double)totalPoints / gamesPlayed;
            double rpg = (double)totalRebounds / gamesPlayed;
            double apg = (double)totalAssists / gamesPlayed;

            return $"PPG: {ppg:F1}, RPG: {rpg:F1}, APG: {apg:F1}";
        }
    }
}
