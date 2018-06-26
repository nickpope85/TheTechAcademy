using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScheduleUsers.Models;
using ScheduleUsers.ViewModels;

namespace ScheduleUsers.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // Builds the Unread and Read Messages
        // GET: Message
        public ActionResult Index()
        {
            var unreadMessages = db.Messages.Where(m => m.UnreadMessage == true).OrderByDescending(x => x.DateSent);
            var readMessages = db.Messages.Where(m => m.UnreadMessage == false).OrderByDescending(x => x.DateSent);
            MessageViewModel messageViewModel = new MessageViewModel(unreadMessages, readMessages); //calls constructor in MessageViewModel
            return View(messageViewModel);
        }

        // GET: Message/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message.UnreadMessage == true)
            {
                message.UnreadMessage = false;

                if (message.DateRead != null)
                {
                    return View(message);
                }
                else
                {
                    message.DateRead = DateTime.Now;
                }
                db.SaveChanges();
            }

            if (message == null)
            {
                return HttpNotFound();
            }



            return View(message);
        }

        // POST: Message/Details/5
        [HttpPost]
        public ActionResult UpdateUnreadMessage(bool check, Guid? id)
        {
            Message message = db.Messages.Find(id);
            if (check == true)
            {
                message.UnreadMessage = true;
            }
            else
            {
                message.UnreadMessage = false;
            }
            db.SaveChanges();
            return Content("Successful Update");
        }

        //// GET: Message/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Message/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MessageID,DateSent,DateRead,MessageTitle,UnreadMessage")] Message message)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        message.MessageID = Guid.NewGuid();
        //        db.Messages.Add(message);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(message);
        //}

        // GET: Message/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Message/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageID,DateSent,DateRead,MessageTitle,UnreadMessage")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: Message/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            db.SaveChanges();
            return View(message);
        }

        // POST: Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //// GET: Message/Read Messsages Partial
        //public ActionResult ReadMessage()
        //{
        //    var readMessage = db.Messages.ToList().Where(m => m.UnreadMessage == false).OrderByDescending(x => x.DateSent);
        //    return PartialView("_ReadMessage", readMessage);
        //}


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
