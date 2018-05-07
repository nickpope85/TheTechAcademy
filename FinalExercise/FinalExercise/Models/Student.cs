using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace FinalExercise.Models
{
    public class Student
    {
        [DisplayName("ID")] 
        public int Id { get; set; }
        [DisplayName("First Name")] // changes the column name
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.Date)] //converts DateTime to just Date
        [DisplayName("Date of Birth")]
        public DateTime? DoB { get; set; } 
        [DisplayName("Gender")]
        public Gender Gender { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}