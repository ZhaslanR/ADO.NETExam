using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamADO.NETt
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ScheduleContext())
            {
                Group group = new Group { Name = "SDP-171", YearStudy = 3 };
                context.Groups.Add(group);

                Student student = new Student { Name = "Ryspekov Zhaslan", GroupId = group.Id, AverageScore = 5.4 };
                context.Students.Add(student);

                Subject subject = new Subject { Name = "Математика" };
                context.Subjects.Add(subject);

                Teacher teacher = new Teacher { Name = "Kabenov Olzhas", Experience = 15, Degree = "Магистор" };
                context.Teachers.Add(teacher);
                context.SaveChanges();

                Schedule schedule = new Schedule { Time = DateTime.Now , GroupId = group.Id , SubjectId = subject.Id , TeacherId = teacher.Id};
                context.Schedules.Add(schedule);
                context.SaveChanges();


                var result = from r in context.Schedules
                             join g in context.Groups on r.GroupId equals g.Id
                             join s in context.Subjects on r.SubjectId equals s.Id
                             join t in context.Teachers on r.TeacherId equals t.Id
                             select new
                             {
                                 Time = r.Time,
                                 GroupName = g.Name,
                                 SubjectName = s.Name,
                                 TeacherName = t.Name
                             };

            }
        }
    }
}
