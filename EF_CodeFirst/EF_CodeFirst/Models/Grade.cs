using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EF_CodeFirst.Models
{
    public class Grade
    {
        [Key, DisplayName("Grade ID")]
        public int GradeId { get; set; }
        [Required, StringLength(50), DisplayName("Grade Name")]
        public required string GradeName { get; set; }
        [Required, StringLength(4, MinimumLength = 4), DisplayName("Section")]
        public required string Section {  get; set; }
        [Required, DisplayName("Student ID")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
