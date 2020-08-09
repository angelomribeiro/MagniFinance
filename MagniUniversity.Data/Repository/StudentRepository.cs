using DomainModel = MagniUniversity.Domain.Model;
using MagniUniversity.Data.Entity;
using MagniUniversity.Domain.Repository;
using MagniUniversity.Data.Context;

namespace MagniUniversity.Data.Repository
{
    public class StudentRepository : RepositoryBase<DomainModel.Student, Student>, IStudentRepository
    {
        public StudentRepository(MagniUniversityContext ctx) : base(ctx) { }
    }
}
