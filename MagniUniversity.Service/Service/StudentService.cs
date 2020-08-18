using DomainModel = MagniUniversity.Domain.Model;
using MagniUniversity.Domain.Repository;
using MagniUniversity.Service.Interface;
using System.Collections.Generic;
using MagniUniversity.Service.DTOs;
using AutoMapper;

namespace MagniUniversity.Service.Service
{
    public class StudentService : ServiceBase<DomainModel.Student>, IStudentService
    {
        private readonly IEnrollmentRepository _enrollRep;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository rep, IEnrollmentRepository enrollRep) : base(rep) 
        {
            _enrollRep = enrollRep;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DomainModel.Enrollment, StudentGradeDTO>()
                    .ForMember(d => d.StudentName, o => o.MapFrom(x => x.Student.Name))
                    .ForMember(d => d.SubjectTitle, o => o.MapFrom(x => x.Subject.Title))
                    .ForMember(d => d.Grade, o => o.MapFrom(x => x.Grade));
            });

            _mapper = config.CreateMapper();
        }

        public List<StudentGradeDTO> ListGradeByStudentId(int id)
        {
            return _mapper.Map<List<StudentGradeDTO>>(_enrollRep.ListByStudentId(id));
        }
    }
}
