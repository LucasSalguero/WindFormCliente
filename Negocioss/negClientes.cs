using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DatosDB;
using Entidades;

namespace Negocioss
{
    public class negClientes
    {
        DatosClientes objDatosClientes = new DatosClientes();
        public int AmbClientes(string accion, Cliente objCliente)
        {
            return objDatosClientes.AbmClientes(accion, objCliente);
        }
    }
}
