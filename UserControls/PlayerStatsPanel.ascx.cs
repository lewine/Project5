using Assignment5_CSE445_Group_62.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5_CSE445_Group_62.UserControls
{
	public partial class PlayerStatsPanel : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnGetStats_Click(object sender, EventArgs e)
        {
            PlayerService svc = new PlayerService();
            string summary = svc.GetPlayerStatsSummary(txtPlayer.Text);
            lblStats.Text = summary;
        }

    }
}