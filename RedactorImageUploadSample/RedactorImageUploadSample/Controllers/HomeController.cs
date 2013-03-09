using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RedactorImageUploadSample.Models;

namespace RedactorImageUploadSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult Upload()
        {
            string link = "/images/trendyol_menu.png";
            List<TestModel> list = Enumerable.Empty<TestModel>().ToList();
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];

                if (file != null)
                {
                    TestModel model = new TestModel();
                    model.Title = file.FileName;
                    list.Add(model);
                    file.SaveAs(Server.MapPath("~/Images/tmp/") + file.FileName);
                    link = "/images/tmp/" + file.FileName;
                }

            }

            return Json(new { filelink = link });
        }

        public JsonResult LoadImages()
        {
            return Json(new List<dynamic>
                            {
                               new { thumb = "/images/tmp/Jellyfish.jpg", image = "/images/tmp/Jellyfish.jpg" }
                            }, JsonRequestBehavior.AllowGet);
        }
    }
}
