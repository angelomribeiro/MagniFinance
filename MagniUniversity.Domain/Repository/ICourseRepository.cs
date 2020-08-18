using MagniUniversity.Domain.Model;
using System.Collections.Generic;

namespace MagniUniversity.Domain.Repository
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        List<CourseDetail> ListCourseDetail();
    }
}
