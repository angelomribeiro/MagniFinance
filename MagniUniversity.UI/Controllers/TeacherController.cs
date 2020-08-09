using MagniUniversity.Domain.Model;
using MagniUniversity.Service.Interface;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace MagniUniversity.UI.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
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
        public JsonResult Save(Teacher model) 
        {
            if (model.TeacherId == 0)
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