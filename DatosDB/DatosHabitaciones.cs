using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Entidades;

namespace DatosDB
{
    public class DatosHabitaciones : Conexion
    {
        public DataTable ListarHabitaciones()
        {
            
            string orden = "SELECT id_habitaciones, numero, tipo, precio FROM Habitaciones";

            OleDbCommand cmd = new OleDbCommand(orden, conexion);
            DataTable ds = new DataTable();
            

            try
            {
                abrirConexion();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds);

            }
            catch (Exception e)
            {               
                throw new Exception("Error al listar habitaciones",e);
            }
            finally
            {
                cerrarConexion();
                cmd.Dispose();
            }
            return ds;
        }

    }
}
