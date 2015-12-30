using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace TDS
{
    /// <summary>
    /// The 'Product' interface
    /// </summary>
    public interface IEPC : ISerializable
    {
        string uri();
         
    }

    /// <summary   >
    /// A 'ConcreteProduct' class
    /// </summary>
    [Serializable()]
    public class Serial_Shipping_Container_Code : IEPC
    {
        private string _EPC_Scheme;
        private string _CompanyPrefix;
        private string _SerialReference;
        private string _uri;

        public Serial_Shipping_Container_Code(string CompanyPrefix, string SerialReference)
        {   //test checkin - check out
            _EPC_Scheme = "sscc";
            _CompanyPrefix = CompanyPrefix;
            _SerialReference = SerialReference;
        }
        
        public string uri()
        {
            _uri= "urn:epc:id:"+_EPC_Scheme+"." + _CompanyPrefix + "." + _SerialReference;

            
            Console.WriteLine("uri of the Serial_Shipping_Container_Code : " +_uri);
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

        public Serial_Shipping_Container_Code(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            
            _uri= (String)info.GetValue("URI", typeof(string));
        }

    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Global_Location_Number : IEPC
    {
        private string _EPC_Scheme;
        private string _CompanyPrefix;
        private string _LocationReference;
        private string _Extension;
        private string _uri;
        public Global_Location_Number(string CompanyPrefix, string LocationReference, string Extension) {
            _EPC_Scheme = "sgln";
            _CompanyPrefix = CompanyPrefix;
            _LocationReference = LocationReference;
            _Extension = Extension;
        }

       
        public string uri()
        {
            _uri = "urn:epc:id:" + _EPC_Scheme +":"+ _CompanyPrefix + "." + _LocationReference+"."+_Extension;
            Console.WriteLine("uri of the Global_Location_Number : " + _uri);
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

        public Global_Location_Number(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties

            _uri = (String)info.GetValue("URI", typeof(string));
        }

    }

   

    /// <summary>
    /// Factory Pattern 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {


            //Serial_Shipping_Container_Code ssc2 =(TDS.Serial_Shipping_Container_Code) factory.GetEpc("Serial_Shipping_Container_Code");
            Serial_Shipping_Container_Code ssc2 = new Serial_Shipping_Container_Code("0614141", "1234567890");
            
            string Shipping_Final_URI= ssc2.uri();
            string str = ssc2.ToString(); 
            Type Obj = ssc2.GetType();

            //Serialize the object to a sample file
            // Open a file and serialize the object into it in binary format.
            // EmployeeInfo.osl is the file that we are creating. 
            // Note:- you can give any extension you want for your file
            // If you use custom extensions, then the user will now 
            //   that the file is associated with your program.
            Stream stream = File.Open("TDS.txt", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();

            Console.WriteLine("Writing object Information");
            bformatter.Serialize(stream, ssc2);
            stream.Close();

            //Deserialize the values by reading it from the file
            //Open the file written above and read values from it.
            stream = File.Open("TDS.txt", FileMode.Open);
            bformatter = new BinaryFormatter();

            Console.WriteLine("Reading Object Information");
            ssc2 = (Serial_Shipping_Container_Code)bformatter.Deserialize(stream);
            stream.Close();

            
            Console.WriteLine("URI from Deserialize", ssc2.uri());

            TDS.Global_Location_Number SGLN_Object = new Global_Location_Number("0614141", "12345", "400");
            Type Obj1 = SGLN_Object.GetType();
            string str1 = SGLN_Object.ToString(); 
            SGLN_Object.uri();
            
            Console.ReadKey();

        }
    }
}