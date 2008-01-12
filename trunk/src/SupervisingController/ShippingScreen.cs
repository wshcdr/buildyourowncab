using System.ComponentModel;
using System.Windows.Forms;

namespace SupervisingController
{
    public partial class ShippingScreen : Form, IShippingScreen
    {
        ShippingScreenPresenter presenter;

        public ShippingScreen()
        {
            InitializeComponent();

            presenter = new ShippingScreenPresenter(this, new ShippingService());

            presenter.Start();
        }

        public Shipment Shipment
        {
            set
            {
                StateOrProvinceCombo.DataBindings.Add("Text", presenter.Shipment, "StateOrProvince", false, DataSourceUpdateMode.OnPropertyChanged);
                ShippingVendorCombo.DataBindings.Add("Text", presenter.Shipment, "Vendor", false, DataSourceUpdateMode.OnPropertyChanged);
                ShippingOptionsCombo.DataBindings.Add("Text", presenter.Shipment, "ShippingOption", false, DataSourceUpdateMode.OnPropertyChanged);
                PurchaseInsuranceCheckBox.DataBindings.Add("Checked", presenter.Shipment, "PurchaseInsurance", false, DataSourceUpdateMode.OnPropertyChanged);
                RequireSignatureCheckBox.DataBindings.Add("Checked", presenter.Shipment, "RequireSignature", false, DataSourceUpdateMode.OnPropertyChanged);
                CostTextBox.DataBindings.Add("Text", presenter.Shipment, "Cost", false, DataSourceUpdateMode.OnPropertyChanged);
            }
        }

        public string[] Locations
        {
            set { FillComboBox(value, StateOrProvinceCombo); }
        }

        public string[] Vendors
        {
            set { FillComboBox(value, ShippingVendorCombo); }
        }

        public string[] ShippingOptions
        {
            set { FillComboBox(value, ShippingOptionsCombo);}
        }

        protected void FillComboBox(string[] options, ComboBox box)
        {
            box.Items.Clear();
            box.Items.AddRange(options);
        }

        public bool InsuranceEnabled
        {
            set { PurchaseInsuranceCheckBox.Enabled = value; }
        }
        public bool SignatureEnabled
        {
            set { RequireSignatureCheckBox.Enabled = value; }
        }
    }
}