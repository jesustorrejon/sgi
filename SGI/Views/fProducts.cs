using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGI.Views
{
    public partial class fProducts : KryptonForm
    {
        public fProducts()
        {
            InitializeComponent();
        }

        private void fProducts_Load(object sender, EventArgs e)
        {
            dtGrid.Rows.Add("1","COCA COLA");
            dtGrid.Rows.Add("2", "AGUA NATURAL");
            dtGrid.Rows.Add("3", "TEQUILA");
        }
    }
}
