using DomainModel = MagniUniversity.Domain.Model;
using MagniUniversity.Data.Entity;
using MagniUniversity.Domain.Repository;
using MagniUniversity.Data.Context;

namespace MagniUniversity.Data.Repository
{
    public class TeacherRepository : RepositoryBase<DomainModel.Teacher, Teacher>, ITeacherRepository
    {
        public TeacherRepository(MagniUniversityContext ctx) : base(ctx) { }
    }
}
