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


        #region Metodos privados
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
            
            if (dgvReservas.Columns.Contains("id_Reservas"))
            {
                dgvReservas.Columns["id_Reservas"].Visible = false;
            }
            if (dgvReservas.Columns.Contains("id_Clientes"))
            {
                dgvReservas.Columns["id_Clientes"].Visible = false;
            }

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

    

        private void CargarHabitaciones()
        {
            negHabitaciones habitacion = new negHabitaciones();
            cmbTipo.DataSource = habitacion.ListarHabitaciones();
            cmbTipo.DisplayMember = "tipo";
            cmbTipo.ValueMember = "id_Habitaciones";


        }

        private void ModificarReserva()
        {
            if (dgvReservas.SelectedRows.Count > 0)
            {
                int idReserva = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["id_Reservas"].Value);
                int idCliente = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["id_clientes"].Value);

                TxtBox_a_Obj(); // llena objEntCliente desde los TextBox

                // Actualizar datos del cliente
                objEntCliente.p_idCliente = idCliente;
                int resultadoCliente = objNegCliente.AmbClientes("Modificar", objEntCliente);

                if (resultadoCliente <= 0)
                {
                    MessageBox.Show("Error al modificar el cliente.");
                    return;
                }

                // Actualizar datos de la reserva
                objEntReserva.p_idReserva = idReserva;
                objEntReserva.p_idCliente = idCliente;
                objEntReserva.p_idHabitacion = Convert.ToInt32(cmbTipo.SelectedValue);
                objEntReserva.p_FechaReserva = dtpFecha.Value;

                int resultadoReserva = objNegReserva.AmbReservas("Modificar", objEntReserva);

                if (resultadoReserva > 0)
                {
                    MessageBox.Show("Reserva modificada con éxito.");
                    CargarReserva();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo modificar la reserva.");
                }
            }
            else
            {
                MessageBox.Show("Seleccioná una reserva para modificar.");
            }
        }

        private void EliminarReserva()
        {
            if (dgvReservas.SelectedRows.Count > 0)
            {
                int idReserva = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["id_Reservas"].Value);

                DialogResult confirmacion = MessageBox.Show(
                    "¿Estás seguro de que querés eliminar esta reserva?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    objEntReserva.p_idReserva = idReserva;

                    int resultado = objNegReserva.AmbReservas("Baja", objEntReserva);

                    if (resultado > 0)
                    {
                        MessageBox.Show("Reserva eliminada con éxito.");                       
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la reserva.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccioná una reserva para eliminar.");
            }


        }

        private void EliminarCliente()
        {
            int idCliente = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["id_clientes"].Value);

            objEntCliente.p_idCliente = idCliente;

            int resultado = objNegCliente.AmbClientes("Baja", objEntCliente);
        }

        #endregion

        #region Eventos
        private void bttReserva_Click(object sender, EventArgs e)
        {
           RegistrarReserva();
            CargarReserva();
           
        }
       
        private void bttEditar_Click(object sender, EventArgs e)
        {
            ModificarReserva();
            CargarReserva();
            Limpiar();
        }

        private void dgvReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text = dgvReservas.CurrentRow.Cells[2].Value.ToString();
            txtApellido.Text = dgvReservas.CurrentRow.Cells[3].Value.ToString();
            txtDni.Text = dgvReservas.CurrentRow.Cells[4].Value.ToString();
            txtEmail.Text = dgvReservas.CurrentRow.Cells[5].Value.ToString();
            txtTelefono.Text = dgvReservas.CurrentRow.Cells[6].Value.ToString();
        }

        private void bttEliminar_Click(object sender, EventArgs e)
        {
            EliminarReserva();
            EliminarCliente();
            CargarReserva();
            Limpiar();

        }

        #endregion
        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarReserva();
            CargarHabitaciones();
        }



    }
}
