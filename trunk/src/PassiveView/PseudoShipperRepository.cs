using System.Collections.Generic;

namespace PassiveView
{
    public class PseudoShipperRepository : IShipperRepository
    {
        private readonly IShipper fedEx;
        private readonly IShipper ups;
        private readonly IShipper dhl;

        public PseudoShipperRepository()
        {
            fedEx = new Shipper("FedEx", 1, true, true, true);

            ups = new Shipper("UPS", 2, false, false, true);

            dhl = new Shipper("DHL", 3, true, true, false);
        }

        public string[] GetShippableStates()
        {
            return new string[]{"CA", "NY", "TX", "WA"};
        }

        public IShipper[] GetShippersForLocation(string location)
        {
            List<IShipper> shippers = new List<IShipper>();
            
            switch(location)
            {
                case "CA":
                    shippers.Add(fedEx);
                    shippers.Add(ups);
                    shippers.Add(dhl);
                    break;
                case "NY":
                    shippers.Add(ups);
                    shippers.Add(dhl);
                    break;
                case "TX":
                    shippers.Add(fedEx);
                    shippers.Add(dhl);
                    break;
                case "WA":
                    shippers.Add(fedEx);
                    shippers.Add(ups);
                    break;
                default:
                    break;
            }
            return shippers.ToArray();
        }

        public IShipper FindShipper(string shipperName)
        {
            switch(shipperName.ToUpper())
            {
                case "FEDEX":
                    return fedEx;
                case "UPS":
                    return ups;
                case "DHL":
                    return dhl;
                default:
                    return null;
            }
        }
    }
}