using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamADO.NETt
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Group Group { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
