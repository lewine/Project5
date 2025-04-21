using Assignment5_CSE445_Group_62.Services;
using Assignment5_CSE445_Group_62;
using HoopHupTeamService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5_CSE445_Group_62
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Simulated login
                Session["username"] = "jason";
                Session["role"] = "member";

                //This is for the fav team cookie
                if (Request.Cookies["FavoriteTeam"] != null)
                {
                    lblFavTeam.Text = $"Howdy! Favorite Team: {Request.Cookies["FavoriteTeam"].Value}";
                }
            }

            lblSession.Text = "Logged in as: " + Session["username"] + " (Role: " + Session["role"] + ")";

            lblLastVisit.Text = "Most recent visitor session started at: " + Application["lastVisit"];

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


        protected void btnTopScorer_Click(object sender, EventArgs e)
        {
            LeagueService svc = new LeagueService();
            string topScorer = svc.GetTopScorer();
            lblTopScorer.Text = "Top Scorer: " + topScorer;
        }

        protected void btnStandings_Click(object sender, EventArgs e)
        {
            LeagueService svc = new LeagueService();
            lblStandings.Text = svc.GetLeagueStandings();
        }

        protected void btnRecentGames_Click(object sender, EventArgs e)
        {
            LeagueService svc = new LeagueService();
            lblRecentGames.Text = svc.GetRecentGames();
        }

        protected void btnHashInput_Click(object sender, EventArgs e)
        {
            string input = txtInputToHash.Text;
            string hash = CryptoUtils.HashString(input);
            lblHashResult.Text = "Hashed Value: " + hash;
        }

        //These are the dang buttons for TeamService
        protected void btnRecord_Click(object sender, EventArgs e)
        {
            var svc = new TeamService();
            lblRecord.Text = svc.GetTeamRecord(txtTeam.Text);
        }

        protected void btnTeamAvg_Click(object sender, EventArgs e)
        {
            var svc = new TeamService();
            double avg = svc.GetTeamAveragePoints(txtTeam.Text);
            lblAvg.Text = $"Avg: {avg} PPG";
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            var svc = new TeamService();
            lblNext.Text = svc.GetNextGame(txtTeam.Text);
        }

        protected void btnSaveFavTeam_Click(object sender, EventArgs e)
        {
            string team = txtFavTeam.Text.Trim();

            if (!string.IsNullOrEmpty(team))
            {
                HttpCookie favCookie = new HttpCookie("FavoriteTeam", team);
                //make it last a week tops
                favCookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(favCookie);

                lblFavTeam.Text = $"Saved! Your favorite team is: {team}";
            }
            else
            {
                lblFavTeam.Text = "Please enter a team name.";
            }
        }

        protected void btnCalcWinPct_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtWins.Text, out int wins) && int.TryParse(txtLosses.Text, out int losses))
            {
                double pct = TeamUtils.CalculateWinPercentage(wins, losses);
                lblWinPct.Text = $"Win Percentage: {pct:F2}%";
            }
            else
            {
                lblWinPct.Text = "Invalid input. Please enter valid numbers.";
            }
        }


    }
}