using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PassiveView
{
    public partial class ShippingScreen : UserControl, IShippingScreen
    {
        private ShippingScreenPresenter shippingScreenPresenter;

        public ShippingScreen()
        {
            InitializeComponent();
        }
        
        public string[] ShippingOptions
        {
            set
            {
                ShippingOptionsCombo.Text = string.Empty;
                ShippingOptionsCombo.Items.Clear();
                if (value != null)
                    ShippingOptionsCombo.Items.AddRange(value);
            }
        }

        public string[] Vendors
        {
            set
            {
                ShippingVendorCombo.Items.Clear();
                if (value != null)
                    ShippingVendorCombo.Items.AddRange(value);
                if (!ShippingVendorCombo.Items.Contains(ShippingVendorCombo.Text))
                    ShippingVendorCombo.Text = string.Empty;
            }
        }

        public string[] States
        {
            set
            {
                StateOrProvinceCombo.Items.Clear();
                if (value != null)
                    StateOrProvinceCombo.Items.AddRange(value);
                if (!StateOrProvinceCombo.Items.Contains(StateOrProvinceCombo.Text))
                    StateOrProvinceCombo.Text = string.Empty;
            }
        }

        public bool InsuranceEnabled
        {
            set { PurchaseInsuranceCheckBox.Enabled = value; }
        }

        public bool SignatureEnabled
        {
            set { RequireSignatureCheckBox.Enabled = value; }
        }

        public string StateOrProvince
        {
            get { return StateOrProvinceCombo.Text; }
            set { StateOrProvinceCombo.Text = value; }
        }

        public string Vendor
        {
            get { return ShippingVendorCombo.Text; }
            set { ShippingVendorCombo.Text = value; }
        }

        public string ShippingOption
        {
            get { return ShippingOptionsCombo.Text; }
            set { ShippingOptionsCombo.Text = value; }
        }

        public bool PurchaseInsurance
        {
            get { return PurchaseInsuranceCheckBox.Checked; }
            set { PurchaseInsuranceCheckBox.Checked = value; }
        }

        public bool RequireSignature
        {
            get { return RequireSignatureCheckBox.Checked; }
            set { RequireSignatureCheckBox.Checked = value; }
        }

        public double Cost
        {
            get
            {
                double temp;
                double.TryParse(CostTextBox.Text, out temp);
                return temp;
            }
            set { CostTextBox.Text = value.ToString(); }
        }

        public void AttachShippingScreenPresenter(ShippingScreenPresenter presenter)
        {
            shippingScreenPresenter = presenter;
        }

        private void OptionsChanged(object sender, EventArgs e)
        {
            shippingScreenPresenter.OptionsChanged();
        }

        private void StateChanged(object sender, EventArgs e)
        {
            shippingScreenPresenter.StateChanged();
        }

        private void ShipperSelected(object sender, EventArgs e)
        {
            shippingScreenPresenter.ShipperSelected();
            shippingScreenPresenter.OptionsChanged();
        }
    }
}
