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
using SGI.Models;
//using CommonProject.App;
using SGI.Data;
using SGI.App;
using System.Data.OracleClient;
using System.IO;

namespace SGI.Views
{
    public partial class fProducts : KryptonForm
    {
        #region 'VARIABLES'
        //private int secuencia_producto = 0;
        private string familia_codigo = "";

        private readonly Producto pr = new Producto();
        private readonly Familia fa = new Familia();
        private readonly Proveedor prov = new Proveedor();
        private readonly Cliente cli = new Cliente();

        private DataTable dtProd = new DataTable();
        private DataTable dtFam = new DataTable();
        private DataTable dtUmedida = new DataTable();
        private DataTable dtProveedor = new DataTable();

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private KryptonForm kform;

        #endregion

        public fProducts(KryptonForm kform)
        {
            InitializeComponent();
            this.kform = kform;
            this.Data();
            this.FamiliaList();
            this.ProveedorList();

        }

        private void ProveedorList()
        {
            dtProveedor.Columns.Clear();

            //Llenar combobox de gestionar productos
            this.dtProveedor = prov.Data();
            cmbProveedor.DisplayMember = "razon_social";
            cmbProveedor.ValueMember = "rut";
            cmbProveedor.DataSource = dtProveedor;



            this.dtGridProveedores.DataSource = dtProveedor;
        }
        #region 'Metodos'
        private void Data()
        {
            //Llenar combobox de Proveedores en gestionar productos
            this.dtProveedor = prov.Data();
            cmbProveedor.DisplayMember = "razon social";
            cmbProveedor.ValueMember = "rut";
            cmbProveedor.DataSource = dtProveedor;


            //Llenar combobox de Unidad de Medida en gestionar productos
            this.dtUmedida = this.pr.ListUMedida();
            cmbUnidadMedida.DisplayMember = "descripcion";
            cmbUnidadMedida.ValueMember = "codigo";
            cmbUnidadMedida.DataSource = dtUmedida;

            dateFechaVencimiento.Value = DateTime.Now;

            dtProd.Columns.Clear();

            // Traer datos de procedimiento almacenado al datagrid
            this.dtProd = this.pr.Data();
            dtGrid.DataSource = dtProd;

            // Modificar altura del Datagrid en 40 puntos
            this.dtGrid.RowTemplate.Height = 40;
            // Centrar vertical y horizontalmente el texto de la celda
            this.dtGrid.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Centrar encabezados vertical y horizontalmente
            this.dtGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajustar celdas segun contenido
            //this.dtGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void FamiliaList()
        {
            dtFamilia.Columns.Clear();
            this.dtFam = fa.Data();
            cmbFamilia.DisplayMember = "descripcion";
            cmbFamilia.ValueMember = "codigo";
            cmbFamilia.DataSource = dtFam;

            dtFamilia.DataSource = dtFam;

        }

        private void ResetUI()
        {
            this.txtCodigo.Text = "Automatico";
            this.txtDescripcion.Clear();
            this.txtBarcode.Clear();
            this.txtIngredientes.Clear();
            this.txtCosto.Text = "0.00";
            this.txtPrecio.Text = "0.00";
            this.txtPrecioEspecial.Text = "0.00";
            this.txtStock.Text = "0.00";
            this.txtStockCritico.Text = "0.00";
            this.txtRaciones.Text = "0.00";
            this.pBox.Image = null;
            this.pBoxFamilia.Image = null;
            this.txtDescripcion.Focus();
        }

        private void CreateorUpdate()
        {
            // Seleccionar primera pestaña
            this.kryptonNavigator1.SelectedIndex = 1;

            if (string.IsNullOrEmpty(this.txtCodigo.Text))
            {
                ClsCommon.Toast("Ingrese codigo del producto");
                this.txtCodigo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.txtBarcode.Text))
            {
                this.txtBarcode.Text = 0.ToString();
            }

            pr.Codigo = txtCodigo.Text;
            pr.Rut_proveedor = cmbProveedor.SelectedValue.ToString();
            pr.Codigo_barra = decimal.Parse(this.txtBarcode.Text.Trim());
            pr.Familia_Codigo = cmbFamilia.SelectedValue.ToString();
            pr.Fecha_vencimiento = dateFechaVencimiento.Value.ToShortDateString();
            pr.Descripcion = txtDescripcion.Text.Trim(); // Trim es por si usuario ingresa espacios en el texto
            pr.Unidad_medida = cmbUnidadMedida.SelectedValue.ToString();
            pr.Precio_compra = float.Parse(txtCosto.Text);
            pr.Precio_venta = float.Parse(txtPrecio.Text);
            pr.Stock = float.Parse(txtStock.Text);
            pr.Stock_critico = float.Parse(txtStockCritico.Text);
            if (this.pBox.Image != null)
            {
                string NombreFoto = this.txtDescripcion.Text.Trim().Replace(" ", "_").ToLower() + DateTime.Now.Ticks.ToString();
                pBox.Image.Save(ClsUI.ImagesProductoPath + NombreFoto + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                pr.Imagen = NombreFoto + ".jpg";
            }
            else
            { pr.Imagen = "sin_imagen.jpg"; }

            ClsCommon.Toast(pr.SearchCode(txtCodigo.Text) == true ? pr.Update() : pr.Create());

            this.Data();

            this.kryptonNavigator1.SelectedIndex = 0;

            this.ResetUI();
        }

        private void Destroy()
        {
            this.pr.Codigo = txtCodigo.Text;
            ClsCommon.Toast(pr.Destroy());

            this.ResetUI();

            this.Data();

            ClsCommon.flag = 0;

            this.kryptonNavigator1.SelectedIndex = 0;
        }

        private void CreateorUpdateFamilia()
        {
            if (string.IsNullOrEmpty(txtFamilia.Text))
            {
                ClsCommon.Toast("Ingrese el nombre de la familia");
                this.txtFamilia.Focus();
                return;
            }

            fa.Codigo = this.txtCodFamilia.Text.Trim();
            fa.Descripcion = this.txtFamilia.Text.Trim();

            if (this.pBoxFamilia.Image != null)
            {
                string NombreFoto = this.txtFamilia.Text.Trim().Replace(" ", "_").ToLower() + DateTime.Now.Ticks.ToString();
                pBoxFamilia.Image.Save(ClsUI.ImagesFamiliaPath + NombreFoto + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                fa.Imagen = NombreFoto + ".jpg";
            }
            else
            { fa.Imagen = "sin_imagen.jpg"; }

            ClsCommon.Toast(this.fa.FamiliaExists(txtFamilia.Text) == true ? fa.Update() : fa.Create());

            txtCodFamilia.Clear();
            txtFamilia.Clear();
            this.pBoxFamilia.Image = null;
            this.dtFam.Columns.Clear();
            this.FamiliaList();

        }

        private void CreateorUpdateProveedor()
        {
            if (!ClsUI.ComprobarFormatoEmail(txtContacto.Text))
            {
                ClsCommon.Toast("Email no valido");
                return;
            }
            if (!ClsCommon.ValidaRut(txtRutProveedor.Text))
            {
                ClsCommon.Toast(ClsCommon.RutNoValido);
                return;
            }
            if (string.IsNullOrEmpty(txtRutProveedor.Text))
            {
                ClsCommon.Toast("Ingrese rut del proveedor");
                this.txtRutProveedor.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                txtTelefono.Text = "0";
            }

            prov.Rut = ClsCommon.QuitarFormatoRut(this.txtRutProveedor.Text.Trim());
            prov.Razon_social = this.txtRazonSocial.Text.Trim();
            prov.Giro = this.txtGiro.Text.Trim();
            prov.Direccion = this.txtDireccion.Text.Trim();
            prov.Comuna = this.txtComuna.Text.Trim();
            prov.Ciudad = this.txtCiudad.Text.Trim();
            prov.Telefono = decimal.Parse(this.txtTelefono.Text.Trim());
            prov.Contacto = txtContacto.Text.Trim();

            ClsCommon.Toast(this.prov.SearchRut() == true ? prov.Update() : prov.Create());

            txtRutProveedor.Clear();
            txtRutProveedor.Enabled = true;
            txtRutProveedor.Focus();
            txtRazonSocial.Clear();
            txtGiro.Clear();
            txtDireccion.Clear();
            txtComuna.Clear();
            txtCiudad.Clear();
            txtTelefono.Clear();
            txtContacto.Clear();
            this.dtGridProveedores.Columns.Clear();
            this.ProveedorList();

        }

        private void Destroy_familia()
        {
            fa.Codigo = txtCodFamilia.Text.Trim();
            ClsCommon.Toast(fa.Destroy());
            txtCodFamilia.Enabled = true;
            txtCodFamilia.Clear();
            txtFamilia.Clear();
            pBoxFamilia.Image = null;
            this.dtFam.Columns.Clear();
            this.FamiliaList();

            ClsCommon.flag = 0;
        }

        private void Destroy_Proveedor()
        {
            prov.Rut = txtRutProveedor.Text.Trim();
            ClsCommon.Toast(prov.Destroy());
            txtRutProveedor.Enabled = true;
            txtRutProveedor.Clear();
            txtRazonSocial.Clear();
            txtGiro.Clear();
            txtDireccion.Clear();
            txtComuna.Clear();
            txtCiudad.Clear();
            txtTelefono.Clear();
            txtContacto.Clear();
            this.dtGridProveedores.Columns.Clear();
            this.ProveedorList();

            ClsCommon.flag = 0;
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

        [Obsolete]
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.ResetUI();
            this.kryptonNavigator1.SelectedIndex = 1;
            this.txtCodigo.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.CreateorUpdate();
        }

        private void btnDestroy_Click(object sender, EventArgs e)
        {
            //this.Destroy();
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                ClsCommon.Toast("Debe seleccionar el registro a eliminar");
                this.kryptonNavigator1.SelectedIndex = 0;
                this.dtGrid.Focus();
                return;
            }

            fConfirm f = new fConfirm("Eliminar Registro");
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
                this.txtCodigo.Text = this.dtGrid.CurrentRow.Cells["CODIGO"].Value.ToString();
                this.txtCodigo.Enabled = false;
                this.txtBarcode.Text = this.dtGrid.CurrentRow.Cells["CODIGO BARRA"].Value.ToString();
                this.txtDescripcion.Text = this.dtGrid.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                this.dateFechaVencimiento.Value = DateTime.Parse(this.dtGrid.CurrentRow.Cells["VENCIMIENTO"].Value.ToString());

                this.cmbUnidadMedida.SelectedIndex = cmbUnidadMedida.FindStringExact(this.dtGrid.CurrentRow.Cells["U.M."].Value.ToString());
                this.cmbProveedor.SelectedIndex = cmbProveedor.FindStringExact(this.dtGrid.CurrentRow.Cells["PROVEEDOR"].Value.ToString());
                this.cmbFamilia.SelectedIndex = cmbFamilia.FindStringExact(this.dtGrid.CurrentRow.Cells["FAMILIA"].Value.ToString());

                this.txtCosto.Text = this.dtGrid.CurrentRow.Cells["COSTO"].Value.ToString();
                this.txtPrecio.Text = this.dtGrid.CurrentRow.Cells["PRECIO"].Value.ToString();
                this.txtStock.Text = this.dtGrid.CurrentRow.Cells["STOCK"].Value.ToString();
                this.txtStockCritico.Text = this.dtGrid.CurrentRow.Cells["STOCK CRITICO"].Value.ToString();

                if(!string.IsNullOrEmpty( this.dtGrid.CurrentRow.Cells["IMAGEN"].Value.ToString()))
                {
                    if(File.Exists(ClsUI.ImagesProductoPath + this.dtGrid.CurrentRow.Cells["IMAGEN"].Value.ToString()))
                    {
                        Image image = Image.FromFile(ClsUI.ImagesProductoPath + this.dtGrid.CurrentRow.Cells["IMAGEN"].Value.ToString());
                        this.pBox.Image = image;
                        this.pBox.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }

                this.kryptonNavigator1.SelectedIndex = 1;
            }
            catch (Exception)
            {

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fProducts_FormClosed(object sender, FormClosedEventArgs e)
        {
            kform.Show();
        }

        private void btnDelFamilia_Click(object sender, EventArgs e)
        {
            if (fa.HasProduct(txtCodFamilia.Text))
            {
                ClsCommon.Toast("La familia tiene productos relacionados, no es posible eliminarla");
                return;
            }
            if (txtCodFamilia.Text == "")
            {
                ClsCommon.Toast("Debe seleccionar el registro a eliminar");
                this.dtFamilia.Focus();
                return;
            }

            fConfirm f = new fConfirm("Eliminar Registro");
            f.ShowDialog();

            if (ClsCommon.flag == 1)
            {
                this.Destroy_familia();
                ClsCommon.flag = 0;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.kryptonNavigator1.SelectedIndex = 0;
            if (txtSearch.Text == "")
            {
                this.Data();
            }
            else
            {
                dtProd.Columns.Clear();

                // Traer datos de procedimiento almacenado al datagrid
                this.dtProd = this.pr.Search(txtSearch.Text);
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
        }

        private void dtGridProveedores_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                this.txtRutProveedor.Text = ClsCommon.FormatearRut(this.dtGridProveedores.CurrentRow.Cells["RUT"].Value.ToString());
                this.txtRutProveedor.Enabled = false;
                this.txtRazonSocial.Text = this.dtGridProveedores.CurrentRow.Cells["RAZON SOCIAL"].Value.ToString();
                this.txtGiro.Text = this.dtGridProveedores.CurrentRow.Cells["GIRO"].Value.ToString();
                this.txtDireccion.Text = this.dtGridProveedores.CurrentRow.Cells["DIRECCION"].Value.ToString();
                this.txtComuna.Text = this.dtGridProveedores.CurrentRow.Cells["COMUNA"].Value.ToString();
                this.txtCiudad.Text = this.dtGridProveedores.CurrentRow.Cells["CIUDAD"].Value.ToString();
                this.txtTelefono.Text = this.dtGridProveedores.CurrentRow.Cells["TELEFONO"].Value.ToString();
                this.txtContacto.Text = this.dtGridProveedores.CurrentRow.Cells["CONTACTO"].Value.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void btnBuscarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog opF = new OpenFileDialog();
            opF.Filter = "Elegir imagen(*.jpg *.png) | *.jpg; *.png";
            if(opF.ShowDialog() == DialogResult.OK)
            {
                pBox.Image = Image.FromFile(opF.FileName);
                pBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void kryptonHeader1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void kryptonHeader1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));

                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void kryptonHeader1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void dtFamilia_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                this.txtCodFamilia.Text = this.dtFamilia.CurrentRow.Cells["CODIGO"].Value.ToString();
                this.txtCodFamilia.Enabled = false;
                this.txtFamilia.Text = this.dtFamilia.CurrentRow.Cells["DESCRIPCION"].Value.ToString();

                if (!string.IsNullOrEmpty(this.dtFamilia.CurrentRow.Cells["IMAGEN"].Value.ToString()))
                {
                    if (File.Exists(ClsUI.ImagesFamiliaPath + this.dtFamilia.CurrentRow.Cells["IMAGEN"].Value.ToString()))
                    {
                        Image image = Image.FromFile(ClsUI.ImagesFamiliaPath + this.dtFamilia.CurrentRow.Cells["IMAGEN"].Value.ToString());
                        this.pBoxFamilia.Image = image;
                        this.pBoxFamilia.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnSaveProveedor_Click(object sender, EventArgs e)
        {
            this.CreateorUpdateProveedor();
        }

        private void buttonSpecHeaderGroup1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opF = new OpenFileDialog();
            opF.Filter = "Elegir imagen(*.jpg *.png) | *.jpg; *.png";
            if (opF.ShowDialog() == DialogResult.OK)
            {
                pBoxFamilia.Image = Image.FromFile(opF.FileName);
                pBoxFamilia.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClsUI.SoloNumero(sender, e);
        }

        private void btnSaveFamilia_Click(object sender, EventArgs e)
        {
            this.CreateorUpdateFamilia();
        }

        private void btnAddFamilia_Click(object sender, EventArgs e)
        {
            this.txtCodFamilia.Enabled = true;
            this.txtCodFamilia.Focus();
            this.txtFamilia.Clear();
            this.txtCodFamilia.Clear();
            this.pBoxFamilia.Image = null;
        }

        private void btnAddProveedores_Click(object sender, EventArgs e)
        {
            txtRutProveedor.Enabled = true;
            txtRutProveedor.Focus();
            txtRutProveedor.Clear();
            txtRazonSocial.Clear();
            txtGiro.Clear();
            txtDireccion.Clear();
            txtComuna.Clear();
            txtCiudad.Clear();
            txtTelefono.Clear();
            txtContacto.Clear();
        }

        private void btnDelProveedor_Click(object sender, EventArgs e)
        {
            if (txtRutProveedor.Text == "")
            {
                ClsCommon.Toast("Debe seleccionar el registro a eliminar");
                this.dtGridProveedores.Focus();
                return;
            }

            fConfirm f = new fConfirm("Eliminar Registro");
            f.ShowDialog();

            if (ClsCommon.flag == 1)
            {
                this.Destroy_Proveedor();
                ClsCommon.flag = 0;
            }
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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Si no es número Y NO ES
            //la tecla borrar
            if (!Char.IsNumber(e.KeyChar) &&
                e.KeyChar != Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
