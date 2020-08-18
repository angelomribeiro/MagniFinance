using MagniUniversity.Service.DTOs;
using System.Collections.Generic;
using DomainModel = MagniUniversity.Domain.Model;

namespace MagniUniversity.Service.Interface
{
    public interface IStudentService : IServiceBase<DomainModel.Student>
    {
        List<StudentGradeDTO> ListGradeByStudentId(int id);
    }
}
