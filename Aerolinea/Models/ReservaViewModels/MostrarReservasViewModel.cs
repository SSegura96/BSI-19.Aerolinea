using Aerolinea.DA.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aerolinea.Models.MostrarViewModels
{
    public class MostrarReservasViewModel
    {
        public List<Reserva> ListReservas { set; get; }
    }
}