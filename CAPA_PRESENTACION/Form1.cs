using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//AGREGADOS
using CAPA_NEGOCIOS;
using System.IO;

namespace CAPA_PRESENTACION
{
    public partial class Form1 : Form
    {

        CN_Estudiantes accion = new CN_Estudiantes();

        //Variable para proteger el ID:
        private string idProducto = null;

        //Variable para pasar la imagen a otro formulario
        private static byte[] ImagenPasable;

        //Recibiendo imagen de seleccionar
        private static byte[] recibiendoImagen;

        public Form1(byte[] recibo)
        {
            if (recibo == null)
            {
                //Enviando una imagen por defecto si no escoge una imagen
                recibo = File.ReadAllBytes("D:/Imagenes/PerfilDiego.jpg");
            }
            else
            {
                recibiendoImagen = recibo;
            }
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeerEstudiantes();
            Cancelar();


            for (int year = 1980; year <= 2022; year++)
            {
                cmbYear.Items.Add(year);
            }
            //Meses:
            for (int month = 0; month <= 12; month++)
            {
                cmbMonth.Items.Add(month);
            }
            //Días:
            for (int day = 0; day <= 30; day++)
            {
                cmbDay.Items.Add(day);
            }
        }
        private void LeerEstudiantes()
        {
            CN_Estudiantes acciones = new CN_Estudiantes();
            dgvTabla.DataSource = acciones.LeerDatos();
        }
        private void Cancelar()
        {
            txtNombre.Focus();

            btnInsertar.Visible = true;
            btnBuscar.Visible = true;
            txtBuscar.Visible = true;
            cmbYear.Visible = true;
            cmbMonth.Visible = true;
            cmbDay.Visible = true;
            btnActualizar.Visible = false;
            btnCancelar.Visible = false;
            btnEliminar.Visible = false;
            btnSeleccionarImagen.Text = "Seleccionar foto";

            txtNombre.Clear();
            txtSNombre.Clear();
            txtApellido.Clear();
            txtSApellido.Clear();
            txtTelefono.Clear();
            txtCelular.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            dtpFechaNacimiento.Text = string.Empty;
            txtObservaciones.Clear();
            txtBuscar.Clear();
            cmbYear.Text = null;
            cmbDay.Text = null;
            cmbMonth.Text = null;
            //Enviando una imagen por defecto si no escoge una imagen
            ImagenPasable = File.ReadAllBytes("D:/Imagenes/PerfilDiego.jpg");
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (recibiendoImagen == null)
                {
                    recibiendoImagen = ImagenPasable;
                }
                else
                {
                    accion.InsertarDatos(txtNombre.Text, txtSNombre.Text, txtApellido.Text, txtSApellido.Text, recibiendoImagen, txtTelefono.Text, txtCelular.Text, txtDireccion.Text, txtEmail.Text, dtpFechaNacimiento.Value, txtObservaciones.Text);
                    MessageBox.Show("Datos insertados correctamente. ");
                    Cancelar();
                    LeerEstudiantes();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error al insertar: " + er);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (recibiendoImagen == null)
                {
                    recibiendoImagen = ImagenPasable;
                }
                else
                {
                    accion.ActualizarDatos(idProducto, txtNombre.Text, txtSNombre.Text, txtApellido.Text, txtSApellido.Text, recibiendoImagen, txtTelefono.Text, txtCelular.Text, txtDireccion.Text, txtEmail.Text, dtpFechaNacimiento.Value, txtObservaciones.Text);
                    MessageBox.Show("Datos modificados correctamente. ");
                    Cancelar();
                    LeerEstudiantes();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error al modificar los datos: " + er);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                accion.EliminarDatos(idProducto);
                MessageBox.Show("Datos eliminados correctamente. ");
                Cancelar();
                LeerEstudiantes();
            }
            catch (Exception er)
            {
                MessageBox.Show("Error al eliminar los datos: " + er);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void dgvTabla_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int indice = e.RowIndex;

            if (indice > -1)
            {
                btnInsertar.Visible = false;
                btnBuscar.Visible = false;
                txtBuscar.Visible = false;
                cmbYear.Visible = false;
                cmbMonth.Visible = false;
                cmbDay.Visible = false;
                btnActualizar.Visible = true;
                btnCancelar.Visible = true;
                btnEliminar.Visible = true;
                btnSeleccionarImagen.Text = "Ver imagen";

                idProducto = dgvTabla.Rows[indice].Cells[0].Value.ToString();
                txtNombre.Text = dgvTabla.Rows[indice].Cells[1].Value.ToString();
                txtSNombre.Text = dgvTabla.Rows[indice].Cells[2].Value.ToString();
                txtApellido.Text = dgvTabla.Rows[indice].Cells[3].Value.ToString();
                txtSApellido.Text = dgvTabla.Rows[indice].Cells[4].Value.ToString();
                ImagenPasable = (byte[])dgvTabla.Rows[indice].Cells[5].Value;
                txtTelefono.Text = dgvTabla.Rows[indice].Cells[6].Value.ToString();
                txtCelular.Text = dgvTabla.Rows[indice].Cells[7].Value.ToString();
                txtDireccion.Text = dgvTabla.Rows[indice].Cells[8].Value.ToString();
                txtEmail.Text = dgvTabla.Rows[indice].Cells[9].Value.ToString();
                dtpFechaNacimiento.Text = dgvTabla.Rows[indice].Cells[10].Value.ToString();
                txtObservaciones.Text = dgvTabla.Rows[indice].Cells[11].Value.ToString();
            }
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            if (ImagenPasable == null)
            {
                //Enviando una imagen por defecto si no escoge una imagen
                ImagenPasable = File.ReadAllBytes("D:/Imagenes/PerfilDiego.jpg");
            }
            else
            {
                frm_SeleccionarFoto enviando = new frm_SeleccionarFoto(ImagenPasable);
                enviando.ShowDialog();
            }

        }

        private void btnReportar_Click(object sender, EventArgs e)
        {
            CrystalReport1 crystal = new CrystalReport1();
            crystal.SetDataSource(dgvTabla.DataSource);
            MessageBox.Show("Cargando registros");

            frm_Reporte enviandoCrystal = new frm_Reporte(crystal);
            enviandoCrystal.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                CN_Estudiantes acciones2 = new CN_Estudiantes();
                dgvTabla.DataSource = acciones2.FiltroNombre(txtBuscar.Text);
                Cancelar();
            }
            catch (Exception er)
            {
                MessageBox.Show("Error al buscar por nombre: " + er);
            }

        }

        private void txtFiltrarFechaNombre_Click(object sender, EventArgs e)
        {
            try
            {
                CN_Estudiantes acciones3 = new CN_Estudiantes();
                dgvTabla.DataSource = acciones3.FiltroFechaNombre(txtBuscar.Text, cmbYear.Text, cmbMonth.Text, cmbDay.Text);
                Cancelar();
            }
            catch (Exception er)
            {
                MessageBox.Show("Error al filtrar: " + er);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Popup;
        }

        private void AceptarSoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
