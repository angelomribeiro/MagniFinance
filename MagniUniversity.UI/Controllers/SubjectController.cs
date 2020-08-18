using MagniUniversity.Domain.Model;
using MagniUniversity.Service.Interface;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace MagniUniversity.UI.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _service;

        public SubjectController(ISubjectService subjectServ)
        {
            _service = subjectServ;
        }

        [HttpGet]
        public JsonResult Index()
        {
            var listSubject = _service.List();
            return Json(listSubject, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Detail(int id)
        {
            var listSubject = _service.GetWithStudentsIds(id);
            return Json(listSubject, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(Subject model) 
        {
            model.Teacher = null;
            var retModel = _service.Save(model);
            return Json(new { Status = "Ok" }, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Remove(int id)
        {
            _service.Remove(id);
            return Json(new { Status = "Ok" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ContentResult Information(int id)
        {
            var list = _service.GetSubjecInformation(id);
            return Content(JsonConvert.SerializeObject(list), "application/json");
        }
    }
}