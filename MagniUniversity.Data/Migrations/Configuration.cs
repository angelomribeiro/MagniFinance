namespace MagniUniversity.Data.Migrations
{
    using MagniUniversity.Data.Context;
    using MagniUniversity.Data.Entity;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MagniUniversity.Data.Context.MagniUniversityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MagniUniversityContext context)
        {
            #region student
            var student1 = new Student() { Name = "Mickey Mouse", BirthDay = new DateTime(1990, 2, 10), RegistrationNumber = 1000 };
            var student2 = new Student() { Name = "Donald Duck", BirthDay = new DateTime(1995, 3, 15), RegistrationNumber = 1001 };
            var student3 = new Student() { Name = "Minnie Mouse", BirthDay = new DateTime(1978, 10, 22), RegistrationNumber = 1002 };
            var student4 = new Student() { Name = "Peter Pan", BirthDay = new DateTime(2000, 8, 5), RegistrationNumber = 1003 };

            if (!context.Students.Any())
            {
                context.Students.AddOrUpdate(student1);
                context.Students.AddOrUpdate(student2);
                context.Students.AddOrUpdate(student3);
                context.Students.AddOrUpdate(student4);
            }
            #endregion

            #region course
            var course1 = new Course() { Title = "Design for Beginners" };

            if (!context.Courses.Any())
            {
                context.Courses.AddOrUpdate(course1);
            }
            #endregion

            #region teacher
            var teacher1 = new Teacher() { Name = "Tom Cruise", BirthDay = new DateTime(1980, 5, 20), Salary = 1500M };

            if (!context.Teachers.Any())
            {
                context.Teachers.AddOrUpdate(teacher1);
            }
            #endregion

            #region subject
            var subject1 = new Subject() { Title = "Basic Math", Teacher = teacher1, Course = course1 };
            var subject2 = new Subject() { Title = "Classic Music", Teacher = teacher1, Course = course1 };
            var subject3 = new Subject() { Title = "Modern Art", Teacher = teacher1, Course = course1 };

            if (!context.Subjects.Any())
            {
                context.Subjects.AddOrUpdate(subject1);
                context.Subjects.AddOrUpdate(subject2);
                context.Subjects.AddOrUpdate(subject3);
            }
            #endregion

            #region enrollment
            var enrollment1 = new Enrollment() { Student = student1, Subject = subject1, Grade = "A" };
            var enrollment2 = new Enrollment() { Student = student1, Subject = subject2, Grade = "A+" };
            var enrollment3 = new Enrollment() { Student = student2, Subject = subject1, Grade = "B" };
            var enrollment4 = new Enrollment() { Student = student2, Subject = subject2, Grade = "A+" };

            if (!context.Enrollments.Any())
            {
                context.Enrollments.AddOrUpdate(enrollment1);
                context.Enrollments.AddOrUpdate(enrollment2);
                context.Enrollments.AddOrUpdate(enrollment3);
                context.Enrollments.AddOrUpdate(enrollment4);
            }
            #endregion

            base.Seed(context);
        }
    }
}
