using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aerolinea.Models.UsuarioViewModel;
using Aerolinea.DA;
using Aerolinea.Models;
using Aerolinea.Models.HomeViewModels;
using Aerolinea.Models.UsuarioViewModels;
using Aerolinea.DA.Entities;
using Aerolinea.Models.MostrarViewModels;
using Aerolinea.Models.AdministrarViewModels;

namespace Aerolinea.Controllers
{
    public class UsuarioController : Controller
    {
        AerolineaContext db = new AerolineaContext();
        Logic lg = new Logic();

        #region get methods

        public ActionResult IniciarSesion()
        {
            var model = new IniciarSesionViewModel();
            return View(model);
        }

        //public ActionResult CerrarSesion()
        //{
        //    lg.SetUserType(0);
        //    return View("../Home/Index", new IndexViewModel());
        //}

        public ActionResult RegistrarUsuario()
        {
            var model = new RegistrarUsuarioViewModel();
            model.correo = "@";
            model.contrasena = "";
            model.rol = 0;
            return View(model);
        }

        public ActionResult ActualizarUsuario(int id)
        {
            //var Usuario = db.usuario.SingleOrDefault(x => x.UsuarioID == id);
            var model = new RegistrarUsuarioViewModel();
            //model.correo = Usuario.Correo;
            //model.contrasena = Usuario.Contrasena;
            //model.rol = 0;
            return View("RegistrarUsuario", model);
        }

        public ActionResult RegistrarUsuarioSysAdmin()
        {
            if (lg.GetUserType() != 0)
            {
                return View("RegistrarUsuario");
            }
            return RedirectToAction("../Home/Index");
        }

        public ActionResult RegistrarUsuarioAgenteAero()
        {
            if (lg.GetUserType() != 0)
            {
                return View("RegistrarUsuario");
            }
            return RedirectToAction("../Home/Index");
        }

        public ActionResult RegistrarUsuarioEstandar()
        {
           return View("RegistrarUsuario");
        }

        public ActionResult RecuperarContrasena()
        {
            return View();
        }

        public ActionResult DesactivarUsuario(int id)
        {
            //var Usuario = db.usuario.SingleOrDefault(x => x.UsuarioID == id);
            //Usuario.Estado = 0;
            //db.Entry(Usuario).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            //return RedirectToAction(lg.ObtenerDireccionListaUsuario(Usuario.Rol));
            return View();
        }

        public ActionResult ActivarUsuario(int id)
        {
            //var Usuario = db.usuario.SingleOrDefault(x => x.UsuarioID == id);
            //Usuario.Estado = 1;
            //db.Entry(Usuario).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            //return RedirectToAction(lg.ObtenerDireccionListaUsuario(Usuario.Rol));
            return View();
        }

        public ActionResult ListaUsuariosSys()
        {
            var model = new MostrarUsuariosViewModel();
            model.listUsers = db.usuario.ToList();
            return View("ListaUsuarios", model);
        }

        public ActionResult ListaUsuariosAdminAero()
        {
            return View("ListaUsuarios", lg.ObtenerListaUsuarios(2));
        }

        public ActionResult ListaUsuariosAgenteAero()
        {
            return View("ListaUsuarios", lg.ObtenerListaUsuarios(3));
        }


        #endregion

        #region post methods

        //[HttpPost]
        //public ActionResult IniciarSesion(IniciarSesionViewModel model)
        //{
        //    var User = db.usuario.SingleOrDefault(x => x.Correo == model.Correo);

        //    if (User != null && User.Estado != 0)
        //    {
        //        if (User.Correo.Equals(model.Correo) && User.Contrasena.Equals(model.Contrasena))
        //        {
        //            var Usuario = db.usuario.SingleOrDefault(x => x.Correo.Equals(model.Correo));
        //            var indexModel = new IndexViewModel();
        //            lg.SetUserType(Usuario.Rol);
        //            lg.SetDisplay(Usuario.Correo);
        //            return View("../Home/Index", indexModel);
        //        }
        //    }
        //    return View("IniciarSesion");
        //}

        [HttpPost]
        public ActionResult RecuperarContrasena(RecuperarContrasenaViewModel model)
        {
            var usuario = db.usuario.SingleOrDefault(user => user.Correo.Equals(model.Correo));
            if (usuario != null)
            {
                //lg.EnviarCorreo(model.Correo, usuario.Contrasena);
                ////mensaje de se ha enviado el correo
                //return View("../Home/Index");
            }
            return RedirectToAction("RecuperarContrasena");
            //mensaje el correo digitado no se encuentra regitrado en el sistema
        }

        [HttpPost]
        public ActionResult ActualizarUsuario(RegistrarUsuarioViewModel model)
        {
            //var Usuario = db.usuario.SingleOrDefault(x => x.Correo.Equals(model.correo));
            //Usuario.Correo = model.correo;
            //Usuario.Contrasena = model.contrasena;
            //if (lg.GetUserType() == 1)
            //{
            //    Usuario.Rol = model.rol;
            //}
            //db.Entry(Usuario).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            //return RedirectToAction(lg.ObtenerDireccionListaUsuario(Usuario.Rol));
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarUsuarioSysAdmin(RegistrarUsuarioViewModel model)
        {
            var usuario = new Usuario
            {
                //Correo = model.correo,
                //Contrasena = model.contrasena,
                //Estado = 1,
                //Rol = model.rol
            };
            db.usuario.Add(usuario);
            db.SaveChanges();
            return RedirectToAction("RegistrarPasajero");
        }

        [HttpPost]
        public ActionResult RegistrarUsuarioAgenteAero(RegistrarUsuarioViewModel model)
        {
            var usuario = new Usuario
            {
                //Correo = model.correo,
                //Contrasena = model.contrasena,
                //Estado = 1,
                //Rol = 3
            };
            db.usuario.Add(usuario);
            db.SaveChanges();
            return RedirectToAction("RegistrarPasajero");
        }

        [HttpPost]
        public ActionResult RegistrarUsuarioEstandar(RegistrarUsuarioViewModel model)
        {
            var usuario = new Usuario
            {
                //Correo = model.correo,
                //Contrasena = model.contrasena,
                //Estado = 1,
                //Rol = 4
            };
            db.usuario.Add(usuario);
            db.SaveChanges();
            lg.SetUsuarioID(usuario.Correo);
            return RedirectToAction("RegistrarPasajero");
        }
        #endregion
    }
}