using System;
namespace TDS
{
    /// <summary>
    /// The 'Product' interface
    /// </summary>
    public interface IEPC
    {
        void uri(int miles);
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Serial_Shipping_Container_Code : IEPC
    {
        public void uri(int miles)
        {
            Console.WriteLine("uri of the Serial_Shipping_Container_Code : " + miles.ToString() + "km");
        }
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Global_Location_Number : IEPC
    {
        public void uri(int miles)
        {
            Console.WriteLine("uri of the Global_Location_Number : " + miles.ToString() + "km");
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
    /// Factory Pattern Demo
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            EpcFactory factory = new ConcreteEpcFactory();

            IEPC SSCC = factory.GetEpc("Serial_Shipping_Container_Code");
            SSCC.uri(10);

            IEPC SGLN = factory.GetEpc("Global_Location_Number");
            SGLN.uri(20);

            Console.ReadKey();

        }
    }
}
