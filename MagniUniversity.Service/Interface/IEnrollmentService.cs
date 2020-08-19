using MagniUniversity.Domain.Model;
using DomainModel = MagniUniversity.Domain.Model;

namespace MagniUniversity.Service.Interface
{
    public interface IEnrollmentService : IServiceBase<DomainModel.Enrollment>
    {
        Enrollment Save(Enrollment command);
    }
}
