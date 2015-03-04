namespace TestTcc2.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestTcc2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestTcc2.Models.UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestTcc2.Models.UsersContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var genres = new List<Genero>
            {
                new Genero { Nome = "Rock" },
                new Genero { Nome = "Jazz" },
                new Genero { Nome = "Metal" },
                new Genero { Nome = "Alternative" },
                new Genero { Nome = "Disco" },
                new Genero { Nome = "Blues" },
                new Genero { Nome = "Latin" },
                new Genero { Nome = "Reggae" },
                new Genero { Nome = "Pop" },
                new Genero { Nome = "Classical" }
            };
        }
    }
}
