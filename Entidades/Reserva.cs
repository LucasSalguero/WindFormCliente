using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Reserva
    {
        private int IdReservas;
        private int IdCliente;
        private int IdHabitacion;
        private DateTime FechaReserva;
        private string EstadoReserva;

        // prop

        public int p_idReserva {  get; set; }
        public int p_idCliente { get; set; }
        public int p_idHabitacion { get; set; }
        public DateTime p_FechaReserva { get; set; }
        public string p_EstadoReserva { get; set; }

        public Reserva() { }

        public Reserva (int idReservas, int idCliente,int idhabitacion, DateTime fechaReserva, string estadoreserva)
        {
            IdReservas = idReservas;
            IdCliente = idCliente;
            IdHabitacion = idhabitacion;
            FechaReserva = fechaReserva;
            EstadoReserva = estadoreserva;

        }


    }
}
