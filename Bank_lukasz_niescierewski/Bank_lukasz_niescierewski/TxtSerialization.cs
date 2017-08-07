using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_lukasz_niescierewski
{
    class TxtSerialization : ISerialization
    {
        public void Serialized(string FileName, object things)
        {
            StreamWriter sw = new StreamWriter(FileName);
            sw.WriteLine(things.ToString());
            sw.Close();
        }
    }
}
