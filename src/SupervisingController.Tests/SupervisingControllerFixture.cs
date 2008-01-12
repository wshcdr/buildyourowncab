using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace SupervisingController.Tests
{
    [TestFixture]
    public class SupervisingControllerFixture
    {
        private MockRepository mocks;
        IShippingService service;
        IShippingScreen screen;
        ShippingScreenPresenter presenter;

        [SetUp]
        public void SetUpTest()
        {
            mocks = new MockRepository();
            service = mocks.CreateMock<IShippingService>();
            screen = mocks.CreateMock<IShippingScreen>();
            presenter = new ShippingScreenPresenter(screen, service);
        }

        [Test]
        public void EnableOrDisableTheInsuranceAndSignatureCheckboxesWhenShippingOptionChanges()
        {
            // Setting up the expected set of Delivery options
            DeliveryOptions deliveryOptions = new DeliveryOptions();
            deliveryOptions.PurchaseInsuranceEnabled = true;
            deliveryOptions.RequireSignatureEnabled = false;

            // Set up the expectations for coordinating both
            // the service and the view
            using (mocks.Record())
            {
                service.CalculateCost(null);
                LastCall.IgnoreArguments();
                Expect.Call(service.GetDeliveryOptions(presenter.Shipment)).Return(deliveryOptions);
                screen.InsuranceEnabled = deliveryOptions.PurchaseInsuranceEnabled;
                screen.SignatureEnabled = deliveryOptions.RequireSignatureEnabled;
            }

            // Perform the work and check the expectations
            using (mocks.Playback())
            {
                presenter.ShippingOptionChanged();
                mocks.VerifyAll();
            }
        }

        [Test]
        public void UpdateTheCostWheneverTheShipmentChanges()
        {
            using (mocks.Record())
            {
                service.GetShippingOptions(null);
                LastCall.IgnoreArguments().Return(new string[] { });
                screen.ShippingOptions = new string[] { };
                service.CalculateCost(presenter.Shipment);
            }

            using (mocks.Playback())
            {
                presenter.Shipment.Vendor = "a different vendor";
            }
        }
    }

    [TestFixture]
    public class ShipmentHasStateSupervisingControllerFixture
    {

        private MockRepository mocks;
        IShippingService service;
        IShippingScreen screen;
        private Shipment shipment;
        ShippingScreenPresenter presenter;

        [SetUp]
        public void SetUpTest()
        {
            shipment = new Shipment();
            shipment.StateOrProvince = "Testville";
            shipment.Vendor = "Test";
            shipment.ShippingOption = "Carrier Pigeon";

            mocks = new MockRepository();
            service = mocks.CreateMock<IShippingService>();
            screen = mocks.CreateMock<IShippingScreen>();
            presenter = new ShippingScreenPresenter(screen, service, shipment);
        }

        [Test]
        public void SetVendorToBlankIfLocationChangesToALocationThatIsNotSupported()
        {
            using (mocks.Record())
            {
                service.CalculateCost(shipment);
                LastCall.IgnoreArguments();

                Expect.Call(service.GetShippingVendorsForLocation(null)).IgnoreArguments().Return(new string[] { });
                screen.Vendors = new string[] { };
                
                service.CalculateCost(shipment);
                LastCall.IgnoreArguments();
                
                Expect.Call(service.VendorServicesLocation(null)).IgnoreArguments().Return(false);

                Expect.Call(service.GetShippingOptions(shipment)).IgnoreArguments().Return(new string[] {});
                screen.ShippingOptions = new string[] {};
                
                Expect.Call(service.ShippingOptionSupportedByVendor(shipment)).Return(false);
                service.CalculateCost(shipment);
                LastCall.IgnoreArguments();
                
                Expect.Call(service.GetDeliveryOptions(shipment)).IgnoreArguments().Return(new DeliveryOptions());

                screen.InsuranceEnabled = false;
                service.CalculateCost(shipment);
                LastCall.IgnoreArguments();

                screen.SignatureEnabled = false;
                service.CalculateCost(shipment);
                LastCall.IgnoreArguments();
            }

            using (mocks.Playback())
            {
                presenter.Shipment.StateOrProvince = "CA";
            }
            
        }
    }
}
