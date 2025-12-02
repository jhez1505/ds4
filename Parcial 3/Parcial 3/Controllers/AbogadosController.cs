using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Parcial_3.DAL;
using Parcial_3.Models;

namespace Parcial_3.Controllers
{
    public class AbogadosController : Controller
    {
        private JDbContext db = new JDbContext();

        // GET: Abogadoes
        public ActionResult Index()
        {
            return View(db.Abogados.ToList());
        }

        // GET: Abogadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abogado abogado = db.Abogados.Find(id);
            if (abogado == null)
            {
                return HttpNotFound();
            }
            return View(abogado);
        }

        // GET: Abogadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Abogadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AbogadoID,Nombre,Apellido,Especialidad,Telefono,Email,EsActivo")] Abogado abogado)
        {
            if (ModelState.IsValid)
            {
                db.Abogados.Add(abogado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(abogado);
        }

        // GET: Abogadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abogado abogado = db.Abogados.Find(id);
            if (abogado == null)
            {
                return HttpNotFound();
            }
            return View(abogado);
        }

        // POST: Abogadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AbogadoID,Nombre,Apellido,Especialidad,Telefono,Email,EsActivo")] Abogado abogado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abogado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(abogado);
        }

        // GET: Abogadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abogado abogado = db.Abogados.Find(id);
            if (abogado == null)
            {
                return HttpNotFound();
            }
            return View(abogado);
        }

        // POST: Abogadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Abogado abogado = db.Abogados.Find(id);
            db.Abogados.Remove(abogado);
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
