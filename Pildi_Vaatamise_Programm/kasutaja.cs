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
            public int ID { get; set; }
            public string Nimi;
            public string Sugu;
            public string Email;
            public int vanus;
            public string password;

            public string Fname
            {
                get { return Nimi; }
                set { Nimi = value; }
            }

            public string Lname
            {
                get { return Sugu; }
                set { Sugu = value; }
            }

            public string Username
            {
                get { return Email; }
                set { Email = value; }
            }
            public int vozrast
            {
                get { return vanus; }
                set { vanus = value; }
            }

            public string Password
            {
                get { return password; }
                set { password = value; }
            }

            public User() { }

            public User(string fname, string lname,string username, string vozrast, string password)
            {
                this.Nimi = fname;
                this.Sugu = lname;
                this.Email = username;

                this.password = password;
            }

        }
    }
}
