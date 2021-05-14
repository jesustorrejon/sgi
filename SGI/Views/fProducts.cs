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

// Librerias
using CommonProject.Models;
using CommonProject.App;
using CommonProject.Data;
using SGI.App;
using System.Data.OracleClient;

namespace SGI.Views
{
    public partial class fProducts : KryptonForm
    {
        #region 'VARIABLES'
        //private int secuencia_producto = 0;
        private int secuencia_familia = 0;

        private readonly Producto pr = new Producto();
        private readonly Familia fa = new Familia();

        private DataTable dtProd = new DataTable();
        private DataTable dtFam = new DataTable();

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private KryptonForm kform;

        #endregion

        public fProducts(/*KryptonForm kform*/)
        {
            InitializeComponent();
            //this.kform = kform;
            this.Data();
            this.FamiliaList();

        }

        #region 'Metodos'
        private void Data()
        {
            dtProd.Rows.Clear();

            OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD= sgi; USER ID= sgi;");
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_productos_data", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comando;
            adapter.Fill(dtProd);
            ora.Close();

            
            // Traer datos de procedimiento almacenado al datagrid
            //this.pr.Data(this.dtProd);
            dtGrid.DataSource = dtProd;

            // Modificar altura del Datagrid en 40 puntos
            this.dtGrid.RowTemplate.Height = 40;
            // Centrar vertical y horizontalmente el texto de la celda
            this.dtGrid.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Centrar encabezados vertical y horizontalmente
            this.dtGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajustar celdas segun contenido
            this.dtGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void FamiliaList()
        {
            //this.dtFam = fa.List();
            fa.List(this.dtFam);
            cmbFamilia.DisplayMember = "descripcion";
            cmbFamilia.ValueMember = "codigo";
            cmbFamilia.DataSource = dtFam;
            
            if(dtFam !=null && dtFam.Rows.Count > 0)
            {
                this.klistFamilia.Items.Clear();
                for (int i = 0; i <= dtFam.Rows.Count-1; i++)
                {
                    this.klistFamilia.Items.Add($"{dtFam.Rows[i].Field<string>("codigo")} - {dtFam.Rows[i].Field<string>("descripcion")}");
                }
            
            }
            
            if (cmbFamilia.Items.Count > 0) cmbFamilia.SelectedIndex = 0;

        }

        private void ResetUI()
        {
            //this.secuencia_producto = 0;
            this.txtCodigo.Clear();
            this.secuencia_familia = 0;
            this.txtDescripcion.Clear();
            this.txtBarcode.Clear();
            this.txtRutProveedor.Clear();
            this.txtIngredientes.Clear();
            this.txtCosto.Text = "0.00";
            this.txtPrecio.Text = "0.00";
            this.txtPrecioEspecial.Text = "0.00";
            this.txtStock.Text = "0.00";
            this.txtStockCritico.Text = "0.00";
            this.txtRaciones.Text = "0.00";
            this.pBox.Image = null;
            this.pFamilia.Image = null;
            this.txtCodigo.Focus();
        }

        private void CreateorUpdate()
        {
            // Seleccionar primera pestaña
            this.kryptonNavigator1.SelectedIndex = 1;

            if (string.IsNullOrEmpty(this.txtCodigo.Text))
            {
                clsSGI.Toast("Ingrese codigo del producto");
                this.txtCodigo.Focus();
                return;
            }

            pr.Codigo = txtCodigo.Text;
            pr.Rut_proveedor = txtRutProveedor.Text;
            pr.Codigo_barra = 123123;//Convert.ToInt32(this.txtBarcode.Text.Trim());
            pr.Codigo_familia = cmbFamilia.SelectedValue.ToString();
            pr.Fecha_vencimiento = Convert.ToDateTime(dateFechaVencimiento.Value);
            pr.Descripcion = txtDescripcion.Text.Trim(); // Trim es por si usuario ingresa espacios en el texto
            pr.Unidad_medida = "kg";//cmbUnidadMedida.SelectedItem.ToString();
            pr.Precio_compra = float.Parse(txtCosto.Text);
            pr.Precio_venta = float.Parse(txtPrecio.Text);
            pr.Stock = float.Parse(txtStock.Text);
            pr.Stock_critico = float.Parse(txtStockCritico.Text);
            if (this.pBox.Image != null)
            {
                string NombreFoto = this.txtDescripcion.Text.Trim().Replace(" ", "_").ToLower() + DateTime.Now.Ticks.ToString();
                pBox.Image.Save(ClsUI.ImagesProductoPath + NombreFoto + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                pr.Imagen = NombreFoto + "jpg";
            }
            else              
                { pr.Imagen = "n"; }

            pr.Create();
            //clsSGI.Toast(this.secuencia_producto > 0 ? pr.Update() : pr.Create() );

            this.Data();

            this.kryptonNavigator1.SelectedIndex = 0;

            this.ResetUI();
        }

        private void Destroy()
        {
            pr.Codigo = txtCodigo.Text;

            clsSGI.Toast(pr.Destroy());

            this.ResetUI();

            this.Data();

            ClsCommon.flag = 0;

            this.kryptonNavigator1.SelectedIndex = 0;
        }

        private void CreateorUpdate_Familia()
        {
            if (string.IsNullOrEmpty(txtFamilia.Text))
            {
                clsSGI.Toast("Ingrese el nombre de la familia");
                this.txtFamilia.Focus();
                return;
            }

            fa.Codigo = this.txtCodFamilia.Text.Trim();
            fa.Descripcion = this.txtFamilia.Text.Trim();

            if (this.pFamilia.Image !=null)
            {
                string NombreFoto = this.txtFamilia.Text.Trim().Replace(" ", "_").ToLower() + DateTime.Now.Ticks.ToString();
                pFamilia.Image.Save(ClsUI.ImagesFamiliaPath + NombreFoto + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                fa.Imagen = NombreFoto + ".jpg";

                clsSGI.Toast(this.secuencia_familia > 0 ? fa.Update() : fa.Create());

                this.FamiliaList();

                this.ResetUI();
            }
        }

        private void Destroy_familia()
        {
            fa.Codigo = txtCodFamilia.Text.Trim();
            clsSGI.Toast(fa.Destroy());

            this.ResetUI();

            this.FamiliaList();
        }
        #endregion


        private void fProducts_Load(object sender, EventArgs e)
        {
            
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClsUI.SoloDecimal(sender, e);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClsUI.SoloDecimal(sender, e);
        }

        private void txtPrecioEspecial_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClsUI.SoloDecimal(sender, e);
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClsUI.SoloDecimal(sender, e);
        }

        private void txtStockCritico_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClsUI.SoloDecimal(sender, e);
        }

        private void txtRaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClsUI.SoloDecimal(sender, e);
        }

        private void txtCosto_Validated(object sender, EventArgs e)
        {
            txtCosto.Text = ClsUI.Divisa(txtCosto.Text.Trim());
        }

        private void txtPrecio_Validated(object sender, EventArgs e)
        {
            txtPrecio.Text = ClsUI.Divisa(txtPrecio.Text.Trim());
        }

        private void txtPrecioEspecial_Validated(object sender, EventArgs e)
        {
            txtPrecioEspecial.Text = ClsUI.Divisa(txtPrecioEspecial.Text.Trim());
        }

        private void txtStock_Validated(object sender, EventArgs e)
        {
            txtStock.Text = ClsUI.Divisa(txtStock.Text.Trim());
        }

        private void txtStockCritico_Validated(object sender, EventArgs e)
        {
            txtStockCritico.Text = ClsUI.Divisa(txtStockCritico.Text.Trim());
        }

        private void txtRaciones_Validated(object sender, EventArgs e)
        {
            txtRaciones.Text = ClsUI.Divisa(txtRaciones.Text.Trim());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.ResetUI();
            this.kryptonNavigator1.SelectedIndex = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.CreateorUpdate();
        }

        private void btnDestroy_Click(object sender, EventArgs e)
        {
            
                clsSGI.Toast("Debe seleccionar el registro a eliminar");
                this.kryptonNavigator1.SelectedIndex = 0;
                this.dtGrid.Focus();

            this.kryptonNavigator1.SelectedIndex = 1;
            fConfirm f = new fConfirm();
            f.ShowDialog();

            if (ClsCommon.flag == 1)
            {
                this.Destroy();
                ClsCommon.flag = 0;
            }
        }

        private void dtGrid_DoubleClick(object sender, EventArgs e)
        {
            
            try
            {
                this.pBox.Image = null;
               // this.secuencia_producto = Convert.ToInt32(this.dtGrid.CurrentRow.Cells["NRO"].Value);
                this.txtCodigo.Text = this.dtGrid.CurrentRow.Cells["ID"].Value.ToString();
                this.txtDescripcion.Text = this.dtGrid.CurrentRow.Cells["NOMBRE"].Value.ToString();
                this.cmbFamilia.Text = this.dtGrid.CurrentRow.Cells["FAMILIA"].Value.ToString();
                this.txtBarcode.Text = this.dtGrid.CurrentRow.Cells["CODIGO"].Value.ToString();
                //this.dateFechaVencimiento = this.dtGrid.CurrentRow.Cells["VENCIMIENTO"].Value;

                this.kryptonNavigator1.SelectedIndex = 1;
            }
            catch (Exception)
            {

            }
        }
    }
}
