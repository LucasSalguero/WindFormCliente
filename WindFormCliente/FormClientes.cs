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

        public Reserva objEntReserva = new Reserva();
        public negReservas objNegReserva = new negReservas();

        public Habitacion objEntHabitacion = new Habitacion();
        public negHabitaciones objNegHabitacion = new negHabitaciones();


        //metodo de limpiar
        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();

        }

        private void TxtBox_a_Obj()
        {
            objEntCliente.p_nombre = txtNombre.Text;
            objEntCliente.p_apellido = txtApellido.Text;
            objEntCliente.p_email = txtEmail.Text;
            objEntCliente.p_dni = txtDni.Text;
            objEntCliente.p_telefono = txtTelefono.Text;
                      

        }

       

        private void CargarReserva()
        {
            TxtBox_a_Obj();
            negReservas reserva = new negReservas();
            DataSet ds = reserva.RealizarReserva();
            dgvReservas.DataSource = ds.Tables[0];
            
        }


        private void RegistrarReserva()
        {
            // Cargar datos del cliente desde los TextBox
            TxtBox_a_Obj();

            // 1. Registrar cliente y obtener el ID
            int idCliente = objNegCliente.AmbClientes("Alta", objEntCliente);

            if (idCliente <= 0)
            {
                MessageBox.Show("Error al registrar el cliente.");
                return;
            }

            // 2. Cargar datos de la reserva
            objEntReserva.p_idCliente = idCliente;
            objEntReserva.p_idHabitacion = Convert.ToInt32(cmbTipo.SelectedValue);
            objEntReserva.p_FechaReserva = dtpFecha.Value;

            // 3. Registrar la reserva
            int resultado = objNegReserva.AmbReservas("Alta", objEntReserva);

            if (resultado > 0)
            {
                MessageBox.Show("Reserva registrada con éxito.");
                CargarReserva(); // refrescar el dgv
                Limpiar();       // limpiar los campos
            }
            else
            {
                MessageBox.Show("No se pudo registrar la reserva.");
            }
        }

        private void ModificarReserva()
        {
            TxtBox_a_Obj();
            int resultadoCliente = objNegCliente.AmbClientes("Modificar", objEntCliente);
            
            objEntReserva.p_idCliente = objEntCliente.p_idCliente;
            objEntReserva.p_idHabitacion = Convert.ToInt32(cmbTipo.SelectedValue);
            objEntReserva.p_FechaReserva = dtpFecha.Value;

            int resultadoReserva = objNegReserva.AmbReservas("Modificar", objEntReserva);

            if (resultadoCliente > 0 || resultadoReserva > 0 )
            {
                MessageBox.Show("Modificacion realizada");
                CargarReserva();
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo modificar");
            }


        }

        private void CargarHabitaciones()
        {
            negHabitaciones habitacion = new negHabitaciones();
            cmbTipo.DataSource = habitacion.ListarHabitaciones();
            cmbTipo.DisplayMember = "tipo";
            cmbTipo.ValueMember = "id_Habitaciones";


        }



        private void bttReserva_Click(object sender, EventArgs e)
        {
           RegistrarReserva();
            CargarReserva();
           
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarReserva();
            CargarHabitaciones();
        }

       

        private void bttEditar_Click(object sender, EventArgs e)
        {
            ModificarReserva();
        }


    }
}
