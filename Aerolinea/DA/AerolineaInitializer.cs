using Aerolinea.DA.Entities;
using Aerolinea.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Aerolinea.DA
{
    public class AerolineaInitializer : DropCreateDatabaseIfModelChanges<AerolineaContext>
    {
        private Logic log = new Logic();

        protected override void Seed(AerolineaContext context)
        {
            //Se insertan registros en la tabla Pais
            var Paises = new List<Pais>
            {
                new Pais {Nombre = "Nicaragua"},
                new Pais {Nombre = "Panama"},
                new Pais {Nombre = "Colombia"},
                new Pais {Nombre = "Argentina"},
                new Pais {Nombre = "Peru"},
                new Pais {Nombre = "Canada"},
                new Pais {Nombre = "Estados Unidos"},
                new Pais {Nombre = "Mexico"},
                new Pais {Nombre = "Brasil"},
                new Pais {Nombre = "España"},
                new Pais {Nombre = "Inglaterra"},
                new Pais {Nombre = "Francia"},
                new Pais {Nombre = "Alemania"},
                new Pais {Nombre = "Holanda"},
                new Pais {Nombre = "Rusia"}
            };
            Paises.ForEach(pais => context.pais.Add(pais));

            //Se registran modelos en la tabla de modelos
            var Modelos = new List<Modelo>
            {
                new Modelo {Capacidad = 18, Nombre = "Stationair"},
                new Modelo {Capacidad =  25, Nombre = "A380-800"},
                new Modelo {Capacidad =  100, Nombre = "G650"},
                new Modelo {Capacidad =  330, Nombre = "Legacy 450"},
                new Modelo {Capacidad =  40, Nombre = "A330-300"},
                new Modelo {Capacidad =  40, Nombre = "Citation CJ4"}
            };
            Modelos.ForEach(modelo => context.modelo.Add(modelo));

            //Se registran asientos en la tabla de asientos
            var Asientos = new List<Asiento>
            {
                new Asiento {CodigoAsiento = "A-1", Clase = "VIP", Tipo = "Ventana", Modelo = Modelos[0]},
                new Asiento {CodigoAsiento = "D-2", Clase = "Estandar", Tipo = "Pasillo", Modelo = Modelos[1]},
                new Asiento {CodigoAsiento = "J-3", Clase = "Economico", Tipo = "Medio", Modelo = Modelos[2] },
                new Asiento {CodigoAsiento = "B-3", Clase = "VIP", Tipo = "Pasillo", Modelo = Modelos[3] },
                new Asiento {CodigoAsiento = "E-1", Clase = "Estandar", Tipo = "Ventana", Modelo = Modelos[4] },
                new Asiento {CodigoAsiento = "K-1", Clase = "Economico", Tipo = "Ventana", Modelo = Modelos[5] }
            };
            Asientos.ForEach(asiento => context.asiento.Add(asiento));

            //Se insertan registros en la tabla Avion
            var Aviones = new List<Avion>
            {
                new Avion {Nombre="Cessna", Modelo = Modelos[0] },
                new Avion {Nombre = "Airbus", Modelo =Modelos[1] },
                new Avion {Nombre = "Gulfstream", Modelo =Modelos[2] },
                new Avion {Nombre = "Embraer", Modelo =Modelos[3] },
                new Avion {Nombre = "Airbus", Modelo =Modelos[4] },
                new Avion {Nombre = "Cessna", Modelo =Modelos[5] }
            };
            Aviones.ForEach(avion => context.avion.Add(avion));



            //Se inisertan registros en la tabla Usuarios
            var Usuarios = new List<Usuario>
            {
                new Usuario {Nombre = "sys", Apellidos = "sys",Correo="sys",FechaNacimiento = DateTime.Parse("2016-01-01"), Contrasenna="sys", Pasaporte="G8U1J8O1L", Nacionalidad = "Informatico" },
                new Usuario {Nombre = "Sergio Luis", Apellidos = "Segura Vidal",Correo="sergio31.96@gmail.com",FechaNacimiento = DateTime.Parse("1996-08-31"), Contrasenna="rk001", Pasaporte="S3L1S9V6J", Nacionalidad = "Colombiano" },
                new Usuario {Nombre = "Javier", Apellidos = "Fernandez Alvarado",Correo="BlackSwan",FechaNacimiento = DateTime.Parse("1997-03-13"), Contrasenna="calmese", Pasaporte="J1F3A9S7J", Nacionalidad = "Español" },
                new Usuario {Nombre = "Labo", Apellidos = "Labo",Correo="labo",FechaNacimiento = DateTime.Parse("2016-01-01"), Contrasenna="labo", Pasaporte="Q9W2E5R9T", Nacionalidad = "Informatico" },
                new Usuario {Nombre = "Ji Min", Apellidos = "Shin",Correo="test",FechaNacimiento = DateTime.Parse("1991-01-08"), Contrasenna="test", Pasaporte="A8S1D8F1G", Nacionalidad = "Informatico" }
            };
            Usuarios.ForEach(usuario => context.usuario.Add(usuario));

            var Sistemas = new List<Sistema>
            {
                new Sistema {Usuario = 0}
            };
            Sistemas.ForEach(sistema => context.sistema.Add(sistema));

            context.SaveChanges();

            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var user = new ApplicationUser { UserName = "RKoch3196" };
            manager.Create(user, "Rk$001");
        }
    }
}