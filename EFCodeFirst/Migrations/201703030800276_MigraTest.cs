namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigraTest : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Etudiant", name: "DoB", newName: "DateOfBirth");
            AlterColumn("dbo.Etudiant", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.Etudiant", "StudentName", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("dbo.Etudiant", "StudentName", unique: true, name: "IX_FirstNameLastName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Etudiant", "IX_FirstNameLastName");
            AlterColumn("dbo.Etudiant", "StudentName", c => c.String());
            AlterColumn("dbo.Etudiant", "DateOfBirth", c => c.DateTime(precision: 7, storeType: "datetime2"));
            RenameColumn(table: "dbo.Etudiant", name: "DateOfBirth", newName: "DoB");
        }
    }
}
