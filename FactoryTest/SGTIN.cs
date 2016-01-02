using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace TDS
{

    [Serializable()]
    public class Serialized_Global_Trade_Item_Number : IEPC
    {
        private string _EPC_Scheme;
        private string _CompanyPrefix;
        private string _ItemRef;
        private string _Serial;
        private string _uri;
        public Serialized_Global_Trade_Item_Number(string companyprefix, string itemref, string serial)
        {
            _EPC_Scheme = "sgtin";
            _CompanyPrefix = companyprefix;
            _ItemRef = itemref;
            _Serial = serial;
        }


        public string uri()
        {
            //#if 
            StringBuilder builder = new StringBuilder();
            builder.Append("urn:epc:id:");
            builder.Append(_EPC_Scheme);
            builder.Append(":");
            builder.Append(_CompanyPrefix);
            builder.Append(".");
            builder.Append(_ItemRef);
            builder.Append(".");
            builder.Append(_Serial);
            _uri = builder.ToString();

            _uri = "urn:epc:id:" + _EPC_Scheme + ":" + _CompanyPrefix + "." + _ItemRef + "." + _Serial;
            Console.WriteLine("uri of the Serialized_Global_Trade_Item_Number : " + _uri);
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

        public Serialized_Global_Trade_Item_Number(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties

            _uri = (String)info.GetValue("URI", typeof(string));
        }
        public void uri_save(string filename)
        {
            Stream stream = File.Open(filename, FileMode.OpenOrCreate);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, this);
            stream.Close();
        }

    }

}