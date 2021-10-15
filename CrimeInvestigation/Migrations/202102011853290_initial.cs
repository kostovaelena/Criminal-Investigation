namespace CrimeInvestigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Begstvoes",
                c => new
                    {
                        Ime = c.String(nullable: false, maxLength: 128),
                        Prezime = c.String(),
                        Godini = c.Int(nullable: false),
                        Slika = c.String(),
                        Datum = c.String(),
                        Mesto = c.String(),
                    })
                .PrimaryKey(t => t.Ime);
            
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        Ime = c.String(nullable: false, maxLength: 128),
                        Prezime = c.String(),
                        Vreme = c.String(),
                        Lokacija = c.String(),
                        Tip = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Ime);
            
            CreateTable(
                "dbo.Ischeznats",
                c => new
                    {
                        Ime = c.String(nullable: false, maxLength: 128),
                        Prezime = c.String(),
                        Godini = c.Int(nullable: false),
                        Grad = c.String(),
                        Adresa = c.String(),
                        Datum = c.String(),
                        Vreme = c.String(),
                        Mesto = c.String(),
                        Izgled = c.String(),
                        Slika = c.String(),
                    })
                .PrimaryKey(t => t.Ime);
            
            CreateTable(
                "dbo.Osomnichens",
                c => new
                    {
                        Ime = c.String(nullable: false, maxLength: 128),
                        predmetId = c.Int(nullable: false),
                        Prezime = c.String(),
                        Godini = c.Int(nullable: false),
                        opisOsomnichen = c.String(),
                        Slika = c.String(),
                        tipObvinenie = c.String(),
                    })
                .PrimaryKey(t => t.Ime);
            
            CreateTable(
                "dbo.Policaecs",
                c => new
                    {
                        Ime = c.String(nullable: false, maxLength: 128),
                        policaecId = c.Int(nullable: false),
                        Prezime = c.String(),
                        iskustvo = c.Int(nullable: false),
                        urlslika = c.String(),
                    })
                .PrimaryKey(t => t.Ime);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Policaecs");
            DropTable("dbo.Osomnichens");
            DropTable("dbo.Ischeznats");
            DropTable("dbo.Cases");
            DropTable("dbo.Begstvoes");
        }
    }
}
