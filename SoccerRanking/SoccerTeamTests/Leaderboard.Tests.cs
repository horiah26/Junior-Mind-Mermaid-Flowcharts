using System;
using Xunit;
using RankingBoard;
using SoccerRanking;

namespace LeaderboardTests.cs
{
    public class LeaderboardTests
    {
        [Fact]
        public void AddsFIrstTeam()
        {
            Leaderboard board = new Leaderboard();

            SoccerTeam t1 = new SoccerTeam("FCSB", 5);
            SoccerTeam t2 = new SoccerTeam("CFR Cluj", 4);
            SoccerTeam t3 = new SoccerTeam("Dinamo", 2);

            board.AddTeam(t1);
            board.AddTeam(t2);
            board.AddTeam(t3);

            Assert.True(board.IsFirstTeam(t1));
        }

        [Fact]
        public void AddsLastTeam()
        {
            Leaderboard board = new Leaderboard();

            SoccerTeam t1 = new SoccerTeam("FCSB", 5);
            SoccerTeam t2 = new SoccerTeam("CFR Cluj", 4);
            SoccerTeam t3 = new SoccerTeam("Dinamo", 2);

            board.AddTeam(t1);
            board.AddTeam(t2);
            board.AddTeam(t3);

            Assert.True(board.IsLastTeam(t3));
        }

        [Fact]
        public void SortsBiggestAndSmallest()
        {
            Leaderboard board = new Leaderboard();

            SoccerTeam t1 = new SoccerTeam("Dinamo", 5);
            SoccerTeam t2 = new SoccerTeam("FCSB", 2);
            SoccerTeam t3 = new SoccerTeam("CFR Cluj", 4);
            SoccerTeam t4 = new SoccerTeam("Gloria Bistrita", 3);
            SoccerTeam t5 = new SoccerTeam("Rapid", 6);

            board.AddTeam(t1);
            board.AddTeam(t2);
            board.AddTeam(t3);
            board.AddTeam(t4);
            board.AddTeam(t5);

            Assert.True(board.IsFirstTeam(t5) && board.IsLastTeam(t2));
        }

        [Fact]
        public void UpdatesMatches()
        {
            Leaderboard board = new Leaderboard();

            SoccerTeam t1 = new SoccerTeam("Dinamo", 5);
            SoccerTeam t2 = new SoccerTeam("FCSB", 2);

            SoccerTeam t1Update = new SoccerTeam("Dinamo", 7);
            SoccerTeam t2Update = new SoccerTeam("FCSB", 3);

            board.AddTeam(t1);
            board.AddTeam(t2);

            board.Match(t1, t2, 2, 1);

            Assert.True(t1.IsEqual(t1Update) && t2.IsEqual(t2Update));
        }
    }
}

