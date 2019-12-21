namespace MVC_A.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_A.Models.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MVC_A.Models.MyContext";
        }

        protected override void Seed(MVC_A.Models.MyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Classes.AddOrUpdate(c => c.Id,
                new Models.Class{ Id = 1, Name = @"T1807E", CreatedAt = DateTime.Now, DeletedAt = DateTime.Now },
                            new Models.Class{ Id = 2, Name = @"T1807A", CreatedAt = DateTime.Now, DeletedAt = DateTime.Now });
            context.Students.AddOrUpdate(s => s.Id,
                new Models.Student{ Id = 1, ClassId = 1, Name = @"Dat", Code = @"D123", Phone = @"876543210", Email = @"datpt123@fpt.edu.vn" },
                            new Models.Student{ Id = 2, ClassId = 2, Name = @"DatFake", Code = @"D321",Phone = @"012345678", Email = @"datpt321@fpt.edu.vn" });
        }
    }
}
