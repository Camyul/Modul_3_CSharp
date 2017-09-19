namespace AspNetMvcFirstApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStudenttoStudentViewModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Students", newName: "StudentViewModels");
            AlterColumn("dbo.StudentViewModels", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.StudentViewModels", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentViewModels", "LastName", c => c.String());
            AlterColumn("dbo.StudentViewModels", "FirstName", c => c.String());
            RenameTable(name: "dbo.StudentViewModels", newName: "Students");
        }
    }
}
