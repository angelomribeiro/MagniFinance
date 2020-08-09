using DomainModel = MagniUniversity.Domain.Model;
using MagniUniversity.Data.Entity;
using MagniUniversity.Domain.Repository;
using MagniUniversity.Data.Context;

namespace MagniUniversity.Data.Repository
{
    public class CourseRepository : RepositoryBase<DomainModel.Course, Course>, ICourseRepository
    {
        public CourseRepository(MagniUniversityContext ctx) : base(ctx) { }
    }
}
