using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aerolinea.DA.Entities
{
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioID { set; get; }
        public string Nombre { set; get; }
        public string Apellidos { set; get; }
        public string Correo { set; get; }
        public DateTime FechaNacimiento { set; get; }//en sql server "date" YYYY-MM-DD
        public string Contrasenna { set; get; }
        public string Pasaporte { set; get; }
        public string Nacionalidad { set; get; }
        /*
            1 == activado
            0 == desactivado
         */
        public int Estado { set; get; }

        public virtual Rol Rol { set; get; }
        public virtual Aerolinea Aerolinea { set; get; }
    }
}