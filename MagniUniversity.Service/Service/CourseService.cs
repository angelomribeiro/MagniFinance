using DomainModel = MagniUniversity.Domain.Model;
using MagniUniversity.Domain.Repository;
using MagniUniversity.Service.Interface;
using System.Collections.Generic;
using MagniUniversity.Service.DTOs;
using System.Linq;

namespace MagniUniversity.Service.Service
{
    public class CourseService : ServiceBase<DomainModel.Course>, ICourseService
    {
        private readonly ICourseRepository _rep;
        public CourseService(ICourseRepository rep) : base(rep) 
        {
            _rep = rep;
        }

        public List<DomainModel.CourseDetail> ListCourseDetail()
        {
            return _rep.ListCourseDetail();
        }
    }
}
