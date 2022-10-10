using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.PeerToPeer;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Pildi_Vaatamise_Programm
{
    public partial class login : Form
    {
        TextBox tb1, tb2;
        Label lbl1, lbl2;
        Button btn,btn2;
        CheckBox rb;
        public login()
        {
            this.Size = new Size(500, 400);
            tb1 = new TextBox()
            {
                Location = new Point(200,100)
            };
            tb2 = new TextBox()
            {
                Location = new Point(200, 150),
                PasswordChar = '•'
            };
            lbl1 = new Label()
            {
                Location = new Point(170, 100),
                Text = "login"
            };
            lbl2 = new Label()
            {
                Location = new Point(145, 150),
                Text = "Password"
            };
            btn = new Button()
            {
                Location = new Point(200, 260),
                Size = new Size(100,40),
                Text = "Logi Sisse"
            };
            btn2 = new Button()
            {
                Location = new Point(200, 300),
                Size = new Size(100, 40),
                Text = "Registreerima"
            };
            this.Controls.Add(tb1);
            this.Controls.Add(tb2);
            this.Controls.Add(btn);
            this.Controls.Add(btn2);
            this.Controls.Add(lbl1);
            this.Controls.Add(lbl2);



            btn.Click += Btn_Click;
            btn2.Click += Btn2_Click;
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            this.Hide();
            registration mp2 = new registration();
            mp2.Show();
        }

        public int I;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane.TTHK\source\repos\ArtemKabilov2_TARpv20\Pildi_Vaatamise_Programm\Pildi_Vaatamise_Programm\Database1.mdf;Integrated Security=True";

        private async void Btn_Click(object sender, EventArgs e)
        {
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane.TTHK\source\repos\ArtemKabilov2_TARpv20\Pildi_Vaatamise_Programm\Pildi_Vaatamise_Programm\Database1.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            I = 0;
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from people where nimi = '" + tb1.Text + "'and password= '" + tb2.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            I = Convert.ToInt32(dt.Rows.Count.ToString());
            if (I == 0)
            {
                MessageBox.Show("Seda kasutajanime või parooli pole olemas");
            }
            else
            {
                this.Hide();
                Menu mp = new Menu();
                mp.Show();
            }
            connection.Close();

        }
    }
}
