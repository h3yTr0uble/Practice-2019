using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class SettingsForm : Form
    {
        public int ApplesCount { get; private set; }
        public int TanksCount { get; private set; }
        public int Speed { get; private set; }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ApplesCount = int.Parse(ctlApplesCount.Value.ToString());
            TanksCount = int.Parse(ctlTanksCount.Value.ToString());
            Speed = int.Parse(ctlSpeed.Value.ToString());
        }
    }
}
