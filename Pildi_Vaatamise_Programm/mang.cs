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
        NumericUpDown nud, nud2, nud3, nud4;
        Label lbl5;
        Button btn;
        Label textLabel;
        string text;
        // Create a Random object called randomizer 
        // to generate random numbers.
        Random randomizer = new Random();

        Timer timer;
        Stopwatch sw;
        public mang()
        {
            string[] tehed = new string[4] { "+", "-", "/", "*" };

            this.Size = new Size(500, 400);
            this.Name = "Matemaatiline äraarvamismäng";
            tl = new TableLayoutPanel()
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                AutoSize = true,
                Location = new System.Drawing.Point(0, 0),
                ColumnCount = 5,
                RowCount = 5,
                TabIndex = 0,
                BackColor = System.Drawing.Color.White
            };
            /*
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
                            (System.Windows.Forms.SizeType.Absolute, 40F));*/
            nud = new NumericUpDown()
            {
                Font = new Font("Times New Roman", 18f),
                Size = new Size(100, 40),
                Name = "sum"
            };
            nud2 = new NumericUpDown()
            {
                Font = new Font("Times New Roman", 18f),
                Size = new Size(100, 40),
                Name = "sum"
            };
            nud3 = new NumericUpDown()
            {
                Font = new Font("Times New Roman", 18f),
                Size = new Size(100, 40),
                Name = "sum"
            };
            nud4 = new NumericUpDown()
            {
                Font = new Font("Times New Roman", 18f),
                Size = new Size(100, 40),
                Name = "sum"
            };
            var l_nimed = new string[5, 4];
            for (int i = 0; i < 4; i++)
            {
                tl.RowStyles.Add(new System.Windows.Forms.RowStyle
               (System.Windows.Forms.SizeType.Absolute, 40F));
                for (int j = 0; j < 5; j++)
                {
                    tl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle
                    (System.Windows.Forms.SizeType.Percent, 40F));
                    var l_nimi = "L" + j.ToString() + i.ToString();
                    l_nimed[j, i] = l_nimi;
                    if (j == 1) { text = tehed[i]; }
                    else if (j == 3) { text = "="; }
                    // else if (j == 4) { nud = new NumericUpDown { }; }
                    else { text = "?"; }
                    Label l = new Label { Text = text };

                    if (j == 4 && i == 0)
                    {
                        tl.Controls.Add(nud, j, i);
                    }
                    else if (j == 4 && i == 1)
                    {
                        tl.Controls.Add(nud2, j, i);
                    }
                    else if (j == 4 && i == 2)
                    {
                        tl.Controls.Add(nud3, j, i);
                    }
                    else if (j == 4 && i == 3)
                    {
                        tl.Controls.Add(nud4, j, i);
                    }
                    else
                    {
                        tl.Controls.Add(l, j, i);
                    }




                }
            }


            btn = new Button()
            {
                Font = new Font("Times New Roman", 15.75f),
                Text = "Alusta",
                Size = new Size(200, 60),
                Location = new Point(100, 250),
            };
            lbl5 = new Label()
            {
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                AutoSize = false,
                Size = new Size(200, 50),
                Text = "asdasdsa",
                Font = new Font("Times New Roman", 15.75f),
                Location = new Point(150, 150),
                Name = "timeLabel"
            };
            textLabel = new Label()
            {
                Font = new Font("Times New Roman", 15.75f),
                Location = new Point(50, 150),
                Name = "timeLabel",
                Text = "Time Left"
            };
            btn.Click += Btn_Click;

            //tl.Controls.Add(nud, 4, 4);


            this.Controls.Add(lbl5);
            this.Controls.Add(btn);
            this.Controls.Add(textLabel);
            this.Controls.Add(tl);
        }
        
        private void Btn_Click(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = (30000);
            timer.Tick += new EventHandler(timer_Tick);
            sw = new Stopwatch();
            timer.Start();
            sw.Start();

            // start processing emails

            // when finished 
            timer.Stop();
            sw.Stop();
            lbl5.Text = "Completed in " + sw.Elapsed.Seconds.ToString() + " seconds";
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            lbl5.Text = "Running for " + sw.Elapsed.Seconds.ToString() + " seconds";
            Application.DoEvents();
        }
    }
}
