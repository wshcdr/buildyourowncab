namespace SupervisingController
{
    public class DeliveryOptions
    {
        private bool _purchaseInsuranceEnabled;
        private bool _requireSignatureEnabled;

        public bool PurchaseInsuranceEnabled
        {
            get { return _purchaseInsuranceEnabled; }
            set { _purchaseInsuranceEnabled = value; }
        }

        public bool RequireSignatureEnabled
        {
            get { return _requireSignatureEnabled; }
            set { _requireSignatureEnabled = value; }
        }
    }
}