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
                          select new { c.CourseId, s.SubjectId, t.TeacherId, e.StudentId, e.Grade } ).ToList();

            List<CourseDetail> listDetail = new List<CourseDetail>();
            foreach (var course in _db.Courses.ToList())
            {
                var curseDetail = new CourseDetail();
                curseDetail.CourseId = course.CourseId;
                curseDetail.Title = course.Title;
                curseDetail.TeachersNumber = coursesAllData.Where(w => w.CourseId == course.CourseId)
                        .Select(s => s.TeacherId).Distinct().Count();
                curseDetail.StudentsNumber = coursesAllData.Where(w => w.CourseId == course.CourseId)
                        .Select(s => s.StudentId).Distinct().Count();
                curseDetail.GradeAvg = coursesAllData.Where(w => w.CourseId == course.CourseId).Select(s => s.Grade).Count() == 0 ? 
                    0M : 
                    coursesAllData.Where(w => w.CourseId == course.CourseId).Select(s => s.Grade).Average();

                listDetail.Add(curseDetail);
            }

            return listDetail;
        }
    }
}
