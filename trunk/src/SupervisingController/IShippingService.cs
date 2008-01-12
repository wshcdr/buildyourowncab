namespace SupervisingController
{
    public interface IShippingService
    {
        string[] GetLocations();
        string[] GetShippingVendorsForLocation(string location);
        string[] GetShippingOptions(Shipment shipment);
        void CalculateCost(Shipment shipment);
        DeliveryOptions GetDeliveryOptions(Shipment shipment);

        bool VendorServicesLocation(Shipment shipment);
        bool ShippingOptionSupportedByVendor(Shipment shipment);
    }
}