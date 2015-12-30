using System;
namespace TDS
{
    /// <summary>
    /// The 'Product' interface
    /// </summary>
    public interface IEPC
    {
        string uri();
         
    }

    /// <summary   >
    /// A 'ConcreteProduct' class
    /// </summary>
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

            TDS.Global_Location_Number SGLN_Object = new Global_Location_Number("0614141", "12345", "400");
            Type Obj1 = SGLN_Object.GetType();
            string str1 = SGLN_Object.ToString(); 
            SGLN_Object.uri();
            
            Console.ReadKey();

        }
    }
}