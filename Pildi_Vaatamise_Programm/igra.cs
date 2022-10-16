using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pildi_Vaatamise_Programm
{
    internal class igra
    {
        public int Id { get; set; }
        public string nimetus { get; set; }
        public int point { get; set; }
        public int kasutajaID { get; set; }
        public User kasutaja { get; set; }
    }
}
