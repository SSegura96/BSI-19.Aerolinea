using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aerolinea.Models
{
    public class RegistrarVueloViewModel
    {
        public List<SelectListItem> listaItemsAviones { set; get; }
        public List<SelectListItem> listaItemsAeropuertos { set; get; }

        [Required]
        [Display(Name = "Codigo")]
        public string Codigo { set; get; }

        [Display(Name = "Hora/fecha llegada")]
        public DateTime HoraFechaLlegada { set; get; }

        [Required]
        [Display(Name = "Hora/fecha salida")]
        public DateTime HoraFechaSalida { set; get; }

        [Required]
        [Display(Name = "Aeropuerto de salida")]
        public int AeropuertoSalida { set; get; }

        [Required]
        [Display(Name = "Aeropuerto de llegada")]
        public int AeropuertoLlegada { set; get; }

        [Required]
        [Display(Name = "Avion")]
        public int Avion { set; get; }
    }
}