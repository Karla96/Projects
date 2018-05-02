namespace Projekt.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Progress1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Progresses", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Progresses", "UserId", c => c.Int(nullable: false));
        }
    }
}
