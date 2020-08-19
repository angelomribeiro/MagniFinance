using DomainModel = MagniUniversity.Domain.Model;
using MagniUniversity.Domain.Repository;
using MagniUniversity.Service.Interface;
using MagniUniversity.Domain.Model;
using System.Linq;

namespace MagniUniversity.Service.Service
{
    public class SubjectService : ServiceBase<DomainModel.Subject>, ISubjectService
    {
        private readonly ISubjectRepository _rep;
        private readonly IEnrollmentRepository _repEnrollment;

        public SubjectService(ISubjectRepository rep, IEnrollmentRepository repEnrollment) : base(rep) 
        {
            _rep = rep;
            _repEnrollment = repEnrollment;
        }

        public SubjectInformation GetSubjecInformation(int id)
        {
            return _rep.GetSubjecInformation(id);
        }

        public Subject GetWithStudentsIds(int id)
        {
            var subject = _rep.GetById(id);
            var listEnrollment = _repEnrollment.ListBySubjectId(subject.SubjectId);
            subject.Students = listEnrollment.Select(e => e.StudentId).ToArray();

            return subject;
        }

        public Subject Save(Subject command)
        {
            Subject subject;
            if (command.SubjectId == 0)
            {
                subject = _rep.Add(command);
            } 
            else 
            {
                subject = _rep.Update(command);
            }

            // check if subject has enrollment
            var listEnrollment = _repEnrollment.ListBySubjectId(subject.SubjectId);

            if (!listEnrollment.Any())
            {
                // save students
                foreach (var item in command.Students)
                    _repEnrollment.Add(new Enrollment { 
                        SubjectId = subject.SubjectId,
                        StudentId = item
                    });
            } 
            else
            {
                // remove all enrolment
                foreach(var enroll in listEnrollment)
                {
                    _repEnrollment.Remove(enroll.EnrollmentId);
                }

                // add news or old enrolments
                foreach (var item in command.Students)
                {
                    var oldRecord = listEnrollment.Where(w => w.StudentId == item).FirstOrDefault();
                    // check if is old record
                    if (oldRecord != null)
                    {
                        // add new enrollment using old data
                        _repEnrollment.Add(new Enrollment
                        {
                            SubjectId = subject.SubjectId,
                            StudentId = item,
                            Grade = oldRecord.Grade
                        });
                    }
                    else
                    {
                        _repEnrollment.Add(new Enrollment
                        {
                            SubjectId = subject.SubjectId,
                            StudentId = item
                        });
                    }
                }
            }

            return subject;
        }
    }
}
