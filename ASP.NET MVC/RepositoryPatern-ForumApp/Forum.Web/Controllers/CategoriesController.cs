using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Forum.Data;
using Forum.Models;
using Forum.Data.Common;
using Forum.Web.Contracts;

namespace Forum.Web.Controllers
{
    public class CategoriesController : Controller, ICategoriesController
    {
        private IRepository<Category> category;
        private IEfUnitOfWork unitOfWork;

        public CategoriesController(IRepository<Category> category, IEfUnitOfWork UnitOfWork)
        {
            this.category = category;
            this.unitOfWork = UnitOfWork;
        }
        

        // GET: Categories
        public ActionResult Index()
        {
            var categories = this.category.All;
            return View(categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = this.category.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            ViewBag.ParentCategoryId = new SelectList(this.category.All, "Id", "Name");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ParentCategoryId")] Category category)
        {
            if (ModelState.IsValid)
            {
                this.category.Add(category);
                this.unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.ParentCategoryId = new SelectList(this.category.All, "Id", "Name", category.ParentCategoryId);
            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = this.category.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentCategoryId = new SelectList(this.category.All, "Id", "Name", category.ParentCategoryId);
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ParentCategoryId")] Category category)
        {
            if (ModelState.IsValid)
            {
                this.category.Update(category);
                this.unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.ParentCategoryId = new SelectList(this.category.All, "Id", "Name", category.ParentCategoryId);
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = this.category.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = this.category.GetById(id);
            this.category.Delete(category);
            this.unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
