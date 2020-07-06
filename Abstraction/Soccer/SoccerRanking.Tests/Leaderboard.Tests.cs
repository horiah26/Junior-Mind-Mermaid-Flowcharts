using System;
using Xunit;
using RankingBoard;
using SoccerRanking;

namespace LeaderboardTests.cs
{
    public class LeaderboardTests
    {
        [Fact]
        public void AddsTeamsInOrder()
        {
            Leaderboard board = new Leaderboard();

            SoccerTeam t1 = new SoccerTeam("FCSB", 5);
            SoccerTeam t2 = new SoccerTeam("Dinamo", 2);
            SoccerTeam t3 = new SoccerTeam("CFR Cluj", 4);
            SoccerTeam t4 = new SoccerTeam("Rapid", 6);
            SoccerTeam t5 = new SoccerTeam("Gloria Bistrita", 3);

            board.AddTeam(t1);
            board.AddTeam(t2);
            board.AddTeam(t3);
            board.AddTeam(t4);
            board.AddTeam(t5);

            Assert.True(board.Position(t1) == 1);
            Assert.True(board.Position(t2) == 4);
            Assert.True(board.Position(t3) == 2);
            Assert.True(board.Position(t4) == 0);
            Assert.True(board.Position(t5) == 3);
        }

        [Fact]
        public void ReturnsTeamInPosition()
        {
            Leaderboard board = new Leaderboard();

            SoccerTeam t1 = new SoccerTeam("FCSB", 5);
            SoccerTeam t2 = new SoccerTeam("Dinamo", 2);
            SoccerTeam t3 = new SoccerTeam("CFR Cluj", 4);
            SoccerTeam t4 = new SoccerTeam("Rapid", 6);
            SoccerTeam t5 = new SoccerTeam("Gloria Bistrita", 3);

            board.AddTeam(t1);
            board.AddTeam(t2);
            board.AddTeam(t3);
            board.AddTeam(t4);
            board.AddTeam(t5);

            Assert.True(t1.IsEqual(board.TeamInPosition(1)));
            Assert.True(t2.IsEqual(board.TeamInPosition(4)));
            Assert.True(t3.IsEqual(board.TeamInPosition(2)));
            Assert.True(t4.IsEqual(board.TeamInPosition(0)));
            Assert.True(t5.IsEqual(board.TeamInPosition(3)));
        }


        [Fact]
        public void MatchWinUpdate()
        {
            Leaderboard board = new Leaderboard();

            SoccerTeam t1 = new SoccerTeam("Dinamo", 5);
            SoccerTeam t2 = new SoccerTeam("FCSB", 2);

            SoccerTeam t1Update = new SoccerTeam("Dinamo", 8);
            SoccerTeam t2Update = new SoccerTeam("FCSB", 2);

            board.AddTeam(t1);
            board.AddTeam(t2);

            board.Match(t1, t2, 2, 1);

            Assert.True(t1.IsEqual(t1Update) && t2.IsEqual(t2Update));
        }

        [Fact]
        public void MatchDrawUpdate()
        {
            Leaderboard board = new Leaderboard();

            SoccerTeam t1 = new SoccerTeam("Dinamo", 5);
            SoccerTeam t2 = new SoccerTeam("FCSB", 2);

            SoccerTeam t1Update = new SoccerTeam("Dinamo", 6);
            SoccerTeam t2Update = new SoccerTeam("FCSB", 3);

            board.AddTeam(t1);
            board.AddTeam(t2);

            board.Match(t1, t2, 2, 2);

            Assert.True(t1.IsEqual(t1Update) && t2.IsEqual(t2Update));
        }
    }
}

