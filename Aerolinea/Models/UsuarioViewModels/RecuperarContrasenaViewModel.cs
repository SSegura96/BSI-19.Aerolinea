using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aerolinea.Models.UsuarioViewModels
{
    public class RecuperarContrasenaViewModel
    {
        [Required]
        [Display(Name = "Correo")]
        public string Correo { set; get; }
    }
}