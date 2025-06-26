using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Entidades;



namespace DatosDB
{
    public class DatosClientes : Conexion
    {
        public int AbmClientes(string accion,Cliente objCliente)
        {
            int resultado = -1;
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conexion;
            try
            {
                abrirConexion();

                if (accion == "Alta")
                {
                    cmd.CommandText = "INSERT INTO Clientes (DNI, Nombre, Apellido, Email, Telefono) VALUES (?, ?, ?, ?, ?)";
                    cmd.Parameters.AddWithValue("DNI", objCliente.p_dni);
                    cmd.Parameters.AddWithValue("Nombre", objCliente.p_nombre);
                    cmd.Parameters.AddWithValue("Apellido", objCliente.p_apellido);
                    cmd.Parameters.AddWithValue("Email", objCliente.p_email);
                    cmd.Parameters.AddWithValue("Telefono", objCliente.p_telefono);

                    cmd.ExecuteNonQuery();

                    // Para obtener el id del cliente recien generado
                    cmd.CommandText = "SELECT @@IDENTITY";
                    cmd.Parameters.Clear(); //Limpiar param anteriores
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());

                }
                else if (accion == "Modificar")
                {
                    cmd.CommandText = "UPDATE Clientes SET Nombre = ?, Apellido = ?, Email = ?, Telefono = ?, DNI = ? WHERE id_Clientes = ?";
                    cmd.Parameters.AddWithValue("Nombre", objCliente.p_nombre);
                    cmd.Parameters.AddWithValue("Apellido", objCliente.p_apellido);
                    cmd.Parameters.AddWithValue("Email", objCliente.p_email);
                    cmd.Parameters.AddWithValue("Telefono", objCliente.p_telefono);
                    cmd.Parameters.AddWithValue("DNI", objCliente.p_dni);
                    cmd.Parameters.AddWithValue("id_Clientes", objCliente.p_idCliente);

                    resultado = cmd.ExecuteNonQuery();
                }
                else if (accion == "Baja")
                {
                    cmd.CommandText = "DELETE FROM Clientes WHERE id_clientes = ?";
                    cmd.Parameters.AddWithValue("id_clientes", objCliente.p_idCliente);

                    resultado = cmd.ExecuteNonQuery();
                }

                
                
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
