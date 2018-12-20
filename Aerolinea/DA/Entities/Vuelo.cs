using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aerolinea.DA.Entities
{
    public class Vuelo
    {
            /*PARA LAS FECHAS*/
        //https://msdn.microsoft.com/en-us/library/ms186724.aspx

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VueloID { set; get; }
        public string Codigo { set; get; }
        public DateTime HoraFechaLlegada { set; get; }//en sql server "date" YYYY-MM-DD
        public DateTime HoraFechaSalida { set; get; }//en sql server "time" hh:mm:ss
        public string Estado { set; get; }//abierto - cerrado
        public int Cupo { set; get; }//se copia la capacidad del avion y se disminuye segun el numero de reservas

        public virtual Aeropuerto AeropuertoLlegada { set; get; }
        public virtual Aeropuerto AeropuertoSalida { set; get; }
        public virtual Avion Avion { set; get; }
    }
}