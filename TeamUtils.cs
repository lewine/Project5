using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment5_CSE445_Group_62
{
    public class TeamUtils
    {
        public static double CalculateWinPercentage(int wins, int losses)
        {
            int total = wins + losses;
            if (total == 0)
            {
                return 0;
            }
            else
            {
                double himothy = (double)wins / total * 100;
                return himothy;
            }
        }
    }
}