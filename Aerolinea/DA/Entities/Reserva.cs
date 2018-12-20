using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aerolinea.DA.Entities
{
    public class Reserva
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservaID { set; get; }
        public int Precio { set; get; } //US Dollar
        public string Estado { set; get; } //Reservado - Cancelar

        public virtual Usuario Usuario { set; get; }
        public virtual Vuelo Vuelo { set; get; }
    }
}