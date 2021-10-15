namespace CrimeInvestigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dg : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Policaecs");
            AlterColumn("dbo.Policaecs", "Ime", c => c.String());
            AlterColumn("dbo.Policaecs", "policaecId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Policaecs", "policaecId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Policaecs");
            AlterColumn("dbo.Policaecs", "policaecId", c => c.Int(nullable: false));
            AlterColumn("dbo.Policaecs", "Ime", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Policaecs", "Ime");
        }
    }
}
