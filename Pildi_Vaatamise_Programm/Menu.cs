using K4os.Compression.LZ4.Encoders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pildi_Vaatamise_Programm
{
    public partial class Menu : Form
    {
        Button btn1, btn2, btn3,btn4, btn5;
        static Label lbl, lbl2;
        public static string Name;

        public Menu()
        {
            this.Size = new Size(400, 400);
            this.BackColor = Color.LightYellow;
            


            btn1 = new Button()
            {
                Text = "Pildi vaatamise programm",
                Location = new Point(40,150),
                Size = new Size(100,50),
                BackColor = Color.LightGreen,

            };
            btn2 = new Button()
            {
                Text = "Matemaatiline äraarvamismäng",
                Location = new Point(140, 150),
                Size = new Size(100, 50),
                BackColor = Color.LightGreen


            };
            btn3 = new Button()
            {
                Text = "Sarnaste piltide leidmise mäng",
                Location = new Point(240, 150),
                Size = new Size(100, 50),
                BackColor = Color.LightGreen


            };
            btn4 = new Button()
            {
                Text = "Logi välja",
                Location = new Point(278, 20),
                Size = new Size(100, 50),
                BackColor = Color.LightGreen


            };
            btn5 = new Button()
            {
                Text = "Table",
                Location = new Point(40, 20),
                Size = new Size(100, 50),
                BackColor = Color.LightGreen


            };
            lbl = new Label()
            {
                Text = " ",
                Location = new Point(200, 20),
                Size = new Size(100, 50),
                ForeColor = Color.Black
            };
            lbl2 = new Label()
            {
                Text = "Tervist ",
                Location = new Point(165, 20),
                Size = new Size(100, 50),
                ForeColor = Color.Black
            };

            btn1.Click += Btn1_Click;
            btn2.Click += Btn2_Click;
            btn3.Click += Btn3_Click;
            btn4.Click += Btn4_Click1;
            btn5.Click += Btn5_Click;
            this.Controls.Add(btn1);
            this.Controls.Add(btn2);
            this.Controls.Add(btn3);
            this.Controls.Add(btn4); 
            this.Controls.Add(btn5);
            this.Controls.Add(lbl);
            this.Controls.Add(lbl2);




        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            tablitsa tb = new tablitsa();
            tb.ShowDialog();
            this.Close();
        }

        public int I;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane.TTHK\source\repos\ArtemKabilov2_TARpv20\Pildi_Vaatamise_Programm\Pildi_Vaatamise_Programm\Database1.mdf;Integrated Security=True";
        private void Btn4_Click1(object sender, EventArgs e)
        {
            login mang3 = new login();
            mang3.ShowDialog();
            this.Close();
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            mang2 mang2 = new mang2();
            mang2.ShowDialog();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            mang mang = new mang();
                mang.ShowDialog();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }
        public static void EnterName(string name)
        {
            lbl.Text = name;
        }
    }
}
