using MagniUniversity.Domain.Model;
using System.Collections.Generic;

namespace MagniUniversity.Domain.Repository
{
    public interface ISubjectRepository : IRepositoryBase<Subject>
    {
        SubjectInformation GetSubjecInformation(int id);
    }
}
