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
        void  uri_save(string filename);
         
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
        public void  uri_save(string filename){
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, this);
            stream.Close();
        }

    }

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
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    [Serializable()]
    public class Aerospace_Defense_ID : IEPC
    {
        private string _EPC_Scheme;
        private string _Code;
        private string _Part;
        private string _Serial;
        private string _uri;
        public Aerospace_Defense_ID(string code, string part, string serial) {
            _EPC_Scheme = "adi";
            _Code =  code;
            _Part = part;
            _Serial = serial;
        }

       
        public string uri()
        {
            _uri = "urn:epc:id:" + _EPC_Scheme +":"+ _Code + "." + _Part+"."+_Serial;
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
        public void  uri_save(string filename){
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, this);
            stream.Close();
        }

    }

   

    /// <summary>
    /// Factory Pattern 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            /*
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

            ssc2.uri_save("TDS.txt");

            //Deserialize the values by reading it from the file
            //Open the file written above and read values from it.
            Stream stream = File.Open("TDS.txt", FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();

            Console.WriteLine("Reading Object Information");
            ssc2 = (Serial_Shipping_Container_Code)bformatter.Deserialize(stream);
            stream.Close();

            
            Console.WriteLine("URI from Deserialize", ssc2.uri());
            */

            TDS.Serialized_Global_Trade_Item_Number   SGLN_Object = new Serialized_Global_Trade_Item_Number("0614141", "112345", "400");
            Type Obj1 = SGLN_Object.GetType();
            string str1 = SGLN_Object.ToString();
            SGLN_Object.uri();
            SGLN_Object.uri_save("SGLN.txt");
            Console.ReadKey();

            TDS.Aerospace_Defense_ID ADI_Object = new Aerospace_Defense_ID("W81X9C", "3KL984PX1", "2WMA52");
            Type Obj2 = ADI_Object.GetType();
            string str2 = ADI_Object.ToString();
            ADI_Object.uri();
            ADI_Object.uri_save("ADI.txt");
            Console.ReadKey();

        }
    }
}