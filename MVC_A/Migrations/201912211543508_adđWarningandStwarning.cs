namespace MVC_A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adđWarningandStwarning : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Warnings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentWarnings",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        ActionId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => new { t.StudentId, t.ActionId });
            
            CreateTable(
                "dbo.WarningStudents",
                c => new
                    {
                        Warning_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Warning_Id, t.Student_Id })
                .ForeignKey("dbo.Warnings", t => t.Warning_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Warning_Id)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WarningStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.WarningStudents", "Warning_Id", "dbo.Warnings");
            DropIndex("dbo.WarningStudents", new[] { "Student_Id" });
            DropIndex("dbo.WarningStudents", new[] { "Warning_Id" });
            DropTable("dbo.WarningStudents");
            DropTable("dbo.StudentWarnings");
            DropTable("dbo.Warnings");
        }
    }
}
