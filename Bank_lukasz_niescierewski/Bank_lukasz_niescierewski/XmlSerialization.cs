using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Bank_lukasz_niescierewski
{
    class XmlSerialization : ISerialization
    {
        public void Serialized(string FileName, object things)
        {
            throw new NotImplementedException();
        }

        public void Serialized(string FileName, object things, Type a )
        {
            XmlSerializer xs = new XmlSerializer(a);
            TextWriter sw = null;
            try
            {
                sw = new StreamWriter(FileName);
                xs.Serialize(sw, things);
            }/*
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Błąd!", MessageBoxButton.OK ,MessageBoxImage.Error);
            }*/
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }
    }
}
