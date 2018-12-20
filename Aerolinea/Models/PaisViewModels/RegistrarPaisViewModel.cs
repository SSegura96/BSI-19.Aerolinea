using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aerolinea.Models.PaisViewModels
{
    public class RegistrarPaisViewModel
    {
        [Required(ErrorMessage ="Campo requerido.")]
        [Display(Name = "Nombre del Pais")]
        public string Nombre { set; get; }
        /*Para actualizar NADA MAS*/
        public int PaisID { set; get; }
    }
}