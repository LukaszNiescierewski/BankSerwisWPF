using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bank_lukasz_niescierewski
{
    [Serializable]
    public class Account
    {
        protected int n_number;
        protected Decimal dec_cash;

        public Account()
        {
            this.n_number = 0;
            this.dec_cash=0;
        }

        public Account (int n_number, decimal dec_cash)
        {
            this.n_number = n_number;
            this.dec_cash = dec_cash;
        }
        
        public virtual void Pay (decimal payment)
        {
            this.dec_cash += payment;
        }

        public virtual void Payoff (decimal payoff)
        {
            this.dec_cash -= payoff;
        }

        public int Number
        {
            get { return n_number; }
            set { n_number = value; }
        }

        public decimal Cash
        {
            get { return dec_cash; }
            set { dec_cash = value; }
        }
        
        public override string ToString()
        {
            string s = "";
            s = "nr: " + this.n_number + " saldo: " + this.dec_cash + "zł";
            return s;
        }
    }
}
