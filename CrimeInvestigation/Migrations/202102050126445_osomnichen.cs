namespace CrimeInvestigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class osomnichen : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OsomnichenCases", "Osomnichen_Ime", "dbo.Osomnichens");
            DropIndex("dbo.OsomnichenCases", new[] { "Osomnichen_Ime" });
            RenameColumn(table: "dbo.OsomnichenCases", name: "Osomnichen_Ime", newName: "Osomnichen_ID");
            DropPrimaryKey("dbo.Osomnichens");
            DropPrimaryKey("dbo.OsomnichenCases");
            AddColumn("dbo.Osomnichens", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Osomnichens", "Ime", c => c.String());
            AlterColumn("dbo.OsomnichenCases", "Osomnichen_ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Osomnichens", "ID");
            AddPrimaryKey("dbo.OsomnichenCases", new[] { "Osomnichen_ID", "Case_ID" });
            CreateIndex("dbo.OsomnichenCases", "Osomnichen_ID");
            AddForeignKey("dbo.OsomnichenCases", "Osomnichen_ID", "dbo.Osomnichens", "ID", cascadeDelete: true);
            DropColumn("dbo.Osomnichens", "predmetId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Osomnichens", "predmetId", c => c.Int(nullable: false));
            DropForeignKey("dbo.OsomnichenCases", "Osomnichen_ID", "dbo.Osomnichens");
            DropIndex("dbo.OsomnichenCases", new[] { "Osomnichen_ID" });
            DropPrimaryKey("dbo.OsomnichenCases");
            DropPrimaryKey("dbo.Osomnichens");
            AlterColumn("dbo.OsomnichenCases", "Osomnichen_ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Osomnichens", "Ime", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Osomnichens", "ID");
            AddPrimaryKey("dbo.OsomnichenCases", new[] { "Osomnichen_Ime", "Case_ID" });
            AddPrimaryKey("dbo.Osomnichens", "Ime");
            RenameColumn(table: "dbo.OsomnichenCases", name: "Osomnichen_ID", newName: "Osomnichen_Ime");
            CreateIndex("dbo.OsomnichenCases", "Osomnichen_Ime");
            AddForeignKey("dbo.OsomnichenCases", "Osomnichen_Ime", "dbo.Osomnichens", "Ime", cascadeDelete: true);
        }
    }
}
