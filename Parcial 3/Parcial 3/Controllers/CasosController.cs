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
    public class CasosController : Controller
    {
        private JDbContext db = new JDbContext();

        // GET: Casos
        public ActionResult Index()
        {
            var casos = db.Casos.Include(c => c.AbogadoAsignado);
            return View(casos.ToList());
        }

        // GET: Casos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caso caso = db.Casos.Find(id);
            if (caso == null)
            {
                return HttpNotFound();
            }
            return View(caso);
        }

        // GET: Casos/Create
        public ActionResult Create()
        {
            ViewBag.AbogadoAsignadoID = new SelectList(db.Abogados, "AbogadoID", "Nombre");
            return View();
        }

        // POST: Casos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CasoID,CodigoCaso,Titulo,Descripcion,FechaInicio,FechaVencimiento,EstadoCaso,Prioridad,AbogadoAsignadoID")] Caso caso)
        {
            if (ModelState.IsValid)
            {
                db.Casos.Add(caso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AbogadoAsignadoID = new SelectList(db.Abogados, "AbogadoID", "Nombre", caso.AbogadoAsignadoID);
            return View(caso);
        }

        // GET: Casos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caso caso = db.Casos.Find(id);
            if (caso == null)
            {
                return HttpNotFound();
            }
            ViewBag.AbogadoAsignadoID = new SelectList(db.Abogados, "AbogadoID", "Nombre", caso.AbogadoAsignadoID);
            return View(caso);
        }

        // POST: Casos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CasoID,CodigoCaso,Titulo,Descripcion,FechaInicio,FechaVencimiento,EstadoCaso,Prioridad,AbogadoAsignadoID")] Caso caso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AbogadoAsignadoID = new SelectList(db.Abogados, "AbogadoID", "Nombre", caso.AbogadoAsignadoID);
            return View(caso);
        }

        // GET: Casos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caso caso = db.Casos.Find(id);
            if (caso == null)
            {
                return HttpNotFound();
            }
            return View(caso);
        }

        // POST: Casos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Caso caso = db.Casos.Find(id);
            db.Casos.Remove(caso);
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
