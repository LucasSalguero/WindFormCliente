using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Habitacion
    {
        //atrib
        private int IdHabitacion;
        private string NumeroHab;
        private string TipoHab;
        private decimal Precio;
        private string Estado;

        //prop
        public int p_idHabitacion { get; set; }
        public string p_numeroHab { get; set; }
        public string p_tipoHab { get; set; }
        public decimal p_precio { get; set; }
        public string p_estado { get; set; }


        // metodo 
        public Habitacion() { }

        public Habitacion (int idhabitacion, string numerohab, string tipohab, decimal precio, string estado)
        {
            IdHabitacion = idhabitacion;
            NumeroHab = numerohab;
            TipoHab = tipohab;
            Precio = precio;
            Estado = estado;
        }


       





    }
}
