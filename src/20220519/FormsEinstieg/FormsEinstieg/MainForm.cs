using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsEinstieg
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btt_accept_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_input.Text))
            {
                return;
            }

            lbl_header.Text = txt_input.Text;
            txt_input.Text = string.Empty;
        }

        private void btt_cancel_Click(object sender, EventArgs e)
        {
            txt_input.Text = string.Empty;
        }
    }
}
