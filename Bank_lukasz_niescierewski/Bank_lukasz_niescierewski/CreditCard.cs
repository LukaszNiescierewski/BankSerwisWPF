using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bank_lukasz_niescierewski
{
    [Serializable]
    public class CreditCard : Account
    {
        public bool what_cash = false;
        public decimal cash_beginning=0;

        public CreditCard()
        {
            base.n_number = 0;
            base.dec_cash = 0;
        }

        public CreditCard(int number, decimal cash)
        {
            base.n_number = number;
            base.dec_cash = cash;
        }

        public override void Pay(decimal payment)
        {
            if (!this.what_cash)
            {
                this.cash_beginning = base.dec_cash;
            }
            this.what_cash = true;

            //Spłacanie tylko do wysokości zaciągniętego kredytu
            if ((base.dec_cash + payment) > cash_beginning)
                return;
            else
                base.Pay(payment);   
        }

        public override void Payoff(decimal payoff)
        {
            if (!this.what_cash)
            {
                this.cash_beginning = base.dec_cash;
            }
            this.what_cash = true;

            base.Payoff(payoff);
        }

        public override string ToString()
        {
            return "Karta kredytowa " + base.ToString();
        }
    }
}
