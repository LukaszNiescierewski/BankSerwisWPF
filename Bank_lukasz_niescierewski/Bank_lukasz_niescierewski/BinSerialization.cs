using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Bank_lukasz_niescierewski
{
    class BinSerialization : ISerialization
    {
        /* public List<object> Deserialize(string FileName, object things)
         {
             throw new NotImplementedException();
        */
        public void Serialized(string FileName, object things)
        {
            FileStream fs = new FileStream(FileName, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(fs, things);
            fs.Close();
        }

        public void Serialized(string FileName, object things, Type a)
        {
            throw new NotImplementedException();
        }
    }
}
