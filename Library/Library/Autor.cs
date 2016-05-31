using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Autor
    {
        private int id;
        private String name;
        private String surname;

        public Autor(String name, String surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
