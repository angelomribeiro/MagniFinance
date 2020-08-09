using DomainModel = MagniUniversity.Domain.Model;
using MagniUniversity.Domain.Repository;
using MagniUniversity.Service.Interface;

namespace MagniUniversity.Service.Service
{
    public class StudentService : ServiceBase<DomainModel.Student>, IStudentService
    {
        public StudentService(IStudentRepository rep) : base(rep) {}
    }
}
