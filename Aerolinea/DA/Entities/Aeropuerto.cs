using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aerolinea.DA.Entities
{
    public class Aeropuerto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AeropuertoID { set; get; }
        public string Nombre { set; get; }
    }
}