namespace PassiveView
{
    public interface IShippingScreen
    {
        string[] ShippingOptions { set; }
        string[] Vendors { set; }
        string[] States { set; }

        bool InsuranceEnabled { set; }
        bool SignatureEnabled { set; }

        string StateOrProvince { get; set;}
        string Vendor { get; set;}
        string ShippingOption { get; set;}
        bool PurchaseInsurance { get; set;}
        bool RequireSignature { get; set;}
        double Cost { get; set;}
        void AttachShippingScreenPresenter(ShippingScreenPresenter presenter);
    }
}