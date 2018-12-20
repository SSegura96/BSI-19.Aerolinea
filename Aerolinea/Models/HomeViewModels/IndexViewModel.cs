using Aerolinea.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aerolinea.Models.HomeViewModels
{
    public class IndexViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string Usuario { set; get; }
    }
}