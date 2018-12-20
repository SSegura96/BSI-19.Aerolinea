using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aerolinea.Models.AerolineasViewModels
{
    public class RegistrarAerolineasViewModel
    {
        [Required]
        [Display(Name = "Nombre:")]
        public string Nombre { set; get; }
        public int paisId { set; get; }
        [Display(Name ="Pais")]
        public List<SelectListItem> ListaPaises { set; get; }
        /*SOLO PAR ACTUALIZAR*/
        public int AerolineasID { set; get; }
    }
}