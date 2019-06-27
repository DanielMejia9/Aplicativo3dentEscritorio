using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escaner_WindowsFormsApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void ConfiguraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            configuraciones ventanaConfiguraciones = new configuraciones();
            ventanaConfiguraciones.Show();
        }

        private void EscanearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            escaner ventanaEscaner = new escaner();
            ventanaEscaner.Show();
        }

        private void PacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            registro_paciente ventanaRegistro = new registro_paciente();
            ventanaRegistro.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void InicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home ventanaHome = new Home();
            ventanaHome.Show();
        }

        private void HistorialPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            consultar ventanaConsulta = new consultar();
            ventanaConsulta.Show();
        }

        private void RegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
