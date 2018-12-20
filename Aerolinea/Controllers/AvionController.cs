using Aerolinea.DA;
using Aerolinea.DA.Entities;
using Aerolinea.Models;
using Aerolinea.Models.MostrarViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aerolinea.Controllers
{
    public class AvionController : Controller
    {
        private AerolineaContext db = new AerolineaContext();
        Logic lg = new Logic();
        
        #region get methods

        public ActionResult RegistrarAvion()
        {
            var model = new RegistrarAvionViewModel();
            model.NumSerie = lg.GenerarNSerie(9);
            return View(model);
        }

        public ActionResult EliminarAvion(int id)
        {
            var Avion = db.avion.SingleOrDefault(x => x.AvionID == id);
            db.avion.Attach(Avion);
            db.avion.Remove(Avion);
            db.SaveChanges();
            return RedirectToAction("MostrarAviones");
        }

        public ActionResult ActualizarAvion(int id)
        {
            var model = new RegistrarAvionViewModel();
            //var modelActu = db.avion.SingleOrDefault(x => x.AvionID == id);
            //model.NumSerie = modelActu.NumSerie;
            //model.Modelo = modelActu.Modelo;
            //model.Capacidad = modelActu.Capacidad;
            return View(model);
        }

        public ActionResult MostrarAviones()
        {
            var model = new MostrarAvionesViewModel();
            model.listAvi = db.avion.ToList();
            return View(model);
        }

        #endregion

        #region post methods

        [HttpPost]
        public ActionResult RegistrarAvion(RegistrarAvionViewModel model)
        {
            //var avion = new Avion
            //{
            //    NumSerie = model.NumSerie,
            //    Modelo = model.Modelo,
            //    Capacidad = model.Capacidad
            //};
            //db.avion.Add(avion);
            //db.SaveChanges();
            return RedirectToAction("MostrarAviones");
        }

        [HttpPost]
        public ActionResult ActualizarAvion(RegistrarAvionViewModel model)
        {
            //var Avion = db.avion.SingleOrDefault(x => x.NumSerie == model.NumSerie);
            //Avion.Modelo = model.Modelo;
            //Avion.NumSerie = model.NumSerie;
            //Avion.Capacidad = model.Capacidad;
            //db.Entry(Avion).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            return RedirectToAction("MostrarAviones");
        }

        #endregion
    }
}