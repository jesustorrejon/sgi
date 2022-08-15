using ComponentFactory.Krypton.Toolkit;
using SGI.App;
using SGI.Models;
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
    public partial class fSearch : KryptonForm
    {
        #region 'VARIABLES'
        private readonly Producto pr = new Producto();


        #endregion 'VARIABLES'

        public fSearch()
        {
            InitializeComponent();
            Data();
        }

        #region 'METODOS'

        private void Data()
        {
            dgProductos.Columns.Clear();
            dgProductos.DataSource = pr.Data();
        }

        #endregion 'METODOS'


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                this.Data();
            }
            else
            {
                dgProductos.Columns.Clear();

                // Traer datos de procedimiento almacenado al datagrid
                dgProductos.DataSource = pr.Search(txtSearch.Text);
            }
        }

        private void dgProductos_DoubleClick(object sender, EventArgs e)
        {
            ClsCommon.codigo = this.dgProductos.CurrentRow.Cells["CODIGO"].Value.ToString();
            this.Close();
        }
    }
}
