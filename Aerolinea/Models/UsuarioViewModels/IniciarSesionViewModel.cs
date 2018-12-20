using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aerolinea.Models.UsuarioViewModel
{
    public class IniciarSesionViewModel
    {
        [Required]
        [Display(Name = "Correo")]
        public string Correo { set; get; }
        [Required]
        [Display(Name = "Contraseña")]
        public string Contrasena { set; get; }
    }
}