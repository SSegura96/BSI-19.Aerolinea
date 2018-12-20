using Aerolinea.DA;
using Aerolinea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aerolinea.DA.Entities;
using Aerolinea.Models.MostrarViewModels;

namespace Aerolinea.Controllers
{
    public class VueloController : Controller
    {
        private AerolineaContext db = new AerolineaContext();
        private Logic log = new Logic();

        #region get methods

        public ActionResult RegistrarVuelo()
        {
            var model = new RegistrarVueloViewModel();
            var LocalListAvi = new List<SelectListItem>();
            var LocalListPais = new List<SelectListItem>();

            model.Codigo = log.GenerarCodigo(3);

            var Aviones = db.avion.ToList();
            foreach (var avion in Aviones)
            {
                LocalListAvi.Add(new SelectListItem() { Value = avion.AvionID.ToString(), Text = avion.Modelo.ToString() });
            }

            var Paises = db.pais.ToList();
            foreach (var pais in Paises)
            {
                LocalListPais.Add(new SelectListItem() { Value = pais.PaisID.ToString(), Text = pais.Nombre });
            }

            model.listaItemsAviones = LocalListAvi;
            model.listaItemsPaises = LocalListPais;
            return View(model);
        }

        public ActionResult EliminarVuelo(int id)
        {
            var Vuelo = db.vuelo.SingleOrDefault(x => x.VueloID == id);
            db.vuelo.Attach(Vuelo);
            db.vuelo.Remove(Vuelo);
            db.SaveChanges();
            return RedirectToAction("MostrarVuelos");
        }

        public ActionResult ActualizarVuelo(int id)
        {
            var Vuelo = db.vuelo.SingleOrDefault(x => x.VueloID == id);

            var model = new RegistrarVueloViewModel();
            var LocalListAvi = new List<SelectListItem>();
            var LocalListPais = new List<SelectListItem>();

            //model.Codigo = Vuelo.Codigo;
            //model.Fecha = Vuelo.Fecha;
            model.Cupo = Vuelo.Cupo;
            model.HoraLlegada = Vuelo.HoraLlegada;
            model.HoraSalida = Vuelo.HoraSalida;

            var Aviones = db.avion.ToList();
            foreach (var avion in Aviones)
            {
                LocalListAvi.Add(new SelectListItem() { Value = avion.AvionID.ToString(), Text = avion.Modelo.ToString() });
            }

            var Paises = db.pais.ToList();
            foreach (var pais in Paises)
            {
                LocalListPais.Add(new SelectListItem() { Value = pais.PaisID.ToString(), Text = pais.Nombre });
            }

            model.listaItemsAviones = LocalListAvi;
            model.listaItemsPaises = LocalListPais;
            return View(model);
        }

        public ActionResult MostrarVuelos()
        {
            var model = new MostrarVuelosViewModel();
            model.ListVuelos = db.vuelo.ToList();
            return View(model);
        }

        #endregion

        #region post methods 

        [HttpPost]
        public ActionResult RegistrarVuelo(RegistrarVueloViewModel model)
        {
            //var Avion = db.avion.SingleOrDefault(avion => avion.AvionID == model.Avion);
            //var Destino = db.pais.SingleOrDefault(pais => pais.PaisID == model.Destino);
            //var Cupo = Avion.Capacidad;

            var Vuelo = new Vuelo
            {
                Codigo = model.Codigo,
                Destino = Destino,
                Fecha = model.Fecha,
                HoraSalida = model.HoraSalida,
                HoraLlegada = model.HoraLlegada,
                Avion = Avion,
                Cupo = Cupo
            };
            db.vuelo.Add(Vuelo);
            db.SaveChanges();
            return RedirectToAction("MostrarVuelos");
        }

        [HttpPost]
        public ActionResult ActualizarVuelo(RegistrarVueloViewModel model)
        {
            //var Avion = db.avion.SingleOrDefault(x => x.AvionID == model.Avion);
            //var Destino = db.pais.SingleOrDefault(x => x.PaisID == model.Destino);
            //var Vuelo = db.vuelo.SingleOrDefault(x => x.Codigo == model.Codigo);

            //Vuelo.Codigo = model.Codigo;
            //Vuelo.Fecha = model.Fecha;
            //Vuelo.HoraLlegada = model.HoraLlegada;
            //Vuelo.HoraSalida = model.HoraSalida;
            //Vuelo.Cupo = model.Cupo;
            //Vuelo.Avion = Avion;
            //Vuelo.Destino = Destino;
            //db.Entry(Vuelo).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            return RedirectToAction("MostrarVuelos");
        }

        #endregion

    }
}