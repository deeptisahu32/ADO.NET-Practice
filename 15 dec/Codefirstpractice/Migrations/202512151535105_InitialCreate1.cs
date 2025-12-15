namespace Codefirstpractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(name: "Student ID", nullable: false),
                        Studentname = c.String(name: "Student name", nullable: false, maxLength: 50, unicode: false),
                        DOB = c.DateTime(nullable: false),
                        Class = c.Int(nullable: false),
                        EmailAddress = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
