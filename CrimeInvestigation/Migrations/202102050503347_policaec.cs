namespace CrimeInvestigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class policaec : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Policaecs", "Case_ID", c => c.Int());
            CreateIndex("dbo.Policaecs", "Case_ID");
            AddForeignKey("dbo.Policaecs", "Case_ID", "dbo.Cases", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Policaecs", "Case_ID", "dbo.Cases");
            DropIndex("dbo.Policaecs", new[] { "Case_ID" });
            DropColumn("dbo.Policaecs", "Case_ID");
        }
    }
}
