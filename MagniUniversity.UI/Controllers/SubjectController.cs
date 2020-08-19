using MagniUniversity.Domain.Model;
using MagniUniversity.Service.Interface;
using Newtonsoft.Json;
using System;
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
            try
            {
                var listSubject = _service.List();
                return Json(listSubject, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error_message = "Error: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult Detail(int id)
        {
            try
            {
                var listSubject = _service.GetWithStudentsIds(id);
                return Json(listSubject, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error_message = "Error: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }            
        }

        [HttpPost]
        public JsonResult Save(Subject model) 
        {
            try
            {
                model.Teacher = null;
                model.Course = null;
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

        [HttpGet]
        public ContentResult Information(int id)
        {
            try
            {
                var list = _service.GetSubjecInformation(id);
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