namespace SupervisingController
{
    public class ShippingService : IShippingService
    {
        private string[] _locations = new string[] { "AZ", "CA", "MA", "NY", "TX", "WA" };
        public string[] GetLocations()
        {
            return _locations;
        }

        public string[] GetShippingVendorsForLocation(string location)
        {
            switch (location)
            {
                case "AZ":
                    return new string[] {"Arizona Courier", "FedEx", "USPS"};
                case "CA":
                    return new string[] { "California Courier", "DHL", "FedEx", "UPS", "USPS" };
                case "MA":
                    return new string[] { "Massachusetts Courier", "DHL", "FedEx", "UPS", "USPS" };
                case "NY":
                    return new string[] { "New York Courier", "USPS" };
                case "TX":
                    return new string[] { "Texas Courier", "FedEx", "UPS" };
                case "WA":
                    return new string[] { "Washington Courier" };
                default:
                    return new string[] {};
            }
        }

        public string[] GetShippingOptions(Shipment shipment)
        {
            if (string.IsNullOrEmpty(shipment.Vendor))
                return new string[] {};

            if(shipment.Vendor.EndsWith("Courier"))
                return new string[] {"Bicycle", "Car"};

            switch(shipment.Vendor.ToUpper())
            {
                case "DHL":
                    return new string[] { "Van", "Truck", "Air"};
                case "FEDEX":
                    return new string[] { "Semi", "Air"};
                case "UPS":
                    return new string[] { "Train", "Air"};
                case "USPS":
                    return new string[] { "Air", "Truck", "Trailer"};
                default:
                    return new string[]{};
            }
        }

        public void CalculateCost(Shipment shipment)
        {
            double cost = ToStateCost(shipment.StateOrProvince);
            cost += CourierCost(shipment.Vendor);
            cost += shipment.PurchaseInsurance ? .5 : 0;
            cost += shipment.RequireSignature ? .25 : 0;
            shipment.Cost = cost;
        }

        private double CourierCost(string vendor)
        {
            if (string.IsNullOrEmpty(vendor))
                return 0;

            if (vendor.EndsWith("Courier"))
                return 50;

            switch(vendor.ToUpper())
            {
                case "DHL":
                    return 10;
                case "FEDEX":
                    return 20;
                case "UPS":
                    return 30;
                case "USPS":
                    return 40;
                default:
                    return 0;
            }
        }

        private double ToStateCost(string province)
        {
            for (int i = 0; i < _locations.Length; i++)
            {
                if (_locations[i] == province)
                    return i + 1;
            }
            return 0;
        }

        public DeliveryOptions GetDeliveryOptions(Shipment shipment)
        {
            DeliveryOptions options = new DeliveryOptions();
            if(shipment.Vendor == "USPS")
            {
                options.PurchaseInsuranceEnabled = false;
                options.RequireSignatureEnabled = false;
            } 
            else
            {
                options.PurchaseInsuranceEnabled = true;
                options.RequireSignatureEnabled = true;
            }
            return options;
        }

        public bool VendorServicesLocation(Shipment shipment)
        {
            foreach(string vendor in GetShippingVendorsForLocation(shipment.StateOrProvince))
            {
                if(vendor.Equals(shipment.Vendor))
                    return true;
            }
            return false;
        }

        public bool ShippingOptionSupportedByVendor(Shipment shipment)
        {
            foreach(string shippingOption in GetShippingOptions(shipment))
            {
                if(shippingOption.Equals(shipment.ShippingOption))
                    return true;
            }
            return false;
        }
    }
}