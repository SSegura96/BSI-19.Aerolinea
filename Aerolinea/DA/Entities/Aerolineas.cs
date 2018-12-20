using Aerolinea.DA.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aerolinea.DA
{
    public class Aerolineas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AerolineasID { set; get; }
        public string Nombre { set; get; }

        public virtual Pais Pais { set; get; }
        public virtual ICollection <Avion> Aviones { set; get; }
        public virtual ICollection <Usuario> Usuarios { set; get; }
        public virtual ICollection <Vuelo> Vuelos { set; get; }
    }
}