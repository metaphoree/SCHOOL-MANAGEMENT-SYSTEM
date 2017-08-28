namespace Rhino_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Userkan : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.StudentDatas", name: "Email", newName: "UserId");
            RenameIndex(table: "dbo.StudentDatas", name: "IX_Email", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.StudentDatas", name: "IX_UserId", newName: "IX_Email");
            RenameColumn(table: "dbo.StudentDatas", name: "UserId", newName: "Email");
        }
    }
}
