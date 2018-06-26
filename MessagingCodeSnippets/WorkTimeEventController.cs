using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ScheduleUsers.Models;
using ScheduleUsers.ViewModels;

namespace ScheduleUsers.Controllers
{
    [Authorize]
    public class WorkTimeEventController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: WorkTimeEvent
        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            // Grabs the current user ID
            var userId = User.Identity.GetUserId();
            // Grabs all events in Db that have the same user ID as the one logging in
            var workTimeEvents = db.WorkTimeEvents.Where(w => w.User.Id == userId);
            // Creates an empty list of WorkTimeEventViewModel
            List<WorkTimeEventViewModel> UserEventList = new List<WorkTimeEventViewModel>();

            foreach (var item in workTimeEvents)
            {
                // for every event in workTimeEvents, grab only the Start, End, & Note
                UserEventList.Add(new WorkTimeEventViewModel(item.Start, item.End, item.Note));
            }
            return View(UserEventList);
        }
        



        // GET: WorkTimeEvent/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTimeEvent workTimeEvent = db.WorkTimeEvents.Find(id);
            if (workTimeEvent == null)
            {
                return HttpNotFound();
            }
            return View(workTimeEvent);
        }

        // GET: WorkTimeEvent/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        /* *****************************************************************************
         *                             CREATE A WORKTIMEEVENT       
         * *************************************************************************** */
        // POST: WorkTimeEvent/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoginViewModel workTimeEvent)    // workTimeEvent grabs the login email, password, and remember me
        {
            PasswordHasher ph = new PasswordHasher();
            var dt = DateTime.Now;

            // Checks Db users for email that matches the email user typed in
            ApplicationUser dbUser = db.Users.FirstOrDefault(x => x.Email == workTimeEvent.Email);

            // If email is not in Db
            if (dbUser == null)
            {
                ModelState.AddModelError("", "There was a problem with the password or username, please try again or contact you system administrator if the problem continues.");
                return View("~/Views/Account/Login.cshtml");
            }

            // Grabs user hashed PW from Db and PW user typed in and check is they match
            var result = ph.VerifyHashedPassword(dbUser.PasswordHash, workTimeEvent.Password);
            // If PW doesn't match
            if (result != PasswordVerificationResult.Success)
            {
                ModelState.AddModelError("", "There was a problem with the password or username, please try again or contact you system administrator if the problem continues.");
                return View("~/Views/Account/Login.cshtml");
            }

            // Grabs Db event that doesn't have an end value and matches user ID
            var notFinishedEvent = db.WorkTimeEvents.FirstOrDefault(x => x.Id == dbUser.Id && !x.End.HasValue);
            
            // If event has already been created that doesn't have an end value, update end value
            if (notFinishedEvent != null)
            {
                notFinishedEvent.End = dt;
                db.SaveChanges();
                ModelState.Clear();
                ModelState.AddModelError("", "Clock out successful at " + dt.ToShortTimeString());
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
                WorkTimeEvent clockIn = new WorkTimeEvent()
                {
                    // Uses Db to return list of emails, then grabs the first (and only) user with that email.
                    User = db.Users.Where(e => e.Email == workTimeEvent.Email).First(), 
                    Start = DateTime.Now,
                    EventID = Guid.NewGuid()
                };

                db.WorkTimeEvents.Add(clockIn);
                db.SaveChanges();
                ModelState.Clear();
                ModelState.AddModelError("", "Clock in successful at " + dt.ToShortTimeString());
                return View("~/Views/Account/Login.cshtml");
            }
        }

        /* *****************************************************************************
         *                               CHECK USER DATA
         * *************************************************************************** */
        [AllowAnonymous]
        public JsonResult CheckForUserData(string userdata) // userdata comes from function UserCheck() on Login.cshtml
        {
            // Checks Db users where the UserName == the username that was inputted by the user and stores EVERYTHING about that user
            var searchData = db.Users.Where(x => x.UserName == userdata).SingleOrDefault();
            
            //if the user exists
            if (searchData != null)
            {
                // Get the number of new messages for the constructor in WorkTimeEventViewModel.cs
                int newMessages = db.Messages.Where(m => m.Recipient.Id == searchData.Id).Where(n => n.UnreadMessage == true).Count();

                // Look at the Db events, grab only events that matched the userID && had a start day with todays date
                var todaysWorkTimeEvents = db.WorkTimeEvents.Where(u => u.Id == searchData.Id).Where(e => e.Start.Day == DateTime.Today.Day).ToList();

                // Grabs Db event that doesn't have an end value and matches user ID
                var notFinishedEvent = db.WorkTimeEvents.FirstOrDefault(x => x.Id == searchData.Id && !x.End.HasValue);
                
                if (notFinishedEvent != null)
                { 
                    // UserVerification (2) means there's a start time, but no end time
                    return Json(new WorkTimeEventCreateViewModel(2, todaysWorkTimeEvents, newMessages), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    // UserVerification (1) means there's no start or end time
                    return Json(new WorkTimeEventCreateViewModel(1, todaysWorkTimeEvents, newMessages), JsonRequestBehavior.AllowGet);
                }
            
            }
            else
            {
                // UserVerification (0) means the current user is not in our Db
                return Json(new WorkTimeEventCreateViewModel(0), JsonRequestBehavior.AllowGet);
            }

        }


        // GET: WorkTimeEvent/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTimeEvent workTimeEvent = db.WorkTimeEvents.Find(id);
            if (workTimeEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "FirstName", workTimeEvent.Id);
            return View(workTimeEvent);
        }

        // POST: WorkTimeEvent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,Start,End,Note,Title,ActiveSchedule,Id")] WorkTimeEvent workTimeEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workTimeEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "FirstName", workTimeEvent.Id);
            return View(workTimeEvent);
        }

        // GET: WorkTimeEvent/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTimeEvent workTimeEvent = db.WorkTimeEvents.Find(id);
            if (workTimeEvent == null)
            {
                return HttpNotFound();
            }
            return View(workTimeEvent);
        }

        // POST: WorkTimeEvent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            WorkTimeEvent workTimeEvent = db.WorkTimeEvents.Find(id);
            db.WorkTimeEvents.Remove(workTimeEvent);
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