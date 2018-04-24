using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;

namespace ExamADO.NETt
{
    public class Student
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public double AverageScore { get; set; }
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}