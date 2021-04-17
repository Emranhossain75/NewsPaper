using NewsPaperProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NewsPaperProject.Controllers
{
    public class AdminPanelController : Controller
    {
        DemoNewEntities Db = new DemoNewEntities();
        // GET: AdminPanel
        public ActionResult DashBoard()
        {
            return View();
        }  
        public ActionResult NewCatagoryAdd()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult NewCatagoryAdd(NavigationName ad)
        {
            using (var context = new DemoNewEntities())
            {
                context.NavigationNames.Add(ad);
                context.SaveChanges();
            }
            return RedirectToAction("VIewNag");

        }
        public ActionResult VIewNag()
        {
            return View(Db.NavigationNames.ToList());
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NavigationName nav = Db.NavigationNames.Find(id);
            if (nav == null)
            {
                return HttpNotFound();
            }
            return View(nav);
        }

        // POST: FiftyTakaData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NavId,CatagoryName")] NavigationName Var)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(Var).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("VIewNag");
            }
            return View(Var);
        }

       // GET: FiftyTakaData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NavigationName Nav = Db.NavigationNames.Find(id);
            if (Nav == null)
            {
                return HttpNotFound();
            }
            return View(Nav);
        }

        // POST: FiftyTakaData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NavigationName Nav = Db.NavigationNames.Find(id);
            Db.NavigationNames.Remove(Nav);
            Db.SaveChanges();
            return RedirectToAction("VIewNag");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}
