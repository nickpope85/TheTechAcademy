namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstructorMappingUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CourseInstructor", newName: "InstructorCourse");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.InstructorCourse", newName: "CourseInstructor");
        }
    }
}
