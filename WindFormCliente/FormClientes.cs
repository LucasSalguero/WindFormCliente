using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocioss;


namespace WindFormCliente
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();

        }

        public Cliente objEntCliente = new Cliente();
        public negClientes objNegCliente = new negClientes();

        private void TxtBox_a_Obj()
        {
            objEntCliente.p_nombre = txtNombre.Text;
            objEntCliente.p_apellido = txtApellido.Text;
            objEntCliente.p_email = txtEmail.Text;
            objEntCliente.p_dni = txtDni.Text;
        }
        private void bttReserva_Click(object sender, EventArgs e)
        {
            int nGrabados = -1;
            TxtBox_a_Obj();
            nGrabados = objNegCliente.AmbClientes("Alta", objEntCliente);

            if (nGrabados == -1)
                System.Console.WriteLine("no pudo grabarse los clientes en el sistema");
            else
            {
                System.Console.WriteLine("se grabo con exito");
            }

        }

      
    }
}
