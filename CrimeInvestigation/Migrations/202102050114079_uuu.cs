namespace CrimeInvestigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uuu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Osomnichens", "Case_ID", "dbo.Cases");
            DropIndex("dbo.Osomnichens", new[] { "Case_ID" });
            CreateTable(
                "dbo.OsomnichenCases",
                c => new
                    {
                        Osomnichen_Ime = c.String(nullable: false, maxLength: 128),
                        Case_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Osomnichen_Ime, t.Case_ID })
                .ForeignKey("dbo.Osomnichens", t => t.Osomnichen_Ime, cascadeDelete: true)
                .ForeignKey("dbo.Cases", t => t.Case_ID, cascadeDelete: true)
                .Index(t => t.Osomnichen_Ime)
                .Index(t => t.Case_ID);
            
            DropColumn("dbo.Osomnichens", "Case_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Osomnichens", "Case_ID", c => c.Int());
            DropForeignKey("dbo.OsomnichenCases", "Case_ID", "dbo.Cases");
            DropForeignKey("dbo.OsomnichenCases", "Osomnichen_Ime", "dbo.Osomnichens");
            DropIndex("dbo.OsomnichenCases", new[] { "Case_ID" });
            DropIndex("dbo.OsomnichenCases", new[] { "Osomnichen_Ime" });
            DropTable("dbo.OsomnichenCases");
            CreateIndex("dbo.Osomnichens", "Case_ID");
            AddForeignKey("dbo.Osomnichens", "Case_ID", "dbo.Cases", "ID");
        }
    }
}
