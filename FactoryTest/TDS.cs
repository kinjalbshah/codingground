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

        public Serial_Shipping_Container_Code()
        {   //test checkin - check out
            _EPC_Scheme = "sscc";
        }
        public void Config(string CompanyPrefix, string SerialReference)
        {
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
        public Global_Location_Number() {
            _EPC_Scheme = "sgln";
        }

        public void Config(string CompanyPrefix, string LocationReference,string Extension)
        {
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
    /// The Creator Abstract Class
    /// </summary>
    public abstract class EpcFactory
    {
        public abstract IEPC GetEpc(string Epc);

    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcreteEpcFactory : EpcFactory
    {
        public override IEPC GetEpc(string Epc)
        {
            switch (Epc)
            {
                case "Serial_Shipping_Container_Code":
                    return new Serial_Shipping_Container_Code();

                case "Global_Location_Number":
                    return new Global_Location_Number();
                default:
                    throw new ApplicationException(string.Format("Epc '{0}' cannot be created", Epc));
            }
        }

    }

    /// <summary>
    /// Factory Pattern 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            EpcFactory factory = new ConcreteEpcFactory();

            /*IEPC SSCC = factory.GetEpc("Serial_Shipping_Container_Code");
            
            string str= SSCC.ToString();
            Type Obj= SSCC.GetType();
            SSCC.uri();
            */

            Serial_Shipping_Container_Code ssc2 =(TDS.Serial_Shipping_Container_Code) factory.GetEpc("Serial_Shipping_Container_Code");
            ssc2.Config("0614141", "1234567890");
            string Shipping_Final_URI= ssc2.uri();
            Type Obj = ssc2.GetType();

            TDS.Global_Location_Number SGLN_Object=(TDS.Global_Location_Number) factory.GetEpc("Global_Location_Number");
            SGLN_Object.Config("0614141", "12345", "400");
            SGLN_Object.uri();
            
            Console.ReadKey();

        }
    }
}