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
    public partial class consultar : Form
    {
        public consultar()
        {
            InitializeComponent();
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void PacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            registro_paciente ventanaRegistro = new registro_paciente();
            ventanaRegistro.Show();
        }

        private void HistorialPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            consultar ventanaConsultar = new consultar();
            ventanaConsultar.Show();
        }

        private void EscanearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            escaner ventanaEscaner = new escaner();
            ventanaEscaner.Show();
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

        private void InicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home ventanaHome = new Home();
            ventanaHome.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(textCedula.Text != "")
            {
                SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = escanner3D; Integrated Security = True");
                con.Open();

                //Consulta a la BD
                string query = "select * from tb_pacientes where cedula_paciente ='"+ textCedula.Text + "'";


                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //Declaramos dos variables que van a contener la consulta del usuario y password

                    textNombre.Text = reader[1].ToString();
                    textCedula.Text = reader[2].ToString();
                    textEdad.Text   = reader[3].ToString();
                    textRH.Text     = reader[4].ToString();
                    textCorreo.Text = reader[5].ToString();
                    textObservacion.Text = reader[6].ToString();

                    //Habilitamos los campos
                    textNombre.Enabled = true;
                    textCedula.Enabled = true;
                    textEdad.Enabled = true;
                    textRH.Enabled = true;
                    textCorreo.Enabled = true;
                    textObservacion.Enabled = true;
                    button1.Enabled = true;
                }
            }
        }

        private void Consultar_Load(object sender, EventArgs e)
        {
            textNombre.Enabled = false;
            textEdad.Enabled = false;
            textRH.Enabled = false;
            textCorreo.Enabled = false;
            textObservacion.Enabled = false;
            button1.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = escanner3D; Integrated Security = True");
                con.Open();

                //Consulta a la BD
                string update = "update tb_pacientes set nombre_paciente = '" + textNombre.Text + "', edad_paciente ='" + textEdad.Text + "', rh_paciente = '" + textRH.Text + "', correo_paciente = '" + textCorreo.Text + "', contra_paciente = '" + textObservacion.Text + "' where cedula_paciente = '"+ textCedula.Text + "'";
               
                SqlCommand cmd = new SqlCommand(update, con);
                //Abrimos la conexion a la BD
                cmd.ExecuteNonQuery();
                con.Close();
               
                MessageBox.Show("Registro Guardado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void RegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
