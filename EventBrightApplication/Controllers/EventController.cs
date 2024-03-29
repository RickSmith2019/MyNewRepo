﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventBrightApplication.Models;

namespace EventBrightApplication.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private EventBrightApplicationDB db = new EventBrightApplicationDB();

        [AllowAnonymous]
        // GET: Event
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        [AllowAnonymous]
        // GET: Event/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            ViewBag.EventType= new SelectList(db.EventTypes, "TypeId", "TypeName");

            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "EventId,TypeName,Title,Description,StartDate,StartTime,EndDate,EndTime,Location,OrganizerName,OrganizerInfo,MaxTickets,AvailableTickets,City,State")] Event @event)
        public ActionResult Create(Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }

            ViewBag.EventType = new SelectList(db.EventTypes, "TypeId", "TypeName", @event.TypeId);
            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,Title,Description,StartDate,StartTime,EndDate,EndTime,Location,OrganizerName,OrganizerInfo,MaxTickets,AvailableTickets,City,State")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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

        [AllowAnonymous]
        public ActionResult Search()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Find(string type, string location)
        {
            var events = GetEvents(type, location);
            if (events == null)
            {
                return PartialView("_NoResult", events);
            }
            return PartialView("_Find", events);
        }

        [AllowAnonymous]
        private List<Event> GetEvents(string searchtype, string searchlocation)
        { 
            return db.Events
                .Where(e => e.Title.Contains(searchtype)
                        || e.TypeName.TypeName.Contains(searchtype)
                        || searchtype == null
                        || searchtype == "Event or Event Type"
                        && e.City.Contains(searchlocation)
                        || e.Location.Contains(searchlocation)
                        || e.State.Contains(searchlocation)
                        || searchlocation == null
                        || searchlocation == "Location, City, or State")
                        .OrderBy(e => e.StartDate)
                        .ToList();
        }        
    }
}
