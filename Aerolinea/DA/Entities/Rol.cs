using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aerolinea.DA.Entities
{
    public class Rol
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RolID { set; get; }
        public string Nombre { set; get; }

        public virtual Usuario Usuario { set; get; }
    }
}