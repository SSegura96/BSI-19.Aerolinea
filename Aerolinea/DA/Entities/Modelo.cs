using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aerolinea.DA.Entities
{
    public class Modelo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModeloID { set; get; }
        public string Nombre { set; get; }
        public int Capacidad { set; get; }

        public virtual ICollection <Avion> Aviones { set; get; }
        public virtual ICollection <Asiento> Asientos { set; get; }
        
    }
}