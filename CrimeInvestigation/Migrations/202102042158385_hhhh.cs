namespace CrimeInvestigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hhhh : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Cases");
            AddColumn("dbo.Cases", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Osomnichens", "Case_ID", c => c.Int());
            AlterColumn("dbo.Cases", "Ime", c => c.String());
            AddPrimaryKey("dbo.Cases", "ID");
            CreateIndex("dbo.Osomnichens", "Case_ID");
            AddForeignKey("dbo.Osomnichens", "Case_ID", "dbo.Cases", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Osomnichens", "Case_ID", "dbo.Cases");
            DropIndex("dbo.Osomnichens", new[] { "Case_ID" });
            DropPrimaryKey("dbo.Cases");
            AlterColumn("dbo.Cases", "Ime", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Osomnichens", "Case_ID");
            DropColumn("dbo.Cases", "ID");
            AddPrimaryKey("dbo.Cases", "Ime");
        }
    }
}
