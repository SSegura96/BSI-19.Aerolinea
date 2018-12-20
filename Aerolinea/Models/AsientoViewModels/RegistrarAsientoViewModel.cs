using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aerolinea.Models.AdministrarViewModels
{
    public class RegistrarAsientoViewModel
    {
        [Required]
        [Display(Name = "Codigo del Asiento")]
        public string CodigoAsiento { get; set; }
        [Required]
        [Display(Name = "Clase")]
        public string Clase { get; set; }
        [Required]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }
        public int modeloId { get; set; }
        [Display(Name = "Modelo del Avion")]
        public List<SelectListItem> ListaModelos { get; set; }
    }
}