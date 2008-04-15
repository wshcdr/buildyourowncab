namespace PassiveView
{
    public interface IShipperRepository
    {
        string[] GetShippableStates();
        IShipper[] GetShippersForLocation(string location);
        IShipper FindShipper(string shipperName);
    }
}