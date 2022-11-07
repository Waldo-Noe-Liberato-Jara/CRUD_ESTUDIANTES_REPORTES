using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAPA_PRESENTACION
{
    public partial class frm_Reporte : Form
    {
        private static CrystalReport1 crystalActual;
        public frm_Reporte(CrystalReport1 crystal)
        {
            crystalActual = crystal;
            InitializeComponent();
        }

        private void frm_Reporte_Load(object sender, EventArgs e)
        {
            rectangleShape1.BringToFront();
            crystalReportViewer1.ReportSource = crystalActual;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
