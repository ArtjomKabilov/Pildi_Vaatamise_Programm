using Microsoft.Data.SqlClient;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Pildi_Vaatamise_Programm
{
    public partial class mang : Form
    {
        TableLayoutPanel tl;
        Random rnd = new Random();
        char[] sümbolid = new char[] { '+', '-', '*', '/' };
        int plussÜks, plussKaks;
        int korrutadaÜks, korrutadaKaks;
        int jagaÜks, jagaKaks;
        int miinusÜks, miinusKaks;
        int aega_jäänud;
        Timer timer;
        Label lb;
        Button start, btn;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\artem\Source\Repos\Pildi_Vaatamise_Programm\Pildi_Vaatamise_Programm\Database2.mdf;Integrated Security=True";

        public mang()
        {
            this.Size = new Size(500, 400);
            this.Name = "Matemaatiline äraarvamismäng";
            tl = new TableLayoutPanel()
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                AutoSize = true,
                Location = new System.Drawing.Point(0, 0),
                ColumnCount = 5,
                RowCount = 4,
                TabIndex = 0,
                BackColor = System.Drawing.Color.White
            };

            tl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle
                (System.Windows.Forms.SizeType.Percent, 40F));
            tl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle
                (System.Windows.Forms.SizeType.Percent, 40F));
            tl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle
                (System.Windows.Forms.SizeType.Percent, 40F));
            tl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle
                (System.Windows.Forms.SizeType.Percent, 40F));
            tl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle
                (System.Windows.Forms.SizeType.Percent, 40F));

            tl.RowStyles.Add(new System.Windows.Forms.RowStyle
                (System.Windows.Forms.SizeType.Absolute, 40F));
            tl.RowStyles.Add(new System.Windows.Forms.RowStyle
                (System.Windows.Forms.SizeType.Absolute, 40F));
            tl.RowStyles.Add(new System.Windows.Forms.RowStyle
                (System.Windows.Forms.SizeType.Absolute, 40F));
            tl.RowStyles.Add(new System.Windows.Forms.RowStyle
                (System.Windows.Forms.SizeType.Absolute, 40F));

            lb = new Label
            {
                Font = new Font(Font.FontFamily, 18),
                AutoSize = false,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(200, 30),
                BackColor = Color.White
            };
            Label label = new Label
            {
                Font = new Font(Font.FontFamily, (float)15.75),
                Text = "Aega jäänud",
                AutoSize = true,
               
            };
            start = new Button
            {
                Text = "Alustage viktoriini",
                Font = new Font(Font.FontFamily, 14),
                AutoSize = true,
                TabIndex = 0,
                BackColor = Color.White

            };
            btn = new Button()
            {
                Text = "Uus formi värv",
                AutoSize = true,
                TabIndex = 0,
                BackColor = Color.White

            };
            btn.Click += Btn_Click;
            start.Click += Start_Click;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            for (int i = 1; i < 5; i++)
            {
                Label num1 = new Label
                {
                    Font = new Font(FontFamily.GenericSansSerif, 18),
                    Text = "?",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(50, 60),
                };
                Label znak = new Label
                {
                    Font = new Font(FontFamily.GenericSansSerif, 18),
                    Text = sümbolid[i - 1].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(50, 60),
                };
                Label num2 = new Label
                {
                    Font = new Font(FontFamily.GenericSansSerif, 18),
                    Text = "?",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(50, 60),
                };
                Label ravno = new Label
                {
                    Font = new Font(FontFamily.GenericSansSerif, 18),
                    Text = "=",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(50, 60),
                };
                NumericUpDown X = new NumericUpDown
                {
                    Font = new Font(FontFamily.GenericSansSerif, 18),
                    Width = 100,
                    TabIndex = i + 1,
                };
                tl.Controls.Add(num1, 0, i);
                tl.Controls.Add(znak, 1, i);
                tl.Controls.Add(num2, 2, i);
                tl.Controls.Add(ravno, 3, i);
                tl.Controls.Add(X, 4, i);
            }
            tl.Controls.Add(lb, 3, 0);
            tl.SetColumnSpan(label, 2);
            tl.SetColumnSpan(lb, 2);
            tl.Controls.Add(label, 1, 0);

            tl.SetColumnSpan(start, 2);
            tl.Controls.Add(start, 2, 5);
            tl.SetColumnSpan(btn, 2);
            tl.Controls.Add(btn, 2, 5);
            Controls.Add(tl);


        }

        private void Btn_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.Color = tl.ForeColor;
            if (MyDialog.ShowDialog() == DialogResult.OK)
                tl.BackColor = MyDialog.Color;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            NumericUpDown X = (NumericUpDown)tl.GetControlFromPosition(4, 1);
            NumericUpDown minX = (NumericUpDown)tl.GetControlFromPosition(4, 2);
            NumericUpDown mulX = (NumericUpDown)tl.GetControlFromPosition(4, 3);
            NumericUpDown divX = (NumericUpDown)tl.GetControlFromPosition(4, 4);
            if (CheckTheAnswer())
            {
                timer.Stop();
                MessageBox.Show("Teil on kõik vastused õiged!",
                                 "Palju õnne!");
                start.Enabled = true;
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"Insert into mang(nimetus, point, kasutajaID) VALUES('matemaatika',1,{login.Id})";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                connection.Close();
            }
            else if (aega_jäänud > 0)
            {
                aega_jäänud = aega_jäänud - 1;
                lb.Text = aega_jäänud + " sekundit";
            }
            else
            {
                timer.Stop();
                lb.Text = "Aeg on läbi!";
                MessageBox.Show("Sa ei lõpetanud õigeks ajaks.", "Vabandust!");
                X.Value = plussÜks + plussKaks;
                minX.Value = miinusÜks - miinusKaks;
                mulX.Value = korrutadaÜks * korrutadaKaks;
                divX.Value = jagaÜks / jagaKaks;
                start.Enabled = true;
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            start.Enabled = false;
        }
        private bool CheckTheAnswer()
        {
            NumericUpDown X = (NumericUpDown)tl.GetControlFromPosition(4, 1);
            NumericUpDown minX = (NumericUpDown)tl.GetControlFromPosition(4, 2);
            NumericUpDown mulX = (NumericUpDown)tl.GetControlFromPosition(4, 3);
            NumericUpDown divX = (NumericUpDown)tl.GetControlFromPosition(4, 4);
            if ((plussÜks + plussKaks == X.Value)
                && (miinusÜks - miinusKaks == minX.Value)
                && (korrutadaÜks * korrutadaKaks == mulX.Value)
                && (jagaÜks / jagaKaks == divX.Value))
                return true;
            else
                return false;
        }

        public void StartTheQuiz()
        {
            for (int row = 1; row < 5; row++)
            {
                Label num1 = (Label)tl.GetControlFromPosition(0, row);
                Label symbol = (Label)tl.GetControlFromPosition(1, row);
                Label num2 = (Label)tl.GetControlFromPosition(2, row);
                NumericUpDown N = (NumericUpDown)tl.GetControlFromPosition(4, row);
                int[] thing = getNums(symbol.Text);
                num1.Text = thing[0].ToString();
                num2.Text = thing[1].ToString();
                N.Value = 0;
            }
            aega_jäänud = 30;
            lb.Text = "30 sekundit";
            timer.Start();
        }

        public int[] getNums(string summ)
        {
            int num1 = 0;
            int num2 = 0;

            if (summ == "+")
            {
                num1 = rnd.Next(51);
                num2 = rnd.Next(51);
                plussÜks = num1;
                plussKaks = num2;
            }
            else if (summ == "-")
            {
                num1 = rnd.Next(1, 101);
                num2 = rnd.Next(1, num1);
                miinusÜks = num1;
                miinusKaks = num2;
            }
            else if (summ == "/")
            {
                num2 = rnd.Next(2, 11);
                int temporaryQuotient = rnd.Next(2, 11);
                num1 = num2 * temporaryQuotient;
                jagaÜks = num1;
                jagaKaks = num2;
            }
            else if (summ == "*")
            {
                num1 = rnd.Next(2, 11);
                num2 = rnd.Next(2, 11);
                korrutadaÜks = num1;
                korrutadaKaks = num2;
            }

            return new int[2] { num1, num2 };
        }
    }
}