using DomainModel = MagniUniversity.Domain.Model;
using MagniUniversity.Domain.Repository;
using MagniUniversity.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace MagniUniversity.Data.Repository
{
    public class EnrollmentRepository : RepositoryBase<DomainModel.Enrollment, Entity.Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(MagniUniversityContext ctx) : base(ctx) { }

        public ICollection<DomainModel.Enrollment> ListBySubjectId(int id)
        {
            return _mapper
                .Map<ICollection<DomainModel.Enrollment>>(_db.Enrollments.Where(w => w.SubjectId == id).ToList());
        }
    }
}
