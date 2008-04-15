using System.ComponentModel;

namespace PassiveView
{
    public class Shipment
    {
        private double _cost;
        private bool _purchaseInsurance;
        private bool _requireSignature;
        private string _shippingOption;
        private string _stateOrProvince;
        private string _vendor;

        public string ShippingOption
        {
            get { return _shippingOption; }
            set { _shippingOption = value; }
        }

        public bool PurchaseInsurance
        {
            get { return _purchaseInsurance; }
            set { _purchaseInsurance = value; }
        }

        public bool RequireSignature
        {
            get { return _requireSignature; }
            set { _requireSignature = value; }
        }

        public double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        public string StateOrProvince
        {
            get { return _stateOrProvince; }
            set { _stateOrProvince = value; }
        }

        public string Vendor
        {
            get { return _vendor; }
            set { _vendor = value; }
        }
    }
}