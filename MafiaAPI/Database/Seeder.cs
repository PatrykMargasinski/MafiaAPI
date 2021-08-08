using System.Collections.Generic;
using MafiaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using MafiaAPI.Repositories;

namespace MafiaAPI.Database
{
    public static class Seeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boss>().HasData(prepareBosses());
            modelBuilder.Entity<Player>().HasData(preparePlayers());
            modelBuilder.Entity<Agent>().HasData(prepareAgents());
            modelBuilder.Entity<Mission>().HasData(prepareMissions());
            modelBuilder.Entity<PerformingMission>().HasData(preparePerformingMissions());
            modelBuilder.Entity<Report>().HasData(prepareReports());
        }

        private static IList<Boss> prepareBosses()
        {
            return new List<Boss>
            {
                new Boss {Id=1, FirstName = "Patricio", LastName = "Rico", Money = 5000, LastSeen = DateTime.Now },
                new Boss {Id=2, FirstName = "Rodrigo", LastName = "Margherita", Money = 5000, LastSeen = DateTime.Now }
            };
        }

        private static IList<Report> prepareReports()
        {
            return new List<Report>
            {
            };
        }

        private static IList<Player> preparePlayers()
        {
            return new List<Player> {
                new Player{Id=1, Nick="mafia", Password="tlnK6HiwFF4+b4DRVaVdRlIPtzduirsf8W3+nbXlLWlf9c/J", BossId=1}, //password: a
                new Player{Id=2, Nick="tomek", Password="d2JZt0Jz9UzgW1l544W2WnOaX14u/pfGUDYTQzv5AEWk3W7D", BossId=2} //password: b
            };
        }

        private static IList<Agent> prepareAgents()
        {
            return new List<Agent> {
                new Agent{Id=1, BossId=1, FirstName="Jotaro", LastName="Kujo", Strength=10, Intelligence=10, Dexterity=10, Income=100},
                new Agent{Id=2, BossId=1, FirstName="Adam", LastName="Mickiewicz", Strength=5, Intelligence=5, Dexterity=5, Income=50},
                new Agent{Id=3, BossId=2, FirstName="Natalia", LastName="Natsu", Strength=7, Intelligence=3, Dexterity=4, Income=70},
                new Agent{Id=4, FirstName="Eleonora", LastName="Lora", Strength=8, Intelligence=0, Dexterity=7, Income=30},
                new Agent{Id=5, BossId=1, FirstName="Robert", LastName="Makłowicz", Strength=3, Intelligence=5, Dexterity=1, Income=200},
            };
        }

        private static IList<Mission> prepareMissions()
        {
            return new List<Mission> {
                new Mission{Id=1, Name="Bank robbery", DifficultyLevel=7, Loot=5000, Duration=30},
                new Mission{Id=2, Name="Senator assassination", DifficultyLevel=9, Loot=10000, Duration=60},
                new Mission{Id=3, Name="Party", DifficultyLevel=2, Loot=100, Duration=10},
                new Mission{Id=4, Name="Buy a coffee", DifficultyLevel=1, Loot=10, Duration=5},
                new Mission{Id=5, Name="Money laundering", DifficultyLevel=5, Loot=1000, Duration=55},
                new Mission{Id=6, Name="Car theft", DifficultyLevel=6, Loot=2000, Duration=3600},
                new Mission{Id=7, Name="Arms trade", DifficultyLevel=8, Loot=4000, Duration=15}
            };
        }

        private static IList<PerformingMission> preparePerformingMissions()
        {
            return new List<PerformingMission>{
            };
        }
    }
}