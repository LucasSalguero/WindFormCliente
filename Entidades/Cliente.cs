using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        // atributos

        private int IdCliente;
        private string DNI;
        private string Nombre;
        private string Apellido;
        private string Email;
        private string Telefono;

        // propiedades
        public int p_idCliente {  get; set; }
        public string p_dni { get; set; }
        public string p_nombre { get; set; }
        public string p_apellido { get; set; }
        public string p_email { get; set; }
        public string P_telefono { get; set; }

        public Cliente() { }

        public Cliente(int idcl, string dni, string nombre, string apellido, string email, string telefono)
        {
            IdCliente = idcl;
            DNI = dni;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Telefono = telefono;
          
        }



    }
}
