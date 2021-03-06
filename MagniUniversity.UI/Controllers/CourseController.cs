﻿using MagniUniversity.Domain.Model;
using MagniUniversity.Service.Interface;
using System;
using System.Web.Mvc;

namespace MagniUniversity.UI.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseServ;

        public CourseController(ICourseService courseServ)
        {
            _courseServ = courseServ;
        }

        [HttpGet]
        public JsonResult Index()
        {
            try
            {
                var listCourse = _courseServ.ListCourseDetail();
                return Json(listCourse, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error_message = "Error: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }            
        }

        [HttpPost]
        public JsonResult Save(Course model) 
        {
            try
            {
                if (model.CourseId == 0)
                {
                    _courseServ.Add(model);
                }
                else
                {
                    _courseServ.Update(model);
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
                _courseServ.Remove(id);                
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