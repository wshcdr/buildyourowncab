namespace HumbleDialogBox
{
    partial class ArrogantView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Dirty = new System.Windows.Forms.CheckBox();
            this.Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Dirty
            // 
            this.Dirty.AutoSize = true;
            this.Dirty.Location = new System.Drawing.Point(34, 12);
            this.Dirty.Name = "Dirty";
            this.Dirty.Size = new System.Drawing.Size(47, 17);
            this.Dirty.TabIndex = 0;
            this.Dirty.Text = "Dirty";
            this.Dirty.UseVisualStyleBackColor = true;
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(12, 43);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(90, 23);
            this.Close.TabIndex = 1;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // ArrogantView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(114, 78);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Dirty);
            this.Name = "ArrogantView";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Dirty;
        private System.Windows.Forms.Button Close;
    }
}

