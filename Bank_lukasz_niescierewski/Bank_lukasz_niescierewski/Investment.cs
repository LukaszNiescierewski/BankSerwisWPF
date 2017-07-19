using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_lukasz_niescierewski
{
    [Serializable]
    class Investment : Account
    {
        public bool first_time_pay = false;
        public bool first_payoff = false;
        public decimal cash_beginning = 0;
        public decimal sum_payoff = 0;

        public Investment(int number, decimal cash)
        {
            base.n_number = number;
            base.dec_cash = cash;
        }

        public override void Payoff(decimal payoff)
        {
            if (base.dec_cash == 0) // zabezpieczenie przed robieniem wypłat z pustego konta
                return;
            else
            {
                if (!this.first_payoff) // ustalanie salda początkowego przy pierwszej wypłacie
                {
                    this.cash_beginning = base.dec_cash;
                }
                this.first_payoff = true;

                // Zabepieczenie przed wyplata z lokaty większej ilosci środków (max 10%)
                if (payoff <= 0.1M * this.cash_beginning)
                {
                    this.sum_payoff += payoff;
                    if ((base.dec_cash > 0) && (sum_payoff <= 0.1M * this.cash_beginning))
                        base.Payoff(payoff);
                }
            }
        }

        public override void Pay(decimal payment)
        {
            //dokonanie początkowej wpłaty - tylko jedna wpłata
            if(!first_time_pay)
                base.Pay(payment);
            first_time_pay = true;
        }

        public override string ToString()
        {
            return "Lokata " + base.ToString();
        }
    }
}
