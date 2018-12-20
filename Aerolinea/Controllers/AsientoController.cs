using Aerolinea.DA;
using Aerolinea.DA.Entities;
using Aerolinea.Models;
using Aerolinea.Models.AdministrarViewModels;
using Aerolinea.Models.MostrarViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aerolinea.Controllers
{
    public class AsientoController : Controller
    {
        private AerolineaContext db = new AerolineaContext();
        private Logic log = new Logic();

        #region get methods

        public ActionResult RegistrarAsiento()
        {
            var model = new RegistrarAsientoViewModel();
            var lista = new List<SelectListItem>();
            var aviones = db.avion.ToList();
            foreach (var avion in aviones)
            {
                lista.Add(new SelectListItem() { Value = avion.AvionID.ToString(), Text = avion.Modelo.ToString() });
            }
            model.ListaItems = lista;
            return View(model);
        }

        public ActionResult EliminarAsiento(int id)
        {
            var Asiento = db.asiento.SingleOrDefault(asiento => asiento.AsientoID == id);
            db.asiento.Attach(Asiento);
            db.asiento.Remove(Asiento);
            db.SaveChanges();
            return RedirectToAction("MostrarAsientos");
        }

        public ActionResult MostrarAsientos (int id)
        {
            var model = new MostrarAsientosViewModel();
            model.avion = db.avion.SingleOrDefault(avion => avion.AvionID == id);
            return View(model);
        }

        #endregion

        #region post methods

        [HttpPost]
        public ActionResult RegistrarAsiento(RegistrarAsientoViewModel model)
        {
            return RedirectToAction("MostrarAsientos");
        }

        #endregion

    }
}