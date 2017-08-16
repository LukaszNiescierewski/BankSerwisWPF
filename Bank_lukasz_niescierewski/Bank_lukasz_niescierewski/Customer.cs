using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bank_lukasz_niescierewski
{
    
    [Serializable]
    public class Customer
    {
        private string str_surname;
        private string str_name;

      
        public Customer (string str_surname, string str_name)
        {
            this.str_surname = str_surname;
            this.str_name = str_name;
        }
        public Customer ()
        {
            this.str_name = "aaa";
            this.str_surname = "bbb";
        }
        
        public string Name
        {
            get { return str_name; }
            set { str_name = value; }
        }
        
        public string Surname
        {
            get { return str_surname; }
            set { str_surname = value; }
        }

        public override string ToString()
        {
            string s = "";
            s = this.str_surname + " " + this.str_name;
            return s;
        }
    }
}
