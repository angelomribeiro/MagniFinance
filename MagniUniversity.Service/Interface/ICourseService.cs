using MagniUniversity.Domain.Model;
using System.Collections.Generic;
using DomainModel = MagniUniversity.Domain.Model;

namespace MagniUniversity.Service.Interface
{
    public interface ICourseService : IServiceBase<DomainModel.Course>
    {
        List<CourseDetail> ListCourseDetail();
    }
}
