using DomainModel = MagniUniversity.Domain.Model;
using MagniUniversity.Data.Entity;
using MagniUniversity.Domain.Repository;
using MagniUniversity.Data.Context;

namespace MagniUniversity.Data.Repository
{
    public class SubjectRepository : RepositoryBase<DomainModel.Subject, Subject>, ISubjectRepository
    {
        public SubjectRepository(MagniUniversityContext ctx) : base(ctx) { }
    }
}
