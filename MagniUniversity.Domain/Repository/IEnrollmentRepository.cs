using MagniUniversity.Domain.Model;
using System.Collections.Generic;

namespace MagniUniversity.Domain.Repository
{
    public interface IEnrollmentRepository : IRepositoryBase<Enrollment>
    {
        ICollection<Enrollment> ListBySubjectId(int id);
        ICollection<Enrollment> ListByStudentId(int id);
    }
}
