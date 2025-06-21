using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DatosDB
{
    public class DatosReserva : Conexion
    {

        public DataSet RealizarReserva()
        {
                        
            string orden = @"SELECT 
                        Clientes.Nombre,
                        Clientes.Apellido,
                        Clientes.DNI,
                        Habitaciones.numero,
                        Habitaciones.tipo,
                        Reservas.fecha_Reserva
                       FROM 
                        ((Reservas 
                        INNER JOIN Clientes  ON Reservas.id_Clientes = Clientes.id_Clientes)
                        INNER JOIN Habitaciones  ON Reservas.id_Habitaciones = Habitaciones.id_Habitaciones)";
            OleDbCommand cmd = new OleDbCommand(orden, conexion);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                abrirConexion();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {

                throw new Exception("Error al realizar reserva", e);
            }
            finally
            {
                cerrarConexion();
                cmd.Dispose();

            }
            return ds;

           
        }

        public int AbmReservas(string accion, Reserva objReservas)
        {
            int resultado = -1;
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conexion;
            try
            {
                abrirConexion();

                if (accion == "Alta")
                {
                    cmd.CommandText = "INSERT INTO Reservas (id_clientes, id_habitaciones, fecha_reserva) VALUES (?, ?, ?)";
                    cmd.Parameters.AddWithValue("id_Clientes", objReservas.p_idCliente);
                    cmd.Parameters.AddWithValue("id_Habitaciones", objReservas.p_idHabitacion);
                    cmd.Parameters.AddWithValue("fecha_Reserva", objReservas.p_FechaReserva);

                }
                else if (accion == "Modificar")
                {
                    cmd.CommandText = "UPDATE Reservas SET id_clientes = ?, id_habitaciones = ?,WHERE fecha_reserva = ?";
                    cmd.Parameters.AddWithValue("id_Clientes", objReservas.p_idCliente);
                    cmd.Parameters.AddWithValue("id_Habitaciones", objReservas.p_idHabitacion);
                    cmd.Parameters.AddWithValue("fecha_Reserva", objReservas.p_FechaReserva);

                }
                else if (accion == "Baja")
                {
                    cmd.CommandText = "DELETE FROM Reservas where id_reserva = ?";
                    cmd.Parameters.AddWithValue("id_cliente", objReservas.p_idReserva);
                }

                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de guardar, modificar o eliminar cliente: " + e.Message, e);
            }
            finally
            {
                cerrarConexion();
                cmd.Dispose();
            }

            return resultado;
        }


    }


}
