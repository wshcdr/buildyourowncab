namespace PassiveView
{
    public class Shipper : IShipper
    {
        private bool acceptsInsurance;
        private bool canRequireInsurance;
        private string[] options;
        private string description;
        private string name;
        private bool canCaptureSignature;

        //to show calculating to different costs.
        private double multiplier;


        public Shipper( string name, double multiplier, bool acceptsInsurance, bool canRequireInsurance, bool canCaptureSignature)
        {
            this.acceptsInsurance = acceptsInsurance;
            this.canRequireInsurance = canRequireInsurance;
            this.name = name;
            this.canCaptureSignature = canCaptureSignature;
            this.multiplier = multiplier;
        }

        public bool AcceptsInsurance
        {
            get { return acceptsInsurance; }
        }

        public bool CanRequireInsurance
        {
            get { return canRequireInsurance; }
        }

        public string[] Options
        {
            get { return options; }
        }

        public string Description
        {
            get { return description; }
        }

        public string Name
        {
            get { return name; }
        }

        public bool CanCaptureSignature
        {
            get { return canCaptureSignature; }
        }

        public double CalculateCost(Shipment shipment)
        {
            double cost = ToStateCost(shipment.StateOrProvince);
            cost += shipment.PurchaseInsurance ? .5 : 0;
            cost += shipment.RequireSignature ? .25 : 0;
            shipment.Cost = cost * (multiplier > 0 ? multiplier : 1) ;
            return shipment.Cost;
        }

        private double ToStateCost(string province)
        {
            int letterSum = 0;
            foreach (char c in province)
            {
                letterSum += (int) c;
            }
            return letterSum;
        }
    }
}