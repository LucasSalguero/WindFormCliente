using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosDB;
using Entidades;

namespace Negocioss
{
    
    public class negReservas
    {
        
        DatosReserva datosReserva = new DatosReserva();
        public DataSet RealizarReserva()
        {
            return datosReserva.RealizarReserva();
        }

        public int AmbReservas(string accion, Reserva objReserva)
        {
            return datosReserva.AbmReservas(accion, objReserva);
        }

    }

    
}
