using MagniUniversity.Domain.Model;
using MagniUniversity.Service.Interface;
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
            var listCourse = _courseServ.List();
            return Json(listCourse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(Course model) 
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

        [HttpDelete]
        public JsonResult Remove(int id)
        {
            _courseServ.Remove(id);
            return Json(new { Status = "Ok" }, JsonRequestBehavior.AllowGet);
        }
    }
}