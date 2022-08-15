using ComponentFactory.Krypton.Toolkit;
using SGI.App;
using SGI.Reports;
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
    public partial class fMenu : KryptonForm
    {
        #region 'VARIABLES'
        private readonly Dashboard dash = new Dashboard();

        #endregion 'VARIABLES'

        public fMenu()
        {
            InitializeComponent();

            DashboardRefresh();
            lblVersion.Values.ExtraText = ClsCommon.version;

        }

        #region 'METODOS'

        private void DashboardRefresh() 
        {
            dtGridTopSales.Columns.Clear();
            dtGridTopSales.DataSource = dash.topSales();

            dtGridLastSales.Columns.Clear();
            dtGridLastSales.DataSource = dash.lastSales();
        }

        #endregion 'METODOS'

        private void HeaderSession_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (Session.user_profile != "ADMINISTRADOR")
            {
                ClsCommon.Toast(ClsCommon.AccesDenied + " " + Session.user_fullname);
                return;
            }
            this.Hide();

            using (fUsers f = new fUsers(this))
            {
                f.ShowDialog();
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (fProducts f = new fProducts(this))
            {
                f.ShowDialog();
            }
        }

        private void kryptonLabel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (fOrders f = new fOrders(this))
            {
                f.ShowDialog();
            }
        }

        private void fMenu_Load(object sender, EventArgs e)
        {
            HeaderSession.Values.Description = Session.user_fullname;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (fCustomers f = new fCustomers(this))
            {
                f.ShowDialog();
            }
        }

        private void bsSettings_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (fLogin f = new fLogin())
            {
                f.ShowDialog();
            }

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (fOrderBuy f = new fOrderBuy(this))
            {
                f.ShowDialog();
            }
        }

        private void bsRefresh_Click(object sender, EventArgs e)
        {
            this.DashboardRefresh();
        }
    }
}
