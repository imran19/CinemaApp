namespace CinemaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Director = c.String(nullable: false),
                        Stars = c.String(nullable: false),
                        Information = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Categories", "Movie_Id", c => c.Int());
            AddColumn("dbo.UserAccounts", "StartedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserAccounts", "Active", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Categories", "Movie_Id");
            AddForeignKey("dbo.Categories", "Movie_Id", "dbo.Movies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Categories", new[] { "Movie_Id" });
            DropColumn("dbo.UserAccounts", "Active");
            DropColumn("dbo.UserAccounts", "StartedDate");
            DropColumn("dbo.Categories", "Movie_Id");
            DropTable("dbo.Movies");
        }
    }
}
