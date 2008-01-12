namespace SupervisingController
{
    public interface IShippingScreen
    {
        Shipment Shipment { set; }
        string[] Locations { set; }
        string[] Vendors { set; }
        string[] ShippingOptions { set; }
        bool InsuranceEnabled { set; }
        bool SignatureEnabled { set; }
    }
}