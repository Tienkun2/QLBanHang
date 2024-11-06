using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang
{
    public partial class MainForm_ : Form
    {
        public MainForm_()
        {
            InitializeComponent();
        }

        private void MainForm__Load(object sender, EventArgs e)
        {

        }

        private void MainForm__FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
