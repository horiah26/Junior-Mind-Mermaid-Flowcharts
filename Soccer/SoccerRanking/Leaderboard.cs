using SoccerRanking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace RankingBoard
{
    public class Leaderboard
    {
        private SoccerTeam[] teams = new SoccerTeam[0];

        public void AddTeam(SoccerTeam newTeam)
        {
            Array.Resize(ref teams, teams.Length + 1);
            teams[teams.Length - 1] = newTeam;

            BubbleSort();
        }

        public void Match(SoccerTeam Team1, SoccerTeam Team2, int goalsByTeam1, int GoalsByTeam2)
        {
            if (goalsByTeam1 > GoalsByTeam2)
            {
                Team1.UpdatePoints(3);
            }
            else if (goalsByTeam1 < GoalsByTeam2)
            {
                Team2.UpdatePoints(3);
            }
            else
            {
                Team1.UpdatePoints(1);
                Team2.UpdatePoints(1);
            } 
        }

        public int Position(SoccerTeam team)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].IsEqual(team))
                {
                    return i;
                }
            }

            return -1;
        }

        public SoccerTeam TeamInPosition(int position)
        {          
            return teams[position];    
        }

        private void BubbleSort()
        {
            bool swapped;
            do
            {
                swapped = false;

                for (int j = 0; j < teams.Length - 1; j++)
                {
                    if (teams[j].HasFewerPoints(teams[j + 1]))
                    {
                        SoccerTeam temp = teams[j];
                        teams[j] = teams[j + 1];
                        teams[j + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }

}
