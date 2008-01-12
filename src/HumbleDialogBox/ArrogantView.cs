using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HumbleDialogBox
{
    public partial class ArrogantView : Form, IHumbleView
    {
        private readonly OverseerPresenter presenter;

        public ArrogantView()
        {
            InitializeComponent();
            presenter = new OverseerPresenter(this);
        }

        public bool IsDirty()
        {
            return Dirty.Checked;
        }

        public bool AskUserToDiscardChanges()
        {
            return MessageBox.Show("'Ok' to discard changes or 'Cancel' to keep working", "Lose changes?", 
                MessageBoxButtons.OKCancel) == DialogResult.OK;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            presenter.Close();
        }
    }
}