using MagniUniversity.Domain.Model;
using MagniUniversity.Service.Interface;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace MagniUniversity.UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public ContentResult Index()
        {
            var list = _service.List();
            return Content(JsonConvert.SerializeObject(list), "application/json");
        }

        [HttpPost]
        public JsonResult Save(Student model) 
        {
            if (model.StudentId == 0)
            {
                _service.Add(model);
            }
            else
            {
                _service.Update(model);
            }
            
            return Json(new { Status = "Ok" }, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Remove(int id)
        {
            _service.Remove(id);
            return Json(new { Status = "Ok" }, JsonRequestBehavior.AllowGet);
        }
    }
}