namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Niveau",
                c => new
                    {
                        StandardId = c.Int(nullable: false, identity: true),
                        StandardName = c.String(),
                    })
                .PrimaryKey(t => t.StandardId);
            
            CreateTable(
                "dbo.Etudiant",
                c => new
                    {
                        DoB = c.DateTime(precision: 7, storeType: "datetime2"),
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        Photo = c.Binary(),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Single(nullable: false),
                        Standard_StandardId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Niveau", t => t.Standard_StandardId)
                .Index(t => t.Standard_StandardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Etudiant", "Standard_StandardId", "dbo.Niveau");
            DropIndex("dbo.Etudiant", new[] { "Standard_StandardId" });
            DropTable("dbo.Etudiant");
            DropTable("dbo.Niveau");
        }
    }
}
