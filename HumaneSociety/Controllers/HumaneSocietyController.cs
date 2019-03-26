using HumaneSociety.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HumaneSociety.Controllers
{
    public class HumaneSocietyController : Controller
    {
        private HumaneSocietyDBContext db = new HumaneSocietyDBContext();

        // GET: HumaneSociety
        public ActionResult Index()
        {
            return View(db.HumaneSocieties.ToList());
        }

        //GET: HumaneSociety/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: HumaneSociety/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Shelter shelter)
        {
            if (ModelState.IsValid)
            {
                db.HumaneSocieties.Add(shelter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shelter);
        }

        //GET: HumaneSociety/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shelter shelter = db.HumaneSocieties.Find(id);
            if (shelter == null)
            {
                return HttpNotFound();
            }
            return View(shelter);
        }

        //GET: HumaneSociety/Details/id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shelter shelter = db.HumaneSocieties.Find(id);
            if (shelter == null)
            {
                return HttpNotFound();
            }
            return View(shelter);
        }
        //GET: HumaneSociety/Edit/id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shelter shelter = db.HumaneSocieties.Find(id);
            if (shelter == null)
            {
                return HttpNotFound();
            }
            return View(shelter);
        }
        //POST: HumaneSociety/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Shelter shelter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shelter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shelter);
        }
        //POST: HumaneSociety/Delete/id
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfrimed(int id)
        {
            Shelter shelter = db.HumaneSocieties.Find(id);
            db.HumaneSocieties.Remove(shelter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}