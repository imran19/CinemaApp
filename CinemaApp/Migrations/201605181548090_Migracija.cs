namespace CinemaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracija : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Screen12", "SeatNumber", c => c.String());
            AlterColumn("dbo.Screen13", "SeatNumber", c => c.String());
            AlterColumn("dbo.Screen2", "SeatNumber", c => c.String());
            AlterColumn("dbo.Screen22", "SeatNumber", c => c.String());
            AlterColumn("dbo.Screen23", "SeatNumber", c => c.String());
            AlterColumn("dbo.Screen3", "SeatNumber", c => c.String());
            AlterColumn("dbo.Screen32", "SeatNumber", c => c.String());
            AlterColumn("dbo.Screen33", "SeatNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Screen33", "SeatNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Screen32", "SeatNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Screen3", "SeatNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Screen23", "SeatNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Screen22", "SeatNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Screen2", "SeatNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Screen13", "SeatNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Screen12", "SeatNumber", c => c.Int(nullable: false));
        }
    }
}
