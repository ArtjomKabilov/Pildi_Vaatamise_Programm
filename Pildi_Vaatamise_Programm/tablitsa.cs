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
    public partial class tablitsa : Form
    {
        DataGridView dg;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\artem\Source\Repos\Pildi_Vaatamise_Programm\Pildi_Vaatamise_Programm\Database2.mdf;Integrated Security=True";

        public tablitsa()
        {
            this.Size = new Size(500,400);
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"Select nimetus, point, people.nimi from mang, people WHERE mang.kasutajaID = people.Id";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            connection.Close();
            dg = new DataGridView()
            {
                DataSource = dt,
                Size = new Size(400,300)

            };

            this.Controls.Add(dg);
        }
        
    }
}
