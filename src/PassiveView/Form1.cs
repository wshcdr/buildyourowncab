using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PassiveView
{
    public partial class Form1 : Form
    {
        private ShippingScreenPresenter shippingScreenPresenter;

        public Form1()
        {
            InitializeComponent();
            shippingScreenPresenter = new ShippingScreenPresenter(new ShippingScreen(), new PseudoShipperRepository());
            Controls.Add((Control)shippingScreenPresenter.screen);
        }


    }
}