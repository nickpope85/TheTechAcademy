using FinalExercise.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace FinalExercise.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var students = new List<Student>()
            {
                new Student {FirstName="Crash", LastName="Davis", DoB=DateTime.Parse("1972-01-17"), Gender=Gender.Male,},
                new Student {FirstName="Nuke", LastName="LaLoosh", DoB=DateTime.Parse("1981-08-07"), Gender=Gender.Male,},
                new Student {FirstName="Annie", LastName="Savoy", DoB=DateTime.Parse("1975-05-23"), Gender=Gender.Female,},
                new Student {FirstName="Millie", LastName="Doe", DoB=DateTime.Parse("1975-03-19"), Gender=Gender.Female,},
                new Student {FirstName="Larry", LastName="Lollygagger", DoB=DateTime.Parse("1965-10-05"), Gender=Gender.Male,}
            };

        students.ForEach(x => context.Students.Add(x));
        context.SaveChanges();

        }
    }
}