using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace TDS
{

    [Serializable()]
    public class Aerospace_Defense_ID : IEPC
    {
        private string _EPC_Scheme;
        private string _Code;
        private string _Part;
        private string _Serial;
        private string _uri;
        public Aerospace_Defense_ID(string code, string part, string serial)
        {
            _EPC_Scheme = "adi";
            _Code = code;
            _Part = part;
            _Serial = serial;
        }


        public string uri()
        {
            // This block needs to be in #if for net framework , Stringbuilder is more efficent then string
            StringBuilder builder = new StringBuilder();
            builder.Append("urn:epc:id:");
            builder.Append(_EPC_Scheme);
            builder.Append(":");
            builder.Append(_Code);
            builder.Append(".");
            builder.Append(_Part);
            builder.Append(".");
            builder.Append(_Serial);
            _uri = builder.ToString();


            _uri = "urn:epc:id:" + _EPC_Scheme + ":" + _Code + "." + _Part + "." + _Serial;
            Console.WriteLine("uri of the Aerospace_Defense_ID : " + _uri);
            return _uri;
        }

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("URI", _uri);
        }

        public Aerospace_Defense_ID(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties

            _uri = (String)info.GetValue("URI", typeof(string));
        }
        public void uri_save(string filename)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, this);
            stream.Close();
        }

    }
}