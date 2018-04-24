namespace ExamADO.NETt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZHaslan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        YearStudy = c.Int(nullable: false),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AverageScore = c.Double(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.GroupId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Experience = c.Int(nullable: false),
                        Degree = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherSubjects",
                c => new
                    {
                        Teacher_Id = c.Int(nullable: false),
                        Subject_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_Id, t.Subject_Id })
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .Index(t => t.Teacher_Id)
                .Index(t => t.Subject_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Schedules", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.TeacherSubjects", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.TeacherSubjects", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Groups", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Schedules", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropIndex("dbo.TeacherSubjects", new[] { "Subject_Id" });
            DropIndex("dbo.TeacherSubjects", new[] { "Teacher_Id" });
            DropIndex("dbo.Schedules", new[] { "TeacherId" });
            DropIndex("dbo.Schedules", new[] { "GroupId" });
            DropIndex("dbo.Schedules", new[] { "SubjectId" });
            DropIndex("dbo.Students", new[] { "GroupId" });
            DropIndex("dbo.Groups", new[] { "Teacher_Id" });
            DropTable("dbo.TeacherSubjects");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Schedules");
            DropTable("dbo.Students");
            DropTable("dbo.Groups");
        }
    }
}
