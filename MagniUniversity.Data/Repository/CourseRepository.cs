using DomainModel = MagniUniversity.Domain.Model;
using MagniUniversity.Data.Entity;
using MagniUniversity.Domain.Repository;
using MagniUniversity.Data.Context;
using System.Collections.Generic;
using MagniUniversity.Domain.Model;
using System.Linq;

namespace MagniUniversity.Data.Repository
{
    public class CourseRepository : RepositoryBase<DomainModel.Course, Entity.Course>, ICourseRepository
    {
        public CourseRepository(MagniUniversityContext ctx) : base(ctx) { }

        public List<CourseDetail> ListCourseDetail()
        {
            var coursesAllData = (from e in _db.Enrollments.ToList()
                          join s in _db.Subjects on e.SubjectId equals s.SubjectId
                          join c in _db.Courses on s.CourseId equals c.CourseId
                          join t in _db.Teachers on s.TeacherId equals t.TeacherId
                          select new { c.CourseId, s.SubjectId, t.TeacherId, e.StudentId, e.Grade } );

            List<CourseDetail> listDetail = new List<CourseDetail>();
            foreach (var course in _db.Courses.ToList())
            {
                listDetail.Add(new CourseDetail { 
                    CourseId = course.CourseId,
                    Title = course.Title,
                    TeachersNumber = coursesAllData.Where(w => w.CourseId == course.CourseId)
                        .Select(s => s.TeacherId).Distinct().Count(),
                    StudentsNumber = coursesAllData.Where(w => w.CourseId == course.CourseId)
                        .Select(s => s.StudentId).Distinct().Count(),
                    GradeAvg = coursesAllData.Where(w => w.CourseId == course.CourseId)
                        .Select(s => s.Grade).Average()
                });
            }

            return listDetail;
        }
    }
}
