using DomainModel = MagniUniversity.Domain.Model;
using MagniUniversity.Service.Interface;
using MagniUniversity.Domain.Repository;
using MagniUniversity.Domain.Model;

namespace MagniUniversity.Service.Service
{
    public class EnrollmentService : ServiceBase<Enrollment>, IEnrollmentService
    {
        private readonly IEnrollmentRepository _rep;
        public EnrollmentService(IEnrollmentRepository rep) : base(rep) 
        {
            _rep = rep;            
        }

        public Enrollment Save(Enrollment command)
        {
            Enrollment enrollment;
            if (command.SubjectId == 0)
            {
                enrollment = _rep.Add(command);
            }
            else
            {
                enrollment = _rep.Update(command);
            }

            return enrollment;
        }
    }
}
