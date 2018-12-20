using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aerolinea.Models.UsuarioViewModels
{
    public class RegistrarUsuarioViewModel
    {
        [Required]
        [Display(Name = "Nombre de Usuario (email)")]
        public string correo { set; get; }
        [Required]
        [Display(Name = "Contrasena")]
        public string contrasena { set; get; }
        [Required]
        [Display(Name = "Rol del Usuario")]
        public int rol { set; get; }
    }
}