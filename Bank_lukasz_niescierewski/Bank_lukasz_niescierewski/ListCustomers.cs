using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace Bank_lukasz_niescierewski
{
    
    public class ListCustomers
    {
        private List<Customer> customers = new List<Customer>();
        
        public List<Customer> Customers
        {
            get { return customers; }
        }
        public void Plus(Customer k)
        {
            this.customers.Add(k);
        }
        public void plus(string imie, string nazwisko)
        {
            customers.Add(new Customer(imie, nazwisko));
        }
        public void Remove(Customer k)
        {
            this.customers.Remove(k);
        }
        public void rem(string name, string surname)
        {
            foreach (Customer kl in customers)
            {
                if (kl.Name == name && kl.Surname == surname)
                    customers.Remove(kl);
            }
        }
        public Customer download(string name, string surname)
        {
            foreach (Customer kl in customers)
            {
                if (kl.Name == name && kl.Surname == surname) return kl;
            }
            return null;
        }
        public void Clear()
        {
            this.customers.Clear();
        }
        /*
        public void Serialization ()
        {
            FileStream fs = new FileStream("lista_klinetow.bin", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, customers);
            fs.Close();
        }
          */     
        public override string ToString()
        {
            string s = "";
            foreach (Customer st in customers)
                s = s + st + Environment.NewLine; 
            return s;
        }
   
    }
}
