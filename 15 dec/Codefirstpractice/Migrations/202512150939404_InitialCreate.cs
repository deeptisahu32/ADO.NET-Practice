namespace Codefirstpractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IPLCLASSes",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        Captain = c.String(),
                        state = c.String(),
                    })
                .PrimaryKey(t => t.TeamID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IPLCLASSes");
        }
    }
}
