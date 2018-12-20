using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aerolinea.DA.Entities
{
    public class Asiento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AsientoID { set; get; }
        /*LETRA-NUMERO_CONSECUTIVO*/
        public string CodigoAsiento { set; get; }
        /*VIP - ESTANDAR - ECONOMICO*/
        public string Clase { set; get; }
        /*VENTANA - CENTRO - PASILLO*/
        public string Tipo { set; get; }

        public virtual Modelo Modelo { set; get; }
    }
}