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
using System.IO;

namespace CAPA_PRESENTACION
{
    public partial class frm_SeleccionarFoto : Form
    {
        private static byte[] imagenActual; 
        public frm_SeleccionarFoto(byte[] imagenRecibida)
        {
            imagenActual = imagenRecibida;
            InitializeComponent();
        }
        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fo = new OpenFileDialog();
                DialogResult rs = fo.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(fo.FileName);
                    MessageBox.Show("Archivo cargado");
                }
            }
            catch
            {
                MessageBox.Show("Archivo no valido");
            }
        }

        private void frm_SeleccionarFoto_Load(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream(imagenActual);
            pictureBox1.Image = Image.FromStream(ms);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            MemoryStream memy = new MemoryStream();
            pictureBox1.Image.Save(memy, System.Drawing.Imaging.ImageFormat.Jpeg);
            Form1 enviandoImagen2 = new Form1(memy.GetBuffer());
            this.Close();
        }
    }
}
