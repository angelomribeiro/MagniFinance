using MagniUniversity.Domain.Model;
using DomainModel = MagniUniversity.Domain.Model;

namespace MagniUniversity.Service.Interface
{
    public interface ISubjectService : IServiceBase<DomainModel.Subject>
    {
        Subject Save(Subject command);
        Subject GetWithStudentsIds(int id);
        SubjectInformation GetSubjecInformation(int id);
    }
}
