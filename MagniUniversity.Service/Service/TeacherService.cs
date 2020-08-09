using DomainModel = MagniUniversity.Domain.Model;
using MagniUniversity.Domain.Repository;
using MagniUniversity.Service.Interface;

namespace MagniUniversity.Service.Service
{
    public class TeacherService : ServiceBase<DomainModel.Teacher>, ITeacherService
    {
        public TeacherService(ITeacherRepository rep) : base(rep) {}
    }
}
