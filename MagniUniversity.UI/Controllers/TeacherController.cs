using MagniUniversity.Domain.Model;
using MagniUniversity.Service.Interface;
using Newtonsoft.Json;
using System;
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
            try
            {
                var list = _service.List();
                return Content(JsonConvert.SerializeObject(list), "application/json");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Content(JsonConvert.SerializeObject(new { error_message = "Error: " + ex.Message }));
            }
        }

        [HttpPost]
        public JsonResult Save(Teacher model) 
        {
            try
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