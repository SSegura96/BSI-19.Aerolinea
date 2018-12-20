using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aerolinea.DA.Entities
{
    public class Sistema
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SistemaID { set; get; }
        public int Usuario { set; get; }
        public string Display { set; get; }
        public string NuevoUsuario { set; get; }
    }
}