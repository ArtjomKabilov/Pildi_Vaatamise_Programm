﻿using System;
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
        Timer tm;
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
        public mang2()
        {
            this.Size = new Size(600, 600);
            MaximizeBox = false;
            tlp = new TableLayoutPanel
            {
                BackColor = ColorTranslator.FromHtml("#3333FF"),
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
            };
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
                        BackColor = ColorTranslator.FromHtml("#3333FF"),
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
            tm = new Timer();
            tm.Interval = 750;
            tm.Tick += Tm_Tick;
            Controls.AddRange(new Control[] { tlp, });
            AssignIconsToSquares();
        }

        private void Tm_Tick(object sender, EventArgs e)
        {
            tm.Stop();
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
            if (tm.Enabled == true)
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

                tm.Start();
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

            MessageBox.Show("You matched all the icons!", "Congratulations");
            Close();
        }
        }
    }
}
