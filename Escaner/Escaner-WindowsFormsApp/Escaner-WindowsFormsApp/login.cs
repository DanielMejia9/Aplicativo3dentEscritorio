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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = escanner3D; Integrated Security = True");
                con.Open();

                //Consulta a la BD
                string query = "select * from tb_usuarios where usuario ='" + textBox1.Text + "'and password_usuario ='" + textBox2.Text + "' ";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //Declaramos dos variables que van a contener la consulta del usuario y password
                    string usuario = reader[2] as string;
                    string password = reader[3] as string;
                    int tipo = (Int32)reader[9];
                    //Quitamos los espacios en blanco que vienen desde la consulta de la BD
                    usuario = usuario.Replace(" ", "");
                    password = password.Replace(" ", "");


                    if (usuario == textBox1.Text || password == textBox2.Text)
                    {
                        this.Hide();
                        Home ventanaHome = new Home();
                        ventanaHome.Show();
                    }
                    else
                    {
                        

                    }
                    break;
                }
            }
            catch (Exception) {

            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
