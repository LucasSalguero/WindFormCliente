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
    public class negHabitaciones
    {
        DatosHabitaciones objnegHabitaciones = new DatosHabitaciones();

        public DataTable ListarHabitaciones()
        {
            return objnegHabitaciones.ListarHabitaciones();
        }

    }
}
