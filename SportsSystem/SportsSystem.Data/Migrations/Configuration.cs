namespace SportsSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;

    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SportsSystemDbContext>
    {
        private const string Folder = @"D:\My Documents\workspace\SoftUni-ASP.NETMVC\SportsSystem\SportsSystem.Web\SampleData\";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SportsSystemDbContext context)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            if (!context.Teams.Any())
            {
                this.SeedTeams(context);
            }

            if (!context.Players.Any())
            {
                this.SeedPlayers(context);
            }
        }

        private void SeedTeams(SportsSystemDbContext context)
        {
            using (var reader = new StreamReader(Folder + "Teams.txt"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    var tokens = line.Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
                    var name = tokens[0];
                    var webSite = tokens[1];
                    var dateFounded = DateTime.Parse(tokens[2]);
                    var nickname = tokens[3];

                    Team team = new Team()
                    {
                        FoundedOn = dateFounded,
                        Name = name,
                        Nickname = nickname,
                        WebSite = webSite
                    };

                    context.Teams.Add(team);
                }

                context.SaveChanges();
            }
        }

        private void SeedPlayers(SportsSystemDbContext context)
        {
            using (var reader = new StreamReader(Folder + "Players.txt"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    var tokens = line.Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
                    var name = tokens[0];
                    var birthDate = DateTime.Parse(tokens[1]);
                    var height = float.Parse(tokens[2]);
                    var teamName = tokens[3];

                    int? teamId = teamName != "(NULL)" ? context.Teams.Where(t => t.Name == teamName).Select(t => t.Id).FirstOrDefault() : (int?)null;

                    Player player = new Player()
                    {
                        BirthDate = birthDate,
                        Height = height,
                        IsEmployed = teamId != null,
                        Name = name,
                        TeamId = teamId
                    };

                    context.Players.Add(player);
                }

                context.SaveChanges();
            }
        }
    }
}
