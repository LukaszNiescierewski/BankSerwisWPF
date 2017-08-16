using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bank_lukasz_niescierewski
{
    [Serializable]
    public class ROR : Account
    {
        public ROR(int number, decimal cash)
        {
            base.n_number = number;
            base.dec_cash = cash;
        }
        public override void Payoff (decimal payoff)
        {
            if (payoff > dec_cash)
                return;
            else
                dec_cash -= payoff;     
        }
        public override string ToString()
        {
            return "ROR " + base.ToString();
        }

    }
}
