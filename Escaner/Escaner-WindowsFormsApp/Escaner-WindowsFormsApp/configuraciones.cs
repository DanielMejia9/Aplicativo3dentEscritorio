using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SqlClient;

namespace Escaner_WindowsFormsApp
{
    public partial class configuraciones : Form
    {
        String output;
        public configuraciones()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //Verificamos el puerto asignado
            SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = escanner3D; Integrated Security = True");
            con.Open();

            //Consulta a la BD
            string query = "SELECT * from tb_port";
            SqlCommand cmd = new SqlCommand(query, con);
            //Obtenemos el valor de la consulta
            SqlDataReader reader = cmd.ExecuteReader();


          
            while (reader.Read())
            {

               string puertoAsignado = reader["number_port"].ToString();
               puertoAsig.Text = puertoAsignado;

                string rutaAsignado = reader["browser_folder"].ToString();
                folder.Text = rutaAsignado;

                if (puertoAsignado != null)
               {
                        groupBox1.Enabled = false;
                        groupBox2.Enabled = true;
               }
               break;
            }
            puertosDisponibles();
        }

        private void puertosDisponibles(){
            foreach (string puertosDisponibles in System.IO.Ports.SerialPort.GetPortNames()){
                cmbPuertos.Items.Add(puertosDisponibles);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = cmbPuertos.Text;
            cmbPuertos.Enabled = false;
            try
            {
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione otro puerto", "Puerto no Disponible");
                cmbPuertos.Enabled = true;
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            try {
                serialPort1.Write(txtTx.Text.Trim());
                txtTx.Clear();

            }
            catch (Exception ex) {
                MessageBox.Show("Error"+ ex);
            }
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string datosRx = serialPort1.ReadExisting();
            txtRx.Text = datosRx;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            String puerto = cmbPuertos.Text;
            String folder = txtBrowser.Text;

            SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = escanner3D; Integrated Security = True");
            con.Open();

            //Consulta a la BD
            string query = "select COUNT(*) from tb_port where number_port ='" + puerto + "' ";

            SqlCommand cmd = new SqlCommand(query, con);

            //Obtenemos el valor de la consulta
            int result = (Int32)cmd.ExecuteScalar();
            //Validamos
            if (result == 0)
            {
                //Validamos que los campo no esten vacios
                if (cmbPuertos.Text != "" && txtBrowser.Text != "") {
                    string insert = "insert into tb_port (number_port,browser_folder)  values ('" + puerto + "," + folder + "')";
                    SqlCommand cmd2 = new SqlCommand(insert, con);
                    //Abrimos la conexion a la BD
                    cmd2.ExecuteNonQuery();
                    con.Close();

                    groupBox1.Enabled = false;
                    groupBox2.Enabled = true;
                }
                else {
                    MessageBox.Show("Por favor rellene los campos");
                }
               


            }
            else
            {
                //Validamos que los campo no esten vacios
                if (cmbPuertos.Text != "" && txtBrowser.Text != "")
                {
                    string update = "update  tb_port set number_port ='" + puerto + "' , browser_folder = '" + folder + "'";
                    SqlCommand cmd3 = new SqlCommand(update, con);
                    //Abrimos la conexion a la BD
                    cmd3.ExecuteNonQuery();
                    con.Close();
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = true;
                }
                else {
                    MessageBox.Show("Por favor rellene los campos");
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
        }

        private void InicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home ventanaHome = new Home();
            ventanaHome.Show();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtBrowser.Text = folderBrowserDialog1.SelectedPath;
            output = folderBrowserDialog1.SelectedPath;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PuertoAsig_TextChanged(object sender, EventArgs e)
        {

        }

        private void PacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            registro_paciente ventanaPacientes = new registro_paciente();
            ventanaPacientes.Show();
        }

        private void PacientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            registro_paciente ventanaRegistro = new registro_paciente();
            ventanaRegistro.Show();
        }

        private void HistorialPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            consultar ventanaConsulta = new consultar();
            ventanaConsulta.Show();
        }

        private void EscanearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            escaner ventanaEscaner = new escaner();
            ventanaEscaner.Show();
        }

        private void ConfiguraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            configuraciones ventanaConfiguraciones = new configuraciones();
            ventanaConfiguraciones.Show();
        }
    }
}
