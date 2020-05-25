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
            Team1.UpdatePoints(goalsByTeam1);
            Team2.UpdatePoints(GoalsByTeam2);
        }


        public bool IsFirstTeam(SoccerTeam Team)
        {
            return Team.IsEqual(teams[0]);
        }

        public bool IsLastTeam(SoccerTeam Team)
        {
            return Team.IsEqual(teams[teams.Length-1]);
        }

        private void BubbleSort()
        {
            for (int i = 0; i < teams.Length; i++)
            {
                for (int j = 0; j < teams.Length - i - 1; j++)
                {
                    if (teams[j].Compare(teams[j+1]))
                    {
                        Swap(j, j+1);
                    }
                }
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            (int minIndex, int maxIndex) = GetMinMaxIndex(firstIndex, secondIndex);

            SoccerTeam temp = teams[minIndex];
            teams[minIndex] = teams[maxIndex];
            teams[maxIndex] = temp;
        }

        private (int minIndex, int maxIndex) GetMinMaxIndex(int firstIndex, int secondIndex)
        {
            if (firstIndex > secondIndex)
            {
                return (secondIndex, firstIndex);
            }

            return (firstIndex, secondIndex);
        }        
    }

}
