namespace PassiveView
{
    public class ShippingScreenPresenter
    {
        private readonly IShippingScreen _screen;
        private readonly IShipperRepository _repository;
        private IShipper _shipper;

        public ShippingScreenPresenter(IShippingScreen screen, IShipperRepository repository)
        {
            _screen = screen;
            _screen.AttachShippingScreenPresenter(this);
            _repository = repository;

            screen.States = repository.GetShippableStates();
            ShipperSelected();
        }

        public void ShipperSelected()
        {
            _shipper = _repository.FindShipper(_screen.Vendor);

            if (_shipper != null)
            {
                PopulateScreenWithShipperOptions();
            }
            else
            {
                RemoveShipperOptionsFromScreen();
            }
        }

        private void RemoveShipperOptionsFromScreen()
        {
            _screen.ShippingOptions = new string[] { };
            _screen.PurchaseInsurance = false;
            _screen.InsuranceEnabled = false;
            _screen.RequireSignature = false;
            _screen.SignatureEnabled = false;
        }

        private void PopulateScreenWithShipperOptions()
        {
            _screen.ShippingOptions = _shipper.Options;

            if (!_shipper.AcceptsInsurance)
                _screen.PurchaseInsurance = false;
            _screen.InsuranceEnabled = _shipper.CanRequireInsurance;

            if (!_shipper.CanCaptureSignature)
                _screen.RequireSignature = false;
            _screen.SignatureEnabled = _shipper.CanCaptureSignature;
        }

        private Shipment createShipmentFromScreen()
        {
            Shipment shipment = new Shipment();
            shipment.PurchaseInsurance = _screen.PurchaseInsurance;
            shipment.StateOrProvince = _screen.StateOrProvince;
            // so on, and so forth

            return shipment;
        }

        public void OptionsChanged()
        {
            Shipment shipment = createShipmentFromScreen();
            if (_shipper != null && shipment != null)
                _screen.Cost = _shipper.CalculateCost(shipment);
            else 
                _screen.Cost = 0;
        }

        public IShippingScreen screen
        {
            get { return _screen; }
        }

        public void StateChanged()
        {
            IShipper[] shippers = _repository.GetShippersForLocation(_screen.StateOrProvince);
            string[] vendors = new string[shippers.Length];
            for (int i = 0; i < shippers.Length; i++)
            {
                vendors[i] = shippers[i].Name;
            }
            _screen.Vendors = vendors;
        }
    }
}