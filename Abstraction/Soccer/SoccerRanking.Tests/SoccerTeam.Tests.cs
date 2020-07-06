using System;
using Xunit;
using SoccerRanking;

namespace SoccerTeamTests.cs
{
    public class SoccerTeamTests
    {
        [Fact]
        public void UpdatesScore()
        {
            SoccerTeam Team = new SoccerTeam("FCSB", 12);
            SoccerTeam TeamAFinal = new SoccerTeam("FCSB", 15);

            Team.UpdatePoints(3);

            Assert.True(Team.IsEqual(TeamAFinal));
        }

        [Fact]
        public void Updates2Scores()
        {
            SoccerTeam Team = new SoccerTeam("FCSB", 12);
            SoccerTeam Team2 = new SoccerTeam("FCSB", 15);

            Team.UpdatePoints(5);
            Team2.UpdatePoints(2);

            Assert.True(Team.IsEqual(Team2));
        }

        [Fact]
        public void UpdatesScoreTwice()
        {
            SoccerTeam Team = new SoccerTeam("FCSB", 12);
            SoccerTeam TeamAFinal = new SoccerTeam("FCSB", 20);

            Team.UpdatePoints(3);
            Team.UpdatePoints(5);

            Assert.True(Team.IsEqual(TeamAFinal));
        }

        [Fact]
        public void ComparesScores()
        {
            SoccerTeam Team = new SoccerTeam("FCSB", 12);
            SoccerTeam Team2 = new SoccerTeam("FCSB", 15);

            Assert.True(Team.HasFewerPoints(Team2));
        }

        [Fact]
        public void ComparesScoresReverse()
        {
            SoccerTeam Team = new SoccerTeam("FCSB", 12);
            SoccerTeam Team2 = new SoccerTeam("FCSB", 15);

            Assert.False(Team2.HasFewerPoints(Team));
        }
    }
}

