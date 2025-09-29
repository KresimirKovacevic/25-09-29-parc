using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_CodeFirst.Models
{
    public class Student
    {
        [Key, DisplayName("Student ID")]
        public int StudentId { get; set; }
        [Required, StringLength(50), DisplayName("Student Name")]
        public required string StudentName { get; set; }
        [Required, DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required, DisplayName("Height (cm)")]
        public decimal Height { get; set; }
        [Required, DisplayName("Weight (kg)")]
        public float Weight { get; set; }
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
        [NotMapped, DisplayName("Grade Count")]
        public int GradesCount => Grades.Count;
    }
}
