using MagniUniversity.Domain.Model;
using MagniUniversity.Service.Interface;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace MagniUniversity.UI.Controllers
{
    public class GradeController : Controller
    {
        private readonly IEnrollmentService _service;

        public GradeController(IEnrollmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public JsonResult Index()
        {
            try
            {
                var list = _service.List();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error_message = "Error: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Save(Enrollment model)
        {
            try
            {
                model.Student = null;
                model.Subject = null;
                var retModel = _service.Save(model);
                return Json(new { Status = "Ok" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error_message = "Error: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpDelete]
        public JsonResult Remove(int id)
        {
            try
            {
                _service.Remove(id);
                return Json(new { Status = "Ok" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error_message = "Error: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}