using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        private string Nombre;
        private string Email;
        private int NroHabitacion;
        private string TipoHabitacion;
        private DateTime Fecha;

        private static int contadorHabitaciones = 100;
        public Cliente()
        { }

        public Cliente(string nombre, string email, string tipoHabitacion, DateTime fecha)
        {
            Nombre = nombre;
            Email = email;
            TipoHabitacion= tipoHabitacion;
            Fecha = fecha;
        }

        public string RealizarReserva()
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Email))
                return "Error: Nombre y Email son obligatorios.";

            if (Fecha.Date < DateTime.Today)
                return "Error: La fecha de reserva no puede ser en el pasado.";

            if (string.IsNullOrWhiteSpace(TipoHabitacion))
                return "Error: Seleccione un tipo de habitación.";

            NroHabitacion = ++contadorHabitaciones;

            return $"Reserva exitosa.\nHabitación asignada: {NroHabitacion}";
        }
    }
}
