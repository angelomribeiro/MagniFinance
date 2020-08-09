using DomainModel = MagniUniversity.Domain.Model;
using MagniUniversity.Domain.Repository;
using MagniUniversity.Service.Interface;

namespace MagniUniversity.Service.Service
{
    public class CourseService : ServiceBase<DomainModel.Course>, ICourseService
    {
        public CourseService(ICourseRepository rep) : base(rep) {}
    }
}
