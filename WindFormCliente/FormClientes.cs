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

namespace WindFormCliente
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }

        private void bttReserva_Click(object sender, EventArgs e)
        {
            Cliente NuevoCliente;
            NuevoCliente = new Cliente(txtNombre.Text, txtEmail.Text, cmbTipo.Text, dtpFecha.Value);

            string resultado = NuevoCliente.RealizarReserva();
            MessageBox.Show(resultado);
        }
    }
}
