namespace CrimeInvestigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ggg : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Ischeznats");
            AddColumn("dbo.Ischeznats", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Ischeznats", "Ime", c => c.String());
            AddPrimaryKey("dbo.Ischeznats", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Ischeznats");
            AlterColumn("dbo.Ischeznats", "Ime", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Ischeznats", "ID");
            AddPrimaryKey("dbo.Ischeznats", "Ime");
        }
    }
}
