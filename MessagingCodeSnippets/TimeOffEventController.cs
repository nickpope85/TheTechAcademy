using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ScheduleUsers.Models;

namespace ScheduleUsers.Controllers
{
    public class TimeOffEventController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TimeOffEvent
        public ActionResult Index()
        {
            var timeOffEvents = db.TimeOffEvents.Include(t => t.User);
            return View(timeOffEvents.ToList());
        }

        // GET: TimeOffEvent/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeOffEvent timeOffEvent = db.TimeOffEvents.Find(id);
            if (timeOffEvent == null)
            {
                return HttpNotFound();
            }
            return View(timeOffEvent);
        }

        // GET: TimeOffEvent/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Users, "Id", "FirstName");
            return PartialView("Create");
        }
        
        
        // POST: TimeOffEvent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,Start,End,Note,Title,ActiveSchedule,Id")] TimeOffEvent timeOffEvent)
        {
            if (ModelState.IsValid)
            {
                var userid = User.Identity.GetUserId();
                timeOffEvent.User = db.Users.Where(w => w.Id == userid).First();
                timeOffEvent.EventID = Guid.NewGuid();
                db.TimeOffEvents.Add(timeOffEvent);
                db.SaveChanges();
                return new EmptyResult();
            }

            ViewBag.Id = new SelectList(db.Users, "Id", "FirstName", timeOffEvent.Id);
            return View(timeOffEvent);
            
        }


        // GET: TimeOffEvent/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeOffEvent timeOffEvent = db.TimeOffEvents.Find(id);
            if (timeOffEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "FirstName", timeOffEvent.Id);
            return View(timeOffEvent);
        }

        // POST: TimeOffEvent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,Start,End,Note,Title,ActiveSchedule,Id")] TimeOffEvent timeOffEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeOffEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "FirstName", timeOffEvent.Id);
            return View(timeOffEvent);
        }

        // GET: TimeOffEvent/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeOffEvent timeOffEvent = db.TimeOffEvents.Find(id);
            if (timeOffEvent == null)
            {
                return HttpNotFound();
            }
            return View(timeOffEvent);
        }

        // POST: TimeOffEvent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TimeOffEvent timeOffEvent = db.TimeOffEvents.Find(id);
            db.TimeOffEvents.Remove(timeOffEvent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
