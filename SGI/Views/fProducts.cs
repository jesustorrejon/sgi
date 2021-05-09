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

namespace SGI.Views
{
    public partial class fProducts : KryptonForm
    {
        #region 'VARIABLES'
        private int secuencia_producto = 0;
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
            this.dtGrid.Columns.Clear();
            // Traer datos de procedimiento almacenado al datagrid
            pr.Data(dtProd);
            this.dtGrid.DataSource = dtProd;

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
            fa.List(dtFam);
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
            this.secuencia_producto = 0;
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
            this.txtDescripcion.Focus();
        }

        private void CreateorUpdate()
        {
            // Seleccionar primera pestaña
            this.kryptonNavigator1.SelectedIndex = 1;

            if (string.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                clsSGI.Toast("Ingrese el nombre del producto");
                this.txtDescripcion.Focus();
                return;
            }

            pr.Secuencia = this.secuencia_producto;
            pr.Codigo = txtCodigo.Text;
            pr.Rut_proveedor = txtRutProveedor.Text;
            pr.Codigo_barra = Convert.ToInt32(this.txtBarcode.Text.Trim());
            pr.Codigo_familia = cmbFamilia.SelectedValue.ToString();
            pr.Fecha_vencimiento = dateFechaVencimiento.Value.Date;
            pr.Descripcion = txtDescripcion.Text.Trim(); // Trim es por si usuario ingresa espacios en el texto
            pr.Unidad_medida = cmbUnidadMedida.SelectedValue.ToString();
            pr.Precio_compra = float.Parse(txtCosto.Text);
            pr.Precio_venta = float.Parse(txtPrecio.Text);
            pr.Stock = float.Parse(txtStock.Text);
            pr.Stock_critico = float.Parse(txtStockCritico.Text);
            if (this.pBox.Image !=null)
            {
                string NombreFoto = this.txtDescripcion.Text.Trim().Replace(" ", "_").ToLower() + DateTime.Now.Ticks.ToString();
                pBox.Image.Save(ClsUI.ImagesProductoPath + NombreFoto + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                pr.Imagen = NombreFoto + "jpg";
            }

            clsSGI.Toast(this.secuencia_producto > 0 ? pr.Update() : pr.Create() );

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
    }
}
