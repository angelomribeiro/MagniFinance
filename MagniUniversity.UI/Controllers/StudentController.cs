using MagniUniversity.Domain.Model;
using MagniUniversity.Service.Interface;
using Newtonsoft.Json;
using System;
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
        public JsonResult Save(Student model) 
        {
            try
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

        [HttpGet]
        public ContentResult Grades(int id)
        {
            try
            {
                var list = _service.ListGradeByStudentId(id);
                return Content(JsonConvert.SerializeObject(list), "application/json");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Content(JsonConvert.SerializeObject(new { error_message = "Error: " + ex.Message }));
            }
            
        }
    }
}