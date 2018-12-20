using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aerolinea.Models
{
    public class RegistrarAvionViewModel : Logic
    {
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Numero de Serie")]
        public int NumSerie { set; get; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name ="Nombre/Modelo")]
        public string Modelo { set; get; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name ="Capacidad")]
        public int Capacidad { set; get; }
    }
}