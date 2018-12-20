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
    public class ReservaController : Controller
    {
        private AerolineaContext db = new AerolineaContext();
        private Logic log = new Logic();

        #region get methods

        public ActionResult RegistrarReserva()
        {
            var model = new RegistrarReservaViewModel();
            var LocalListVuelos = new List<SelectListItem>();
            var LocalListPasajeros = new List<SelectListItem>();

            model.Codigo = log.GenerarCodigo(4);

            var Vuelos = db.vuelo.ToList();
            foreach (var vuelo in Vuelos)
            {
                //LocalListVuelos.Add(new SelectListItem { Value = vuelo.VueloID.ToString(), Text = vuelo.Codigo + "//" + vuelo.Destino.Nombre + "//" + vuelo.Fecha });
            }
            model.listaItemsVuelos = LocalListVuelos;

            //var Pasajeros = db.pasajero.ToList();
            //foreach (var pasajero in Pasajeros)
            //{
            //    LocalListPasajeros.Add(new SelectListItem { Value = pasajero.PasajeroID.ToString(), Text = pasajero.NumeroPasaporte + "//" + pasajero.Nombre });
            //}
            //model.listaItemsPasajeros = LocalListPasajeros;

            return View(model);
        }

        public ActionResult EliminarReserva(int id)
        {
            var Reserva = db.reserva.SingleOrDefault(x => x.ReservaID == id);
            db.reserva.Attach(Reserva);
            db.reserva.Remove(Reserva);
            db.SaveChanges();
            return RedirectToAction("MostrarReservas");
        }

        public ActionResult ActualizarReserva(int id)
        {
            var Reserva = db.reserva.SingleOrDefault(x => x.ReservaID == id);

            var model = new RegistrarReservaViewModel();
            //var LocalListVuelos = new List<SelectListItem>();
            //var LocalListPasajeros = new List<SelectListItem>();

            //model.Codigo = Reserva.Codigo;
            //model.Estado = Reserva.Estado;

            //var Vuelos = db.vuelo.ToList();
            //foreach (var vuelo in Vuelos)
            //{
            //    LocalListVuelos.Add(new SelectListItem { Value = vuelo.VueloID.ToString(), Text = vuelo.Codigo + "//" + vuelo.Destino.Nombre + "//" + vuelo.Fecha });
            //}
            //model.listaItemsVuelos = LocalListVuelos;

            //var Pasajeros = db.pasajero.ToList();
            //foreach (var pasajero in Pasajeros)
            //{
            //    LocalListPasajeros.Add(new SelectListItem { Value = pasajero.PasajeroID.ToString(), Text = pasajero.NumeroPasaporte + "//" + pasajero.Nombre });
            //}
            //model.listaItemsPasajeros = LocalListPasajeros;

            return View(model);
        }

        public ActionResult MostrarReservas()
        {
            var model = new MostrarReservasViewModel();
            //string display = log.GetDisplay();
            //var usuario = db.usuario.SingleOrDefault(x => x.Correo == display);
            //var pasajero = db.pasajero.SingleOrDefault(x => x.Usuario.UsuarioID == usuario.UsuarioID);
            //var ListaReservas = db.reserva.ToList();
            //if (log.GetUserType() == 4)
            //{
            //    var ListaTemp = new List<Reserva>();

            //    foreach (var reserva in ListaReservas)
            //    {
            //        if (reserva.Pasajero.PasajeroID == pasajero.PasajeroID)
            //        {
            //            ListaTemp.Add(reserva);
            //        }
            //    }
            //    ListaReservas = ListaTemp;
            //}

            //model.ListReservas = ListaReservas;

            return View(model);
        }

        #endregion

        #region post methods

        [HttpPost]
        public ActionResult RegistrarReserva(RegistrarReservaViewModel model)
        {
            var Vuelo = db.vuelo.SingleOrDefault(x => x.VueloID == model.Vuelo);
            //var Pasajero = new Pasajero();
            //if (log.GetUserType() != 4)
            //{
            //    Pasajero = db.pasajero.SingleOrDefault(x => x.PasajeroID == model.Pasajero);
            //}
            //else
            //{
            //    string display = log.GetDisplay();
            //    var Usuario = db.usuario.SingleOrDefault(x => x.Correo == display);
            //    Pasajero = db.pasajero.SingleOrDefault(x => x.Usuario.UsuarioID == Usuario.UsuarioID);
            //}

            ////se elimino un cupo en el vuelo
            //Vuelo.Cupo = Vuelo.Cupo - 1;

            //var Reserva = new Reserva()
            //{
            //    Codigo = log.GenerarCodigo(4),
            //    Vuelo = Vuelo,
            //    Pasajero = Pasajero,
            //    Estado = model.Estado
            //};
            //db.reserva.Add(Reserva);
            //db.Entry(Vuelo).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            return RedirectToAction("MostrarReservas");
        }

        [HttpPost]
        public ActionResult ActualizarReserva(RegistrarReservaViewModel model)
        {
            //var Reserva = db.reserva.SingleOrDefault(x => x.Codigo == model.Codigo);
            //var Vuelo = db.vuelo.SingleOrDefault(x => x.VueloID == model.Vuelo);
            //var Pasajero = db.pasajero.SingleOrDefault(x => x.PasajeroID == model.Pasajero);

            //Reserva.Codigo = model.Codigo;
            //Reserva.Estado = model.Estado;
            //db.Entry(Reserva).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            return RedirectToAction("MostrarReservas");
        }

        #endregion
    }
}