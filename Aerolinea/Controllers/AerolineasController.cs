using Aerolinea.DA;
using Aerolinea.Models.AerolineasViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aerolinea.Controllers
{
    public class AerolineasController : Controller
    {
        public AerolineaContext db = new AerolineaContext();

        #region Get Methods

        public ActionResult RegistrarAerolineas()
        {
            return View();
        }

        public ActionResult MostrarAerolineas()
        {
            var model = new MostrarAerolineasViewModel();
            model.ListaAerolineas = db.aerolineas.ToList();
            return View(model);
        }

        public ActionResult ActualizarAerolineas(int id)
        {
            var model = new RegistrarAerolineasViewModel();
            var modelView = db.aerolineas.SingleOrDefault(x => x.AerolineasID == id);
            model.Nombre = modelView.Nombre;
            model.paisId = modelView.Pais.PaisID;
        }

        #endregion
    }
}