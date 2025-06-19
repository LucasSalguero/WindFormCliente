using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace DatosDB
{
    public class Conexion
    {
        public OleDbConnection conexion;
        public string cadenaConexion = @"Provider=SQLOLEDB;Data Source=DESKTOP-B23JM8V;Initial Catalog=Hoteleria;Integrated Security=SSPI;";


        public Conexion()
        {
            conexion = new OleDbConnection(cadenaConexion);

        }

        public void abrirConexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Broken || conexion.State == ConnectionState.Closed)
                    conexion.Open();
                    Console.WriteLine("Servidor conectado correctamente");

            }
            catch (Exception e)
            {
                throw new Exception("Error al conectarse a la base de datos", e);
            }
        }

        public void cerrarConexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            catch (Exception e)
            {

                throw new Exception ("Error al tratar de cerrar conexion",e);
            }


        }







    }


}
