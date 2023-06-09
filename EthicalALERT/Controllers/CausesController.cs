﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EthicalALERT.Models;

namespace EthicalALERT.Controllers
{
    public class CausesController : Controller
    {
        private CauseDBEntities2 db = new CauseDBEntities2();

        // GET: Causes
        public async Task<ActionResult> Index()
        {
            return View(await db.Causes.ToListAsync());
        }

        // GET: Causes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cause cause = await db.Causes.FindAsync(id);
            if (cause == null)
            {
                return HttpNotFound();
            }
            return View(cause);
        }

        // GET: Causes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Causes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,SignatureCount")] Cause cause)
        {
            if (ModelState.IsValid)
            {
                db.Causes.Add(cause);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cause);
        }

        // GET: Causes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cause cause = await db.Causes.FindAsync(id);
            if (cause == null)
            {
                return HttpNotFound();
            }
            return View(cause);
        }

        // POST: Causes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,SignatureCount")] Cause cause)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cause).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cause);
        }

        // GET: Causes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cause cause = await db.Causes.FindAsync(id);
            if (cause == null)
            {
                return HttpNotFound();
            }
            return View(cause);
        }

        // POST: Causes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cause cause = await db.Causes.FindAsync(id);
            db.Causes.Remove(cause);
            await db.SaveChangesAsync();
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
