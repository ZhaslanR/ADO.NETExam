using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace ExamADO.NETt
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearStudy { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}