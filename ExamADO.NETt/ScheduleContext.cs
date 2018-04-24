namespace ExamADO.NETt
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ScheduleContext : DbContext
    {
        public ScheduleContext()
            : base("name=ScheduleContext")
        {
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}