using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerRanking
{
    public class SoccerTeam
    {
        private readonly string Name;
        private int Points;

        public SoccerTeam(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public bool Compare(SoccerTeam that)
        {
            return this.Points < that.Points;
        }

        public void UpdatePoints(int newPoints)
        {
            Points += newPoints;
        }

        public bool IsEqual(SoccerTeam that)
        {
            return this.Name == that.Name && this.Points == that.Points;
        }

    }
}
