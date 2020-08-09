using AutoMapper;
using DomainModel = MagniUniversity.Domain.Model;
using MagniUniversity.Data.Entity;

namespace MagniUniversity.Data.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DomainModel.Course, Course>().ReverseMap();
            CreateMap<DomainModel.Subject, Subject>().ReverseMap();
            CreateMap<DomainModel.Teacher, Teacher>().ReverseMap();
            CreateMap<DomainModel.Student, Student>().ReverseMap();
            CreateMap<DomainModel.Enrollment, Enrollment>().ReverseMap();
        }
    }
}
