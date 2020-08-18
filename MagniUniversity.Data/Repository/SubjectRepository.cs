using DomainModel = MagniUniversity.Domain.Model;
using MagniUniversity.Data.Entity;
using MagniUniversity.Domain.Repository;
using MagniUniversity.Data.Context;
using System.Collections.Generic;
using MagniUniversity.Domain.Model;
using System.Linq;

namespace MagniUniversity.Data.Repository
{
    public class SubjectRepository : RepositoryBase<DomainModel.Subject, Entity.Subject>, ISubjectRepository
    {
        private readonly IEnrollmentRepository _repEnrollment;

        public SubjectRepository(MagniUniversityContext ctx, IEnrollmentRepository repEnrollment) : base(ctx) 
        {
            _repEnrollment = repEnrollment;
        }

        public SubjectInformation GetSubjecInformation(int id)
        {
            SubjectInformation subject = new SubjectInformation();

            var subjData = _db.Subjects.Where(w => w.SubjectId == id)
                .FirstOrDefault();

            if (subjData != null)
            {
                subject.SubjectId = subjData.SubjectId;
                subject.Teacher = _mapper.Map<DomainModel.Teacher>(subjData.Teacher);
                subject.StudentGrades = (from e in _repEnrollment.ListBySubjectId(id)
                                         select new StudentGrade
                                         {
                                             StudentId = e.StudentId,
                                             StudentName = e.Student.Name,
                                             Grade = e.Grade
                                         }).ToList();
            }

            return subject;
        }
    }
}
