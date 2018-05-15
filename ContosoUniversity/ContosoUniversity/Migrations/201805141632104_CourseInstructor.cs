namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseInstructor : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.InstructorCourse", newName: "CourseInstructor");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CourseInstructor", newName: "InstructorCourse");
        }
    }
}
