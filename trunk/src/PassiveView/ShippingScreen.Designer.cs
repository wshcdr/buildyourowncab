namespace PassiveView
{
    partial class ShippingScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.CostTextBox = new System.Windows.Forms.TextBox();
            this.RequireSignatureCheckBox = new System.Windows.Forms.CheckBox();
            this.PurchaseInsuranceCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ShippingOptionsCombo = new System.Windows.Forms.ComboBox();
            this.ShippingVendorCombo = new System.Windows.Forms.ComboBox();
            this.StateOrProvinceCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Cost";
            // 
            // CostTextBox
            // 
            this.CostTextBox.Location = new System.Drawing.Point(34, 148);
            this.CostTextBox.Name = "CostTextBox";
            this.CostTextBox.ReadOnly = true;
            this.CostTextBox.Size = new System.Drawing.Size(100, 20);
            this.CostTextBox.TabIndex = 28;
            // 
            // RequireSignatureCheckBox
            // 
            this.RequireSignatureCheckBox.AutoSize = true;
            this.RequireSignatureCheckBox.Location = new System.Drawing.Point(6, 117);
            this.RequireSignatureCheckBox.Name = "RequireSignatureCheckBox";
            this.RequireSignatureCheckBox.Size = new System.Drawing.Size(111, 17);
            this.RequireSignatureCheckBox.TabIndex = 27;
            this.RequireSignatureCheckBox.Text = "Require Signature";
            this.RequireSignatureCheckBox.UseVisualStyleBackColor = true;
            this.RequireSignatureCheckBox.CheckedChanged += new System.EventHandler(this.OptionsChanged);
            // 
            // PurchaseInsuranceCheckBox
            // 
            this.PurchaseInsuranceCheckBox.AutoSize = true;
            this.PurchaseInsuranceCheckBox.Location = new System.Drawing.Point(6, 94);
            this.PurchaseInsuranceCheckBox.Name = "PurchaseInsuranceCheckBox";
            this.PurchaseInsuranceCheckBox.Size = new System.Drawing.Size(121, 17);
            this.PurchaseInsuranceCheckBox.TabIndex = 26;
            this.PurchaseInsuranceCheckBox.Text = "Purchase Insurance";
            this.PurchaseInsuranceCheckBox.UseVisualStyleBackColor = true;
            this.PurchaseInsuranceCheckBox.CheckedChanged += new System.EventHandler(this.OptionsChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Shipping Option";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Shipping Vendor";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "State or Province";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ShippingOptionsCombo
            // 
            this.ShippingOptionsCombo.FormattingEnabled = true;
            this.ShippingOptionsCombo.Location = new System.Drawing.Point(98, 60);
            this.ShippingOptionsCombo.Name = "ShippingOptionsCombo";
            this.ShippingOptionsCombo.Size = new System.Drawing.Size(148, 21);
            this.ShippingOptionsCombo.TabIndex = 22;
            this.ShippingOptionsCombo.TextChanged += new System.EventHandler(this.OptionsChanged);
            // 
            // ShippingVendorCombo
            // 
            this.ShippingVendorCombo.FormattingEnabled = true;
            this.ShippingVendorCombo.Location = new System.Drawing.Point(98, 33);
            this.ShippingVendorCombo.Name = "ShippingVendorCombo";
            this.ShippingVendorCombo.Size = new System.Drawing.Size(148, 21);
            this.ShippingVendorCombo.TabIndex = 21;
            this.ShippingVendorCombo.TextChanged += new System.EventHandler(this.ShipperSelected);
            // 
            // StateOrProvinceCombo
            // 
            this.StateOrProvinceCombo.FormattingEnabled = true;
            this.StateOrProvinceCombo.Location = new System.Drawing.Point(98, 6);
            this.StateOrProvinceCombo.Name = "StateOrProvinceCombo";
            this.StateOrProvinceCombo.Size = new System.Drawing.Size(148, 21);
            this.StateOrProvinceCombo.TabIndex = 20;
            this.StateOrProvinceCombo.TextChanged += new System.EventHandler(this.StateChanged);
            // 
            // ShippingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CostTextBox);
            this.Controls.Add(this.RequireSignatureCheckBox);
            this.Controls.Add(this.PurchaseInsuranceCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShippingOptionsCombo);
            this.Controls.Add(this.ShippingVendorCombo);
            this.Controls.Add(this.StateOrProvinceCombo);
            this.Name = "ShippingScreen";
            this.Size = new System.Drawing.Size(252, 176);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CostTextBox;
        private System.Windows.Forms.CheckBox RequireSignatureCheckBox;
        private System.Windows.Forms.CheckBox PurchaseInsuranceCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ShippingOptionsCombo;
        private System.Windows.Forms.ComboBox ShippingVendorCombo;
        public System.Windows.Forms.ComboBox StateOrProvinceCombo;
    }
}
