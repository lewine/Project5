using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace Assignment5_CSE445_Group_62.Services
{
    [WebService(Namespace = "http://hoophub.com/")]
    public class LeagueService : WebService
    {
        [WebMethod]
        public string GetTopScorer()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/App_Data/Games.xml"));

            Dictionary<string, int> playerPoints = new Dictionary<string, int>();

            XmlNodeList games = doc.SelectNodes("/Games/Game");
            foreach (XmlNode game in games)
            {
                XmlNodeList players = game.SelectNodes("BoxScore/Player");
                foreach (XmlNode player in players)
                {
                    string name = player.Attributes["name"].Value;
                    int pts = int.Parse(player.Attributes["pts"].Value);

                    if (!playerPoints.ContainsKey(name))
                        playerPoints[name] = 0;

                    playerPoints[name] += pts;
                }
            }

            if (playerPoints.Count == 0)
                return "No player data available.";

            string topScorer = null;
            int maxPoints = -1;

            foreach (var entry in playerPoints)
            {
                if (entry.Value > maxPoints)
                {
                    topScorer = entry.Key;
                    maxPoints = entry.Value;
                }
            }

            return $"{topScorer} is the top scorer with {maxPoints} points.";
        }

        [WebMethod]
        public string GetLeagueStandings()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/App_Data/Games.xml"));

            Dictionary<string, int> teamWins = new Dictionary<string, int>();

            XmlNodeList games = doc.SelectNodes("/Games/Game");
            foreach (XmlNode game in games)
            {
                string team1 = game.SelectSingleNode("Team1").InnerText;
                string team2 = game.SelectSingleNode("Team2").InnerText;
                int score1 = int.Parse(game.SelectSingleNode("Score1").InnerText);
                int score2 = int.Parse(game.SelectSingleNode("Score2").InnerText);

                // Make sure both teams are included
                if (!teamWins.ContainsKey(team1)) teamWins[team1] = 0;
                if (!teamWins.ContainsKey(team2)) teamWins[team2] = 0;

                if (score1 > score2)
                    teamWins[team1]++;
                else if (score2 > score1)
                    teamWins[team2]++;
            }

            // Format output
            string result = "";
            foreach (var team in teamWins)
            {
                result += $"{team.Key}: {team.Value} wins<br />";
            }

            return result;
        }

        [WebMethod]
        public string GetRecentGames()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/App_Data/Games.xml"));

            XmlNodeList gameNodes = doc.SelectNodes("/Games/Game");

            // Store games with parsed date
            List<Tuple<DateTime, XmlNode>> games = new List<Tuple<DateTime, XmlNode>>();

            foreach (XmlNode game in gameNodes)
            {
                DateTime date = DateTime.Parse(game.SelectSingleNode("Date").InnerText);
                games.Add(new Tuple<DateTime, XmlNode>(date, game));
            }

            // Sort descending by date
            games.Sort((a, b) => b.Item1.CompareTo(a.Item1));

            // Take top 3
            var recentGames = games.Take(3);

            string result = "";
            foreach (var entry in recentGames)
            {
                XmlNode game = entry.Item2;
                string date = game.SelectSingleNode("Date").InnerText;
                string team1 = game.SelectSingleNode("Team1").InnerText;
                string team2 = game.SelectSingleNode("Team2").InnerText;
                string score1 = game.SelectSingleNode("Score1").InnerText;
                string score2 = game.SelectSingleNode("Score2").InnerText;

                result += $"{date}: {team1} ({score1}) vs {team2} ({score2})<br />";
            }

            return result;
        }


    }
}
