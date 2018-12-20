using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aerolinea.Models
{
    public class RegistrarReservaViewModel
    {
        public List<SelectListItem> listaItemsVuelos { set; get; }
        public List<SelectListItem> listaItemsPasajeros { set; get; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Codigo")]
        public string Codigo { set; get; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Vuelo")]
        public int Vuelo { set; get; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name ="Pasajero")]
        public int Pasajero { set; get; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name ="Estado")]
        public string Estado { set; get; }
    }
}