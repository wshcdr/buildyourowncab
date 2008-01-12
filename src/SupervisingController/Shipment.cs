using System.ComponentModel;

namespace SupervisingController
{
    public class Shipment : INotifyPropertyChanged
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
            set
            {
                _shippingOption = value;
                fireChanged("ShippingOption");
            }
        }

        public bool PurchaseInsurance
        {
            get { return _purchaseInsurance; }
            set
            {
                _purchaseInsurance = value;
                fireChanged("PurchaseInsurance");
            }
        }

        public bool RequireSignature
        {
            get { return _requireSignature; }
            set
            {
                _requireSignature = value;
                fireChanged("RequireSignature");
            }
        }

        public double Cost
        {
            get { return _cost; }
            set
            {
                _cost = value;
            }
        }

        public string StateOrProvince
        {
            get { return _stateOrProvince; }
            set
            {
                _stateOrProvince = value;
                fireChanged("StateOrProvince");
            }
        }

        public string Vendor
        {
            get { return _vendor; }
            set
            {
                _vendor = value;
                fireChanged("Vendor");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void fireChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}