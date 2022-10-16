using MongoDB.Driver;
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
        TextBox tb1, tb2,tb3,tb4;
        Label lbl1, lbl2,lbl3,lbl4;
        Button btn,btn2,btn3,btn4,btn5;
        public int I;
        public static int Id;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\artem\Source\Repos\Pildi_Vaatamise_Programm\Pildi_Vaatamise_Programm\Database2.mdf;Integrated Security=True";

        public login()
        {
            this.Size = new Size(500, 400);
            tb1 = new TextBox()
            {
                Location = new Point(200,100)
            };
            tb3 = new TextBox()
            {
                Location = new Point(200, 100)
            };
            tb4 = new TextBox()
            {
                Location = new Point(200, 100),
                PasswordChar = '•'
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
            lbl3 = new Label()
            {
                Location = new Point(130, 100),
                Text = "sisesta email"
            };
            lbl4 = new Label()
            {
                Location = new Point(130, 100),
                Text = "uus parol"
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
            btn3 = new Button()
            {
                Location = new Point(300, 280),
                Size = new Size(100, 40),
                Text = "parooli taastamine"
            };
            btn4 = new Button()
            {
                Location = new Point(200, 260),
                Size = new Size(100, 40),
                Text = "uus parol"
            };
            btn5 = new Button()
            {
                Location = new Point(200, 260),
                Size = new Size(100, 40),
                Text = "uus parool"
            };
            this.Controls.Add(tb1);
            this.Controls.Add(tb2);
            this.Controls.Add(btn);
            this.Controls.Add(btn2);
            this.Controls.Add(btn3);
            this.Controls.Add(lbl1);
            this.Controls.Add(lbl2);



            btn.Click += Btn_Click;
            btn2.Click += Btn2_Click;
            btn3.Click += Btn3_Click;
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            tb1.Hide();
            tb2.Hide();
            lbl1.Hide();
            lbl2.Hide();
            btn.Hide();
            btn2.Hide();
            btn3.Hide();
            this.Controls.Add(tb3);
            this.Controls.Add(btn4);
            this.Controls.Add(lbl3);
            btn4.Click += Btn4_Click;
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            I = 0;
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from people where email = '" + tb3.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            I = Convert.ToInt32(dt.Rows.Count.ToString());
            if (I == 0)
            {
                MessageBox.Show("Sellist posti pole.");
            }
            else
            {
                tb3.Hide();
                btn4.Hide();
                lbl3.Hide();
                this.Controls.Add(tb4);
                this.Controls.Add(btn5);
                this.Controls.Add(lbl4);
                btn5.Click += Btn5_Click;
            }
            connection.Close();
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "UPDATE people(password) SET = '"+ tb4.Text +"' WHERE email='"+ tb3.Text +"'";
            cmd.Parameters.Add("@password", tb4.Text);
            cmd.Parameters.Add("@email", tb3.Text);
            cmd.CommandText = "UPDATE people SET password = @password Where email = @email";
       
            DataTable dtt = new DataTable();
            SqlDataAdapter daa = new SqlDataAdapter(cmd);
            daa.Fill(dtt);
            connection.Close();
            this.Hide();
            login mp2 = new login();
            mp2.Show();

        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            this.Hide();
            registration mp2 = new registration();
            mp2.Show();
        }

        

        public async void Btn_Click(object sender, EventArgs e)
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
                Id = Convert.ToInt32(dt.Rows[0][0]);
                this.Hide();
                Menu m = new Menu();
                Pildi_Vaatamise_Programm.Menu.EnterName(tb1.Text);
                m.Show();
            }
            connection.Close();

        }
    }
}
