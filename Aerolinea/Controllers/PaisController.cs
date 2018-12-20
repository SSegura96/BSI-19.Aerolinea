using Aerolinea.DA;
using Aerolinea.DA.Entities;
using Aerolinea.Models.PaisViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aerolinea.Controllers
{
    public class PaisController : Controller
    {
        private AerolineaContext db = new AerolineaContext();

        #region Get Methods
        
        public ActionResult RegistrarPais()
        {
            return View();
        }

        public ActionResult MostrarPaises()
        {
            var model = new MostrarPaisesViewModel();
            model.listaPaises = db.pais.ToList();
            return View(model);
        }

        public ActionResult ActualizarPais(int id)
        {
            var model = new RegistrarPaisViewModel();
            var modelView = db.pais.SingleOrDefault(x => x.PaisID == id);
            model.Nombre = modelView.Nombre;
            model.PaisID = id;//OJO
            return View(model);
        }

        public ActionResult EliminarPais(int id)
        {
            var pais = db.pais.SingleOrDefault(x => x.PaisID == id);
            db.pais.Attach(pais);
            db.pais.Remove(pais);
            db.SaveChanges();
            return RedirectToAction("MostrarPaises");
        }

        #endregion


        #region Post Methods

        [HttpPost]
        public ActionResult RegistrarPais(RegistrarPaisViewModel model)
        {
            var pais = new Pais
            {
                Nombre = model.Nombre
            };
            db.pais.Add(pais);
            db.SaveChanges();
            return RedirectToAction("MostrarPaises");
        }

        public ActionResult ActualizarPais(RegistrarPaisViewModel model)
        {
            var pais = db.pais.SingleOrDefault(x => x.PaisID == model.PaisID);
            pais.Nombre = model.Nombre;
            db.Entry(pais).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("MostrarPaises");
        }

        #endregion
    }
}