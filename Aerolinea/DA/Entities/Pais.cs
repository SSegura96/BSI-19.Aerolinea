using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aerolinea.DA.Entities
{
    public class Pais
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaisID { set; get; }
        public string Nombre { set; get; }

        public virtual ICollection <Aerolinea> Aerolineas { set; get; }
    }
}