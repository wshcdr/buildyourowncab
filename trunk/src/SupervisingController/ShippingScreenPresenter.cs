using System;
using System.ComponentModel;

namespace SupervisingController
{
    public class ShippingScreenPresenter
    {
        private readonly IShippingScreen _view;
        private readonly IShippingService _service;
        private Shipment _shipment;

        public ShippingScreenPresenter(IShippingScreen view, IShippingService service) : this(view, service, new Shipment())
        {}

        public ShippingScreenPresenter(IShippingScreen view, IShippingService service, Shipment shipment)
        {
            _view = view;
            _service = service;
            _shipment = shipment;

            // Since we're got the INotifyPropertyChanged interface on Shipment,
            // we might as well use it to trigger updates to the Cost
            _shipment.PropertyChanged += new PropertyChangedEventHandler(_shipment_PropertyChanged);
        }

        private void _shipment_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _service.CalculateCost(_shipment);

            switch (e.PropertyName)
            {
                case "StateOrProvince":
                    LocationChanged();
                    break;
                case "Vendor":
                    VendorChanged();
                    break;
                case "ShippingOption":
                    ShippingOptionChanged();
                    break;
                default:
                    break;
            }

        }

        public Shipment Shipment
        {
            get { return _shipment; }
        }

        public void Start()
        {
            _view.Locations = _service.GetLocations();
            _view.Shipment = _shipment;
        }

        // React to the user selecting a new destination
        public void LocationChanged()
        {
            _view.Vendors = _service.GetShippingVendorsForLocation(_shipment.StateOrProvince);
            if (!String.IsNullOrEmpty(_shipment.Vendor) && !_service.VendorServicesLocation(_shipment))
                _shipment.Vendor = String.Empty;
        }

        // React to the user changing the Vendor
        public void VendorChanged()
        {
            _view.ShippingOptions = _service.GetShippingOptions(_shipment);
            if (!String.IsNullOrEmpty(_shipment.ShippingOption) && !_service.ShippingOptionSupportedByVendor(_shipment))
                _shipment.ShippingOption = String.Empty;
        }

        // React to the user changing the Shipping Option
        public void ShippingOptionChanged()
        {
            DeliveryOptions options = _service.GetDeliveryOptions(_shipment);

            _view.InsuranceEnabled = options.PurchaseInsuranceEnabled;
            if(!options.PurchaseInsuranceEnabled)
                _shipment.PurchaseInsurance = false;
            
            _view.SignatureEnabled = options.RequireSignatureEnabled;
            if(!options.RequireSignatureEnabled)
                _shipment.RequireSignature = false;
        }
    }
}