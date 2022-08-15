using ComponentFactory.Krypton.Toolkit;
using SGI.App;
using SGI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGI.Views
{
    public partial class fOrderBuy : KryptonForm
    {

        #region 'VARIABLES'
        private KryptonForm kform;

        private DataTable dtOC = new DataTable();
        private DataTable dtOCDetalle = new DataTable();
        private DataTable dtRecOCDetalle = new DataTable();

        private readonly OrdendeCompra oc = new OrdendeCompra();
        private readonly OrdendeCompraDetalle ocDetalle = new OrdendeCompraDetalle();
        private readonly Proveedor prov = new Proveedor();
        private readonly Producto prod = new Producto();
        private readonly Rec_OC_Detalle RecOCDetalle = new Rec_OC_Detalle();
        private readonly Rec_OC roc = new Rec_OC();

        #endregion 'VARIABLES'

        public fOrderBuy(KryptonForm kform)
        {
            InitializeComponent();
            this.kform = kform;

            cmbEstado.DataSource = System.Enum.GetValues(typeof(Rec_OC.ListEstado));
            Data();
            ResetUI();
        }

        #region 'METODOS'
        private void Data()
        {

            dtGrid.Columns.Clear();

            // Traer datos de procedimiento almacenado al datagrid
            this.dtOC = this.oc.Data();
            dtGrid.DataSource = dtOC;


        } // Cargar todas las OC

        private void DataOCDetalle()
        {

            decimal subtotal = 0;

            dgOCDetalle.Columns.Clear();

            // Traer datos de procedimiento almacenado al datagrid
            this.dtOCDetalle = this.ocDetalle.Data(txtCodigo.Text.Trim());
            dgOCDetalle.DataSource = dtOCDetalle;

            for (int i = 0; i <= dgOCDetalle.Rows.Count - 1; i++)
            {

                    subtotal = Decimal.Parse(dgOCDetalle.Rows[i].Cells[5].Value.ToString());
                    goto doSum;
            }

        doSum:
            this.CalculateTotal();

        } // Cargar todas las lineas de la OC

        private void DataRecOCDetalle()
        {
            cmbEstado.DataSource = System.Enum.GetValues(typeof(Rec_OC.ListEstado));

            decimal subtotal = 0;

            dgRecepcion.Columns.Clear();

            // Traer datos de procedimiento almacenado al datagrid
            this.dtRecOCDetalle = this.RecOCDetalle.Data(txtCodOCRec.Text.Trim());
            dgRecepcion.DataSource = dtRecOCDetalle;

            for (int i = 0; i <= dgRecepcion.Rows.Count - 1; i++)
            {

                subtotal = Decimal.Parse(dgRecepcion.Rows[i].Cells[7].Value.ToString());
                goto doSum;
            }

        doSum:
            this.CalculateTotalRecepcion();

        } // Cargar todas las lineas de la OC Recepcion

        private void CrudOCDetails()
        {
            if (string.IsNullOrEmpty(txtCodigo.Text) || txtCodigo.Text == "Automatico")
            {
                txtCodigo.Text = oc.NextID();
            }
            if (string.IsNullOrEmpty(txtRutProveedor.Text))
            {
                ClsCommon.Toast("Debe ingresar rut de proveedor");
                txtRutProveedor.Focus();
                return;
            }
            if (ClsCommon.ValidaRut(txtRutProveedor.Text))
            {
                prov.Rut = ClsCommon.QuitarFormatoRut(txtRutProveedor.Text.Trim()); // asignar variable rut, para buscar y revisar que exista
                if (!prov.SearchRut()) // si no existe el proveedor entonces no dejará seguir
                {
                    ClsCommon.Toast("Debe crear el proveedor antes");
                    return;
                }

                if (!prod.SearchCode(txtMP.Text.Trim()))
                {
                    ClsCommon.Toast("Producto no existe");
                    return;
                }

                if (txtCantidad.Text == "0.00" || txtCantidad.Text == "0")
                {
                    fConfirm f = new fConfirm("Eliminar Registro");
                    f.ShowDialog();

                    if (ClsCommon.flag == 1)
                    {
                        ocDetalle.Cod_oc = decimal.Parse(txtCodigo.Text.Trim());
                        ocDetalle.Cod_producto = txtMP.Text.Trim();
                        ocDetalle.Destroy();
                        ClsCommon.flag = 0;
                        txtMP.Clear();
                        txtCantidad.Clear();
                        txtMP.Focus();
                        DataOCDetalle();
                    }
                    return;
                }
                if (string.IsNullOrEmpty(txtMP.Text))
                {
                    ClsCommon.Toast("Debe ingresar codigo de producto");
                    txtMP.Focus();
                    return;
                }

                DataOCDetalle();

                ocDetalle.Cod_oc = decimal.Parse(txtCodigo.Text.Trim());
                ocDetalle.Cod_producto = txtMP.Text.Trim();
                ocDetalle.Cantidad = decimal.Parse(txtCantidad.Text.Trim());
                oc.Rut_proveedor = ClsCommon.QuitarFormatoRut(txtRutProveedor.Text.Trim());
                oc.Fecha = dateFecha.Value;

                if (!ocDetalle.Create(oc))
                {
                    ClsCommon.Toast("No se agregó el producto");
                    return;
                }

                this.txtRutProveedor.Enabled = false;
                txtMP.Clear();
                txtCantidad.Clear();
                txtMP.Focus();
                DataOCDetalle();
                Data();
            }
            else
            {
                ClsCommon.Toast(ClsCommon.RutNoValido);
                txtRutProveedor.Focus();
            }
        }

        private void CrudRecOCDetails()
        {
            if (string.IsNullOrEmpty(txtCodOCRec.Text))
            {
                ClsCommon.Toast("Debe seleccionar OC");
                kryptonNavigator1.SelectedIndex = 0;
                dtGrid.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtCodMPRec.Text))
            {
                ClsCommon.Toast("Debe ingresar codigo de producto");
                txtCodMPRec.Focus();
                return;
            }

            roc.Estado = cmbEstado.SelectedValue.ToString();
            roc.Fecha = dateFechaRec.Value;
            RecOCDetalle.Cod_producto = txtCodMPRec.Text.Trim();
            RecOCDetalle.Cod_oc = decimal.Parse(txtCodOCRec.Text.Trim());
            RecOCDetalle.Cantidad = decimal.Parse(txtCantidadRec.Text.Trim());

            RecOCDetalle.Update(roc, Session.user_id);
            prod.Codigo = txtCodMPRec.Text.Trim();

            DataRecOCDetalle();
            Data();
        }

        private void ResetUI()
        {
            txtRutProveedor.Enabled = true;
            txtCodigo.Text = "Automatico";
            txtRutProveedor.Clear();
            txtMP.Clear();
            txtCantidad.Clear();
            dateFecha.Value = DateTime.Now;


            //RECEPCIONAR
            dateFechaRec.Value = DateTime.Now;
            txtCodOCRec.Text = "Automatico";
            txtCodMPRec.Clear();
            txtCantidadRec.Clear();
            cmbEstado.SelectedIndex = 0;

            //LIMPIAR DATAGRID
            dgOCDetalle.Columns.Clear();
            dgRecepcion.Columns.Clear();
            Data();
            
        }

        private void CalculateTotal()
        {
            decimal subtotal = 0, total = 0;
            for (int i = 0; i <= dgOCDetalle.Rows.Count - 1; i++)
            {
                subtotal = Decimal.Parse(dgOCDetalle.Rows[i].Cells[5].Value.ToString());
                total += subtotal;
            }

            khTotal.Values.Description = total.ToString("F");
        }

        private void CalculateTotalRecepcion()
        {
            decimal subtotal = 0, total = 0;
            for (int i = 0; i <= dgRecepcion.Rows.Count - 1; i++)
            {
                subtotal = Decimal.Parse(dgRecepcion.Rows[i].Cells[7].Value.ToString());
                total += subtotal;
            }

            khTotalRec.Values.Description = total.ToString("F");
        }

        #endregion 'METODODS'

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fOrderBuy_FormClosed(object sender, FormClosedEventArgs e)
        {
            kform.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = oc.NextID();
            txtCodigo.Enabled = false;
            txtRutProveedor.Enabled = true;
            txtRutProveedor.Focus();
            kryptonNavigator1.SelectedIndex = 1;
            DataOCDetalle();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.CrudOCDetails();
        }

        private void dtGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtCodigo.Text = this.dtGrid.CurrentRow.Cells["CODIGO"].Value.ToString();
                this.dateFecha.Value = DateTime.Parse(this.dtGrid.CurrentRow.Cells["FECHA"].Value.ToString());
                this.txtRutProveedor.Text = ClsCommon.FormatearRut(this.dtGrid.CurrentRow.Cells["PROVEEDOR"].Value.ToString());
                
                this.txtCodigo.Enabled = false;
                txtRutProveedor.Enabled = false;

                // VENTANA DE RECEPCION
                txtCodOCRec.Text = this.dtGrid.CurrentRow.Cells["CODIGO"].Value.ToString();
                this.txtCodOCRec.Enabled = false;

                this.kryptonNavigator1.SelectedIndex = 1;
                this.DataOCDetalle();
                this.DataRecOCDetalle();
            }
            catch (Exception)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ResetUI();
            txtCodigo.Focus();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClsUI.SoloDecimal(sender, e);
        }

        private void txtRutProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar.ToString().ToUpper().Equals("K"))
            {
                e.Handled = false;
            }
            else if (e.KeyChar.ToString().ToUpper().Equals("-"))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void txtRutProveedor_KeyUp(object sender, KeyEventArgs e)
        {
            txtRutProveedor.Text = ClsCommon.FormatearRut(txtRutProveedor.Text);

            txtRutProveedor.SelectionStart = txtRutProveedor.Text.Length;
            txtRutProveedor.SelectionLength = 0;
        }

        private void btnDestroy_Click(object sender, EventArgs e)
        {
            fConfirm f = new fConfirm("Eliminar Registro");
            f.ShowDialog();

            if (ClsCommon.flag == 1)
            {
                oc.Codigo = decimal.Parse(txtCodigo.Text.Trim());
                oc.Destroy();
                ClsCommon.flag = 0;
                ResetUI();
                Data();
                txtCodigo.Focus();
            }
        }

        private void btnAgregarRec_Click(object sender, EventArgs e)
        {
            this.CrudRecOCDetails();
        }

        private void dgRecepcion_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtCodMPRec.Text = this.dgRecepcion.CurrentRow.Cells["CODIGO"].Value.ToString();
                this.txtCantidadRec.Text = this.dgRecepcion.CurrentRow.Cells["RECEPCIONADO"].Value.ToString();

                this.txtCantidadRec.Focus();
            }
            catch (Exception)
            {

            }
        }

        private void dgOCDetalle_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtMP.Text = this.dgOCDetalle.CurrentRow.Cells["CODIGO"].Value.ToString();
                this.txtCantidad.Text = this.dgOCDetalle.CurrentRow.Cells["CANTIDAD"].Value.ToString();

                this.txtCantidad.Focus();
            }
            catch (Exception)
            {

            }
        }

        private void buttonSpecAny1_Click(object sender, EventArgs e)
        {
            fSearch f = new fSearch();
            f.ShowDialog();
            txtMP.Text = ClsCommon.codigo;
            
        }
    }
}
