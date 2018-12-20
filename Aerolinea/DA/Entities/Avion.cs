using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aerolinea.DA.Entities
{
    public class Avion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AvionID { set; get; }
        public string Nombre { set; get; }
        
        public virtual Aerolinea Aerolinea { set; get; } 
        public virtual Modelo Modelo { set; get; }
    }
}