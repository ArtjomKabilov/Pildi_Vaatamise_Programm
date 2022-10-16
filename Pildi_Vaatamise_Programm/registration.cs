using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;

namespace Pildi_Vaatamise_Programm
{
    public partial class registration : Form
    {
        TextBox tb1, tb2,tb3,tb4,tb5;
        Label lbl1, lbl2,lbl3,lbl4,lbl5;
        Button btn;
        public registration()
        {
            this.Size = new Size(500, 400);
            tb1 = new TextBox()
            {
                Location = new Point(200, 50)
            };
            tb2 = new TextBox()
            {
                Location = new Point(200, 100),
            };
            tb3 = new TextBox()
            {
                Location = new Point(200, 150),
            };
            tb4 = new TextBox()
            {
                Location = new Point(200, 200),
            };
            tb5 = new TextBox()
            {
                Location = new Point(200, 250),
                PasswordChar = '•',

            };
            lbl1 = new Label()
            {
                Location = new Point(150, 50),
                Text = "Nimi"
            };
            lbl2 = new Label()
            {
                Location = new Point(150, 100),
                Text = "E-mail"
            };
            lbl3 = new Label()
            {
                 Location = new Point(150, 150),
                 Text = "Sugu"
            };
            lbl4 = new Label()
            {
                Location = new Point(150, 200),
                Text = "Vanus"
            };
            lbl5 = new Label()
            {
                Location = new Point(150, 250),
                Text = "parool"
            };
            btn = new Button()
            {
                Location = new Point(200, 300),
                Size = new Size(100, 40),
                Text = "Registreerima"
            };
            this.Controls.Add(tb1);
            this.Controls.Add(tb2);
            this.Controls.Add(tb3);
            this.Controls.Add(tb4);
            this.Controls.Add(tb5);
            this.Controls.Add(btn);
            this.Controls.Add(lbl1);
            this.Controls.Add(lbl2);
            this.Controls.Add(lbl3);
            this.Controls.Add(lbl4);
            this.Controls.Add(lbl5);


            btn.Click += Btn_Click;

        }

        public int I;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\artem\Source\Repos\Pildi_Vaatamise_Programm\Pildi_Vaatamise_Programm\Database2.mdf;Integrated Security=True";

        private async void Btn_Click(object sender, EventArgs e)
        {
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane.TTHK\source\repos\ArtemKabilov2_TARpv20\Pildi_Vaatamise_Programm\Pildi_Vaatamise_Programm\Database1.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            I = 0;
            connection.Open();
           
            if (tb1.Text.Length == 0)
            {
                MessageBox.Show("Sa jätsid tühjad read");

            }
            else if (tb2.Text.Length == 0)
            {
                MessageBox.Show("Sa jätsid tühjad read");

            }
            else if (tb3.Text.Length == 0)
            {
                MessageBox.Show("Sa jätsid tühjad read");

            }
            else if (tb4.Text.Length == 0)
            {
                MessageBox.Show("Sa jätsid tühjad read");

            }
            else if (tb5.Text.Length == 0)
            {
                MessageBox.Show("Sa jätsid tühjad read");

            }
            else
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT people(nimi,email,sugu,vanus,password) VALUES ('" + tb1.Text + "','" + tb2.Text + "', '" + tb3.Text + "', '" + tb4.Text + "','" + tb5.Text + "');";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                I = Convert.ToInt32(dt.Rows.Count.ToString());
                this.Hide();
                login mp = new login();
                mp.Show();
            }
           
            connection.Close();


        } 
    }
}        
   

