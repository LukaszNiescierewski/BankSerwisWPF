using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_lukasz_niescierewski
{
    public interface ISerialization
    {
        void Serialized(string FileName, object things, Type a);
        void Serialized(string FileName, object things);
        //List<Object> Deserialize(string FileName, Object things);

    }
}
