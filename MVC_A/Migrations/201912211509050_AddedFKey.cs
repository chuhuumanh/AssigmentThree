namespace MVC_A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Students", "ClassId");
            AddForeignKey("dbo.Students", "ClassId", "dbo.Classes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "ClassId" });
        }
    }
}
