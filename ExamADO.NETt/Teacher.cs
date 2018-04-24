using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace ExamADO.NETt
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public string Degree { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}