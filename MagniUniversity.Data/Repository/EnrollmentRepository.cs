using DomainModel = MagniUniversity.Domain.Model;
using MagniUniversity.Domain.Repository;
using MagniUniversity.Data.Context;
using System.Collections.Generic;
using System.Linq;
using MagniUniversity.Domain.Model;

namespace MagniUniversity.Data.Repository
{
    public class EnrollmentRepository : RepositoryBase<DomainModel.Enrollment, Entity.Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(MagniUniversityContext ctx) : base(ctx) { }

        public ICollection<Enrollment> ListByStudentId(int id)
        {
            return _mapper
                .Map<ICollection<DomainModel.Enrollment>>(_db.Enrollments.Where(w => w.StudentId == id).ToList());
        }

        public ICollection<DomainModel.Enrollment> ListBySubjectId(int id)
        {
            return _mapper
                .Map<ICollection<DomainModel.Enrollment>>(_db.Enrollments.Where(w => w.SubjectId == id).ToList());
        }
    }
}
