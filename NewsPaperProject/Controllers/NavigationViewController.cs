using NewsPaperProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPaperProject.Controllers
{
    public class NavigationViewController : Controller
    {
        DemoNewEntities Db = new DemoNewEntities();
        // GET: NavigationView
        public ActionResult Index()
        {
            return View(Db.NavigationNames.ToList());
        }
    }
}