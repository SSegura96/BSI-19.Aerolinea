using Aerolinea.Controllers;
using Aerolinea.DA;
using Aerolinea.Models.MostrarViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Aerolinea.DA.Entities;

namespace Aerolinea.Models
{
    public class Logic
    {
        private AerolineaContext db = new AerolineaContext();

        public int GenerarNSerie(int size)
        {
            Random rnd = new Random();
            int i = 0;
            int num = 0;
            string temp = "";
            while (i < size)
            {
                temp += rnd.Next(1, 9);
                i++;
            }
            num = int.Parse(temp);
            return num;
        }

        public string GenerarCodigo(int size)
        {
            Random rnd = new Random();
            string posibles = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int longitud = posibles.Length;
            char letra;
            string codigo = "";
            for (int i = 0; i < size; i++)
            {
                letra = posibles[rnd.Next(longitud)];
                codigo += letra.ToString();
            }
            codigo += GenerarNSerie(size);
            return codigo;
        }

        public string generarNombre(int size)
        {
            Random rnd = new Random();
            string posibles = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int longitud = posibles.Length;
            char letra;
            string palabra = "";
            for (int i = 0; i < size; i++)
            {
                if (i == 7 || i == 14)
                {
                    palabra += " ";
                }

                letra = posibles[rnd.Next(longitud)];
                palabra += letra.ToString();
            }
            return palabra;
        }

        public MostrarAvionesViewModel LlenarModelAviones()
        {
            var model = new MostrarAvionesViewModel();
            model.listAvi = db.avion.ToList();
            return model;
        }

        public MostrarVuelosViewModel LlenarModelVuelos()
        {
            var model = new MostrarVuelosViewModel();
            model.ListVuelos = db.vuelo.ToList();
            return model;
        }

        public MostrarReservasViewModel LlenarModelReservas()
        {
            var model = new MostrarReservasViewModel();
            model.ListReservas = db.reserva.ToList();
            return model;
        }

        public MostrarUsuariosViewModel LlenarModelUsuarios()
        {
            var model = new MostrarUsuariosViewModel();
            model.listUsers = db.usuario.ToList();
            return model;
        }

        /**
         * 1) Administrador del sistema
         * 2) Administrador aerolinea
         * 3) Agente aerolinea
         * 4) Agente estandar
         */
        public string ObtenerLayout(int rol)
        {
            string Layout = "~/Views/Shared/";
            switch (rol)
            {
                default:
                    Layout += "_LayoutLogOff.cshtml";
                    break;

                case 1:
                    Layout += "_LayoutSysAdmin.cshtml";
                    break;

                case 2:
                    Layout += "_LayoutAeroAdmin.cshtml";
                    break;

                case 3:
                    Layout += "_LayoutAgente.cshtml";
                    break;

                case 4:
                    Layout += "_LayoutEstandar.cshtml";
                    break;
            }
            return Layout;
        }

        public void SetUserType(int type)
        {
            var sistema = db.sistema.SingleOrDefault(x=>x.SistemaID == 1);
            sistema.Usuario = type;
            db.Entry(sistema).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public int GetUserType()
        {
            var sistema = db.sistema.SingleOrDefault(x => x.SistemaID == 1);
            return sistema.Usuario;
        }

        public void SetDisplay(string _display)
        {
            var sistema = db.sistema.SingleOrDefault(x => x.SistemaID == 1);
            sistema.Display = _display;
            db.Entry(sistema).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public string GetDisplay()
        {
            var sistema = db.sistema.SingleOrDefault(x => x.SistemaID == 1);
            return sistema.Display;
        }

        private MailMessage mail;//correo electronico que se envia

        public void EnviarCorreo(string correo, string contrasenna)
        {

            //Se instancia la variable con el destinatoario del email

            string Asunto = "Orange Airlines - Detalles de usuario";
            //Se instancia el cuerpo del email haciendo uso del metodo "ObtenerContrasenna()"
            string Cuerpo = "Usted solicito que se le enviaran sus credenciales de usuario:\n Contraseña: " + contrasenna;

            //se instancia el email
            mail = new MailMessage();
            //Se agrega el string "Destinatario" al elemento "To" del email
            mail.To.Add(new MailAddress(correo));
            //Se agrega el string con la direccion del email del remitente al elemento "From" del email
            mail.From = new MailAddress("it.pluricode@gmail.com");
            //Se agrega el string "Asunto" al elemento "Subject" del email
            mail.Subject = Asunto;
            //Se agrega el string "Cuerpo" al elemento "Body" del email
            mail.Body = Cuerpo;
            //Se establece que cuerpo del email no es de formtado HTML
            mail.IsBodyHtml = false;

            //Se instacia un protocolo de envio simple de emails
            //Se intancia con un tipo de servidor de dominio segun corresponda el remitente y un tipo de puerto respectivamete
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            //Se ''usa'' la varible cliente
            using (client)
            {
                //Se establecen la credenciales mediante el correo de itSupport y la contreseña del mismo
                client.Credentials = new System.Net.NetworkCredential("it.pluricode@gmail.com", "cacadeperro");
                //Se usa para ofrecer seguridad mediante SSL al correo de tipo "empresarial"
                client.EnableSsl = true;
                //Se envia el email a un proceso en linea para enviar el email
                client.Send(mail);
            }//fin using

        }

        public MostrarUsuariosViewModel ObtenerListaUsuarios (int rol)
        {
            var model = new MostrarUsuariosViewModel();
            List<Usuario> temp = db.usuario.ToList();
            List<Usuario> temp2 = new List<Usuario>();
            foreach (var usuario in temp)
            {
                //if (usuario.Rol == rol)
                //{
                //    temp2.Add(usuario);
                //}
            }
            model.listUsers = temp2;
            return model;
        }

        public string ObtenerDireccionListaUsuario(int rol)
        {
            string dir = "../Mostrar/ListaUsuarios";
            string op = "";

            switch(rol)
            {
                default:
                    op = "Sys";
                break;
                    
                case 2:
                    op = "AdminAero";
                break;
                    
                case 3:
                    op = "AgenteAero";
                break;
            };
            dir += op;
            return dir;
        }

        public void SetUsuarioID (string _correo)
        {
            AerolineaContext db = new AerolineaContext();
            var Sistema = db.sistema.SingleOrDefault(x => x.SistemaID == 1);
            Sistema.NuevoUsuario = _correo;
            db.Entry(Sistema).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public int GetUsuarioID()
        {
            AerolineaContext db = new AerolineaContext();
            var Sistema = db.sistema.SingleOrDefault(x => x.SistemaID == 1);
            var user = db.usuario.SingleOrDefault(x => x.Correo == Sistema.NuevoUsuario);
            return user.UsuarioID;
        }

        public int GetPassengerID()
        {
            //AerolineaContext db = new AerolineaContext();
            //string _correo = GetDisplay();
            //var User = db.usuario.SingleOrDefault(x => x.Correo == _correo);
            //var pass = db.pasajero.SingleOrDefault(x => x.Usuario.UsuarioID == User.UsuarioID);
            //return pass.PasajeroID;
            return 0;
        }

        public string ObtenerDireccionNuevoUsuario ()
        {
            switch(GetUserType())
            {
                case 1:
                    return "RegistrarUsuarioSysAdmin";

                case 2:
                    return "RegistrarUsuarioAgenteAero";

                default:
                    return "";
            }
        }
    }
}