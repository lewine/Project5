using Assignment5_CSE445_Group_62.Services;
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


    }
}