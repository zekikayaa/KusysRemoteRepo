using Kusys.Domains.Domains;
using Microsoft.EntityFrameworkCore;

namespace Kusys.DAL.Extentions;

public static class DbContextExtension
{
    public static void InsertCourseData(this ModelBuilder modelBuilder)
    {
        var courses = new List<Course>();

        var course1 = new Course()
        {
            Id = 1,
            Code = "CSI101",
            Name = "Introduction to Computer Science",
            CreatedDate = DateTime.UtcNow
        };

        var course2 = new Course()
        {
            Id = 2,
            Code = "CSI102",
            Name = "Algorithms",
            CreatedDate = DateTime.UtcNow
        };

        var course3 = new Course()
        {
            Id = 3,
            Code = "MAT101",
            Name = "Calculus",
            CreatedDate = DateTime.UtcNow
        };

        var course4 = new Course()
        {
            Id = 4,
            Code = "PHY101",
            Name = "Physics",
            CreatedDate = DateTime.UtcNow
        };

        courses.Add(course1);
        courses.Add(course2);
        courses.Add(course3);
        courses.Add(course4);

        modelBuilder.Entity<Course>().HasData(courses);
    }

    public static void InertStudentsData(this ModelBuilder modelBuilder)
    {
        var students = new List<Student>();

        var student1 = new Student()
        {
            Id = 1,
            FirstName = "Fehmi",
            LastName = "Demir",
            BirthDate = new DateTime(1995, 6, 28),
            CourseId = 1,
            CreatedDate = DateTime.UtcNow
        };

        var student2 = new Student()
        {
            Id = 2,
            FirstName = "Atalay",
            LastName = "Dumenci",
            BirthDate = new DateTime(1994, 2, 14),
            CourseId = 2,
            CreatedDate = DateTime.UtcNow
        };

        var student3 = new Student()
        {
            Id = 3,
            FirstName = "Gurbet",
            LastName = "Sevgi",
            BirthDate = new DateTime(1993, 2, 27),
            CourseId = 3,
            CreatedDate = DateTime.UtcNow
        };

        var student4 = new Student()
        {
            Id = 4,
            FirstName = "Ozkan",
            LastName = "Celen",
            BirthDate = new DateTime(1993, 2, 27),
            CourseId = 4,
            CreatedDate = DateTime.UtcNow
        };


        var student5 = new Student()
        {
            Id = 5,
            FirstName = "Yildiray",
            LastName = "Umut",
            BirthDate = new DateTime(1993, 2, 27),
            CourseId = 3,
            CreatedDate = DateTime.UtcNow
        };

        var student6 = new Student()
        {
            Id = 6,
            FirstName = "Umut",
            LastName = "Eksilmez",
            BirthDate = new DateTime(1993, 2, 27),
            CourseId = 1,
            CreatedDate = DateTime.UtcNow
        };

        students.Add(student1);
        students.Add(student2);
        students.Add(student3);
        students.Add(student4);
        students.Add(student5);
        students.Add(student6);

        modelBuilder.Entity<Student>().HasData(students);
    }
}