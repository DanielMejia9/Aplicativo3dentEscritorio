using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Escaner_WindowsFormsApp
{
    public partial class registro_paciente : Form
    {
        public registro_paciente()
        {
            InitializeComponent();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = escanner3D; Integrated Security = True");
                con.Open();

                //Consulta a la BD
                string insert = "insert into tb_pacientes (nombre_paciente,cedula_paciente,edad_paciente,rh_paciente,correo_paciente,contra_paciente)values ('" + textNombre.Text + "','" + textCedula.Text + "','" + textEdad.Text + "','" + textRH.Text + "','" + textCorreo.Text + "','" + textObservacion.Text + "')";

                SqlCommand cmd = new SqlCommand(insert, con);
                //Abrimos la conexion a la BD
                cmd.ExecuteNonQuery();
                con.Close();
                textNombre.Text = "";
                textCedula.Text = "";
                textEdad.Text = "";
                textRH.Text = "";
                textCorreo.Text = "";
                textObservacion.Text = "";
                MessageBox.Show("Registro Guardado");

            }
            catch (Exception ex) {
                MessageBox.Show("Error" + ex);
            } 
        }

        private void HistorialPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            consultar ventanaConsultar = new consultar ();
            ventanaConsultar.Show();
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

        private void PermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ConfiguraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            configuraciones ventanaConfiguracion = new configuraciones();
            ventanaConfiguracion.Show();
        }

        private void ConsultarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void InicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home ventanaHome = new Home();
            ventanaHome.Show();
        }

        private void Registro_paciente_Load(object sender, EventArgs e)
        {
           
        }
    }
}
