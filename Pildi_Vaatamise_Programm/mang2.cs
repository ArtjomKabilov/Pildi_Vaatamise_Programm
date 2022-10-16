using Microsoft.Data.SqlClient;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pildi_Vaatamise_Programm
{
    public partial class mang2 : Form
    {
       
            Random random = new Random();
        TableLayoutPanel tlp;
        Label firstClicked = null;
        Label secondClicked = null;
        Timer taimer;
        Button btn1, btn2;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\artem\Source\Repos\Pildi_Vaatamise_Programm\Pildi_Vaatamise_Programm\Database2.mdf;Integrated Security=True";
        List<string> icons = new List<string>()
        {
            "a", "a", "B", "B", "j", "j", "K", "K",
            "d", "d", "X", "X", "W", "W","g", "g","1", "1",
        };
        public mang2()
        {
            this.Size = new Size(600, 600);
            this.BackColor = Color.LightGreen;
            MaximizeBox = false;
            tlp = new TableLayoutPanel
            {
                BackColor = Color.LightGreen,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
            };        
            btn1 = new Button()
            {
                Text = "Lihtne mäng",
                Location = new Point(150,250),
                Size = new Size(100,50),
                BackColor = Color.White

            };
            btn2 = new Button()
            {
                Text = "Raske mäng",
                Location = new Point(300, 250),
                Size = new Size(100, 50),
                BackColor = Color.White
            };
            btn2.Click += Btn2_Click;
            btn1.Click += Btn1_Click;
            this.Controls.Add(btn1);
            this.Controls.Add(btn2);
           
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            btn1.Hide();
            btn2.Hide();
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Label lb = new Label
                    {
                        BackColor = Color.LightGreen,
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Webdings", 48, FontStyle.Bold),
                        Size = new Size(48, 48),
                        Text = "c"
                    };
                    lb.Click += label1_Click;
                    tlp.Controls.Add(lb, i, j);
                }
            }
            taimer = new Timer();
            taimer.Interval = 750;
            taimer.Tick += Tm_Tick;
            Controls.AddRange(new Control[] { tlp, });
            AssignIconsToSquares();

        }

        private void Btn1_Click(object sender, EventArgs e)
        {

            btn1.Hide();
            btn2.Hide();
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Label lb = new Label
                    {
                        BackColor = Color.LightGreen,
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Webdings", 48, FontStyle.Bold),
                        Size = new Size(48, 48),
                        Text = "c"
                    };
                    lb.Click += label1_Click;
                    tlp.Controls.Add(lb, i, j);
                }
            }
            taimer = new Timer();
            taimer.Interval = 750;
            taimer.Tick += Tm_Tick;
            Controls.AddRange(new Control[] { tlp, });
            AssignIconsToSquares();
        }

        private void Tm_Tick(object sender, EventArgs e)
        {
            taimer.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }

        private void AssignIconsToSquares()
        {
            foreach (Control control in tlp.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            if (taimer.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                CheckForWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                taimer.Start();
            }
        }
        private void CheckForWinner()
        {
            foreach (Control control in tlp.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"Insert into mang(nimetus, point, kasutajaID) VALUES('kaks pilti',1,{login.Id})";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            connection.Close();
            MessageBox.Show("Sa sobitasid kõik ikoonid!", "Palju õnne");
            Close();
        
        }
    }
}
