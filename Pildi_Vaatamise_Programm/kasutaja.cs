using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pildi_Vaatamise_Programm
{
    internal class kasutaja
    {
        public class User
        {
            public int id { get; set; }
            public string nimi { get; set; }
            public string sugu { get; set; }
            public string email { get; set; }
            public int vanus { get; set; }
            public string password { get; set; }

        }
    }
}
