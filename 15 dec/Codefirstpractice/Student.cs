using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codefirstpractice
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage ="Please enter Student Id .")]
        [Column("Student ID")]
        public int stuid { get; set; }

        [Required(ErrorMessage ="Please enter Student Name .")]
        [RegularExpression("^[a-zA-Z]+$",ErrorMessage ="Please enter student name")]
        [Column("Student name",TypeName ="varchar")]
        [MaxLength(50)]
        public string name { get; set; }
        public DateTime DOB { get; set; }

        [Range(1,12,ErrorMessage ="please enter valid class")]
        [Required(ErrorMessage ="please enter the class")]
        public int Class { get; set; }

        [EmailAddress(ErrorMessage ="please enter the valid email")]
        [Column("EmailAddress",TypeName ="varchar")]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
