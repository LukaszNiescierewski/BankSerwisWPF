using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Bank_lukasz_niescierewski
{
    public class ListAccount
    {
        private Dictionary<Account, Customer> account_customer = new Dictionary<Account, Customer>();

        public Dictionary<Account, Customer> List_Account
        {
            get { return this.account_customer; }
        }

        public void Plus (Account kon, Customer kli)
        {
            this.account_customer.Add(kon, kli);
        }

        public void Remove (Account kon)
        {
            this.account_customer.Remove(kon);
        }
        public void Clear()
        {
            this.account_customer.Clear();
        }
       /* public void Serialization()
        {
            FileStream fs = new FileStream("lista_kont.bin", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(fs, this.account_customer);
            fs.Close();
        }*/

    }
}
