namespace PassiveView
{
    public interface IShipper
    {
        bool AcceptsInsurance { get;}
        bool CanRequireInsurance { get;}

        string[] Options { get;}
        string Description { get;}
        string Name { get; }

        bool CanCaptureSignature { get; }

        double CalculateCost(Shipment shipment);
    }
}