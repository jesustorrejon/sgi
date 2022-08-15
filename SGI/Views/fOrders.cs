using ComponentFactory.Krypton.Toolkit;
using SGI.App;
using SGI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGI.Views
{
    public partial class fOrders : KryptonForm
    {

        #region 'Variables'
        private KryptonForm kform;
        private DataTable data = new DataTable();
        private Producto producto = new Producto();
        private Boleta boleta = new Boleta();
        private string Ticket_Name_Retrieved;
        private string _barcode = "";

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        #endregion


        #region 'METODOS'


        #endregion

        public fOrders(KryptonForm kf)
        {
            InitializeComponent();
            this.kform = kf;

            dtGrid.RowTemplate.Height = 55;
            dtGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtGrid.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Alinear al centro
            dtGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Alinear al centro

            dtGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader; // Ajustar primera columna segun el contenido.
            dtGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dtGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dtGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dtGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            this.loadFamilias();
        }

        #region 'METODOS'

        private void loadFamilias()
        {
            try
            {
                panelCards.Controls.Clear();
                Familia fam = new Familia();
                DataTable f = new DataTable();
                f = fam.List();

                KryptonButton b;

                for (int i = 0; i <= f.Rows.Count - 1; i++)
                {
                    b = new KryptonButton();
                    b.Name = "fam" + f.Rows[i].Field<string>("codigo");
                    b.Tag = f.Rows[i].Field<string>("codigo");

                    b.Height = 90;
                    b.Width = 140;
                    string pathPic = (string.IsNullOrEmpty(f.Rows[i].Field<string>("imagen")) ? "" : f.Rows[i].Field<string>("imagen").ToString().Trim());
                    if (!string.IsNullOrEmpty(pathPic) && pathPic != "null")
                    {
                        if (File.Exists(ClsUI.ImagesFamiliaPath + pathPic))
                        {
                            Image image = Image.FromFile(ClsUI.ImagesFamiliaPath + pathPic);
                            b.Values.Image = ClsUI.resizeImage(image, b.Width, b.Height);
                            b.BackgroundImageLayout = ImageLayout.Stretch;
                            b.StateCommon.Content.ShortText.TextH = PaletteRelativeAlign.Center;
                            b.StateCommon.Content.ShortText.TextV = PaletteRelativeAlign.Far;
                            b.StateNormal.Border.Rounding = 3;
                            b.StateNormal.Border.Width = 1;
                            b.StateTracking.Back.Color1 = Color.Black;
                            b.StateTracking.Back.Color2 = Color.DimGray;
                            b.StateCommon.Content.ShortText.Color1 = Color.White;
                            b.StateCommon.Content.ShortText.Color2 = Color.White;
                            b.OverrideDefault.Back.Color1 = Color.Black;
                            b.OverrideDefault.Back.Color2 = Color.FromArgb(64, 64, 64);
                            b.PaletteMode = PaletteMode.ProfessionalSystem;
                            b.StateNormal.Back.Color1 = Color.Black;
                            b.StateNormal.Back.Color1 = Color.DimGray;
                            b.StateNormal.Border.DrawBorders = (PaletteDrawBorders.Top | PaletteDrawBorders.Bottom | PaletteDrawBorders.Left | PaletteDrawBorders.Right);
                        }
                    }
                    b.Text = f.Rows[i].Field<string>("descripcion").ToString();
                    b.AutoSizeMode = AutoSizeMode.GrowOnly;
                    b.AutoSize = true;
                    b.Dock = DockStyle.Fill;

                    b.Click += new EventHandler(this.familia_Click);
                    panelCards.Controls.Add(b);

                    panelCards.Dock = DockStyle.Fill;
                    panelProductos.Visible = false;
                    panelCards.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void familia_Click(object sender, System.EventArgs e)
        {
            string famcodigo = ((KryptonButton)sender).Tag.ToString();
            this.loadProductos(famcodigo);
            khFamilias.Text = ((KryptonButton)sender).Text.Trim().ToUpper();
        }

        private void loadProductos(string familia_codigo)
        {
            try
            {
                panelProductos.Controls.Clear();
                DataTable items = new DataTable();
                producto.Familia_Codigo = familia_codigo;
                items = producto.DataOrders();
                KryptonButton b;
                for (int i = 0; i <= items.Rows.Count - 1 ; i++)
                {
                    b = new KryptonButton();
                    b.Name = "prod" + items.Rows[i].Field<string>("codigo");
                    b.Tag = "|" + items.Rows[i].Field<string>("codigo") + "|" + items.Rows[i].Field<string>("descripcion") + "|" + items.Rows[i].Field<decimal>("precio") + "|"  + items.Rows[i].Field<decimal>("stock");
                    b.Height = 90;
                    b.Width = 140;
                    b.StateCommon.Content.ShortText.Font = new Font("Monserrat", 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    b.Text = fixName(items.Rows[i].Field<string>("descripcion"), 10);

                    Image image = Image.FromFile(ClsUI.ImagesProductoPath + items.Rows[i].Field<string>("imagen"));
                    b.Values.Image = (Image)(new Bitmap(image, new Size(100, 55)));
                    b.StateCommon.Content.ShortText.TextH = PaletteRelativeAlign.Center;
                    b.StateCommon.Content.ShortText.TextV = PaletteRelativeAlign.Far;
                    b.StateNormal.Border.Rounding = 3;
                    b.StateNormal.Border.Width = 1;

                    b.Click += new EventHandler(this.producto_Click);

                    panelProductos.Controls.Add(b);
                    panelProductos.Dock = DockStyle.Fill;
                    panelCards.Visible = false;
                    panelProductos.Visible = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            } 
        }

        private string fixName(string text, int chunkSize)
        {
            string cadFixed = "";
            string[] parts = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1 || text.Length <= chunkSize)
            {
                cadFixed = text.ToUpper();
                return cadFixed;
            }
            else
            {
                foreach (var p in parts)
                {
                    if ((cadFixed + " " + p).Length <= chunkSize )
                    {
                        cadFixed += " " + p + "\n";
                    }
                    else
                    {
                        cadFixed += " " + p + "\n";
                    }

                }
            }

            return cadFixed.TrimEnd('\n').TrimEnd('\r');
        }

        private void producto_Click(object sender, System.EventArgs e)
        {
            string[] info = (((KryptonButton)sender).Tag.ToString()).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            decimal precio = 0, cant = 0, importe = 0;
            bool added = false;

            if (dtGrid.Rows.Count >= 0)
            {
                dtGrid.Rows.Add(info[0], info[1], info[2], 1.ToString("F"), info[2]);
                goto doSum;
            }
            else
            {
                for (int i = 0; i <= dtGrid.Rows.Count - 1; i++)
                {
                    if (Convert.ToString(dtGrid.Rows[i].Cells[0].Value) == Convert.ToString(info[0]))
                    {
                        cant = Decimal.Parse(dtGrid.Rows[i].Cells[3].Value.ToString() + 1);
                        precio = Decimal.Parse(dtGrid.Rows[i].Cells[2].Value.ToString());
                        importe = (cant * precio);

                        dtGrid.Rows[i].Cells[3].Value = cant.ToString("F");
                        dtGrid.Rows[i].Cells[4].Value = importe.ToString();
                        goto doSum;

                    }
                }
            }
            doSum:
            this.CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal importe = 0, total = 0, items = 0;
            for (int i = 0; i <= dtGrid.Rows.Count - 1; i++)
            {
                importe = Decimal.Parse(dtGrid.Rows[i].Cells[4].Value.ToString());
                items = Decimal.Parse(dtGrid.Rows[i].Cells[3].Value.ToString());
                total += importe; 
            }

            khTotal.Values.Description = total.ToString("F");
            lblItems.Values.ExtraText = items.ToString("F");
        }

        private void IncreaseDecreaseItem(string producto_codigo, int action)
        {
            try
            {
                if (dtGrid.Rows.Count <= 0)
                {
                    MessageBox.Show("NO HAY PRODUCTOS AGREGADOS A LA VENTA");
                    return;
                }

                decimal cant = 0, precio = 0, importe = 0;

                for (int i = 0; i <= dtGrid.Rows.Count - 1; i++)
                {
                    if (dtGrid.Rows[i].Cells[0].Value.ToString() == producto_codigo)
                    {
                        cant = decimal.Parse(dtGrid.Rows[i].Cells[3].Value.ToString()) + (action == 1 ? 1 : -1);
                        precio = decimal.Parse(dtGrid.Rows[i].Cells[2].Value.ToString());
                        importe = cant * precio;

                        dtGrid.Rows[i].Cells[3].Value = cant;
                        dtGrid.Rows[i].Cells[4].Value = importe.ToString();

                        if (cant < 1)
                        {
                            dtGrid.Rows.RemoveAt(i);
                            kgToolbar.Visible = false;
                        }

                        break;

                    }
                }


                this.CalculateTotal();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveItem()
        {
            if (dtGrid.SelectedRows.Count > 0)
            {
                dtGrid.Rows.RemoveAt(dtGrid.CurrentCell.RowIndex);
                kgToolbar.Visible = false;
                CalculateTotal();
            }
        }

        private void ResetUI()
        {
            dtGrid.Rows.Clear();
            txtSearch.Clear();
            txtSearch.Focus();
            loadFamilias();
            CalculateTotal();
        }

        private void Suspend_Transaction()
        {
            StreamWriter file = new StreamWriter(ClsUI.TicketsPath + DateTime.Now.Ticks.ToString() + "_" + khTotal.Values.Description.Trim() + "_.txt");
            try
            {
                string sLine = "";
                for (int r = 0; r <= dtGrid.Rows.Count - 1; r++)
                {

                    for (int c = 0; c <= dtGrid.Columns.Count - 1; c++)
                    {
                        sLine = sLine + dtGrid.Rows[r].Cells[c].Value;
                        if (c != dtGrid.Columns.Count - 1)
                        {
                            sLine = sLine + "|";
                        }
                    }
                    file.WriteLine(sLine);
                    sLine = "";
                }
                file.Close();
                ClsCommon.Toast("Transaccion suspendida");
                dtGrid.Rows.Clear();
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                file.Close();
                
            }

        }

        private void Recovery_Transaction(string ticketName = "")
        {
            try
            {
                int files = Directory.GetFiles(ClsUI.TicketsPath + "*.txt").Count();
                if (files <= 0)
                {
                    ClsCommon.Toast("No hay transacciones suspendidas");
                    return;
                }
                if (!File.Exists(ticketName))
                {
                    ClsCommon.Toast("No existe el archivo de la transacción");
                    return;
                }
                Ticket_Name_Retrieved = ticketName;
                string[] lines = File.ReadAllLines(Ticket_Name_Retrieved);
                string[] values;

                for (int i = 0; i < lines.Length; i++)
                {
                    values = lines[i].ToString().Split('|'); // array de valores
                    string[] row = new string[values.Length]; // definiendo el tamaño en el array

                    for (int j = 0; j < values.Length; j++)
                    {
                        row[j] = values[j].Trim();
                    }
                    dtGrid.Rows.Add(row[0], row[1], decimal.Parse(row[2]).ToString("f"), decimal.Parse(row[3]).ToString("f"), decimal.Parse(row[4]).ToString("f"));
                }
                CalculateTotal();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            // obtenemos la tecla  / caracter
            char c = (char)keyData;

            // validamos si el caracter es numero
            if (char.IsNumber(c))
            {
                this._barcode += c; 
            }

            if (c == (char)Keys.Return)
            {
                this.BuscarProducto_EnDatabase(this._barcode);
                this._barcode = "";
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BuscarProducto_EnDatabase(string barcode)
        {
            DataTable prod = producto.SearchByCode(barcode);
            if (prod != null && prod.Rows.Count > 0)
            {
                KryptonButton btn = new KryptonButton
                {
                    Tag = "|" + prod.Rows[0].Field<string>("codigo") + "|"
                    + prod.Rows[0].Field<string>("descripcion") + "|"
                    + prod.Rows[0].Field<decimal>("precio") + "|"
                    + prod.Rows[0].Field<decimal>("stock") + "|"
                };

                this.producto_Click(btn, null);
                btn.Dispose();
                txtSearch.Clear();
                txtSearch.Focus();
            }
            else
            {
                ClsCommon.Toast("PRODUCTO NO ENCONTRADO");
                txtSearch.Clear();
                txtSearch.Focus();
            }
        }

        /*private string Boleta_NextID()
        {
            Boleta bol = new Boleta();
            DataTable boldt = new DataTable();
            boldt = bol.NextID();

            string result = "";
            for (int i = 0; i < boldt.Rows.Count; i++)
            {
                result = boldt.Rows[i].Field<decimal>("numero").ToString();
            }

            return result;
        }*/

        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            kform.Show();
        }

        private void fOrders_Load(object sender, EventArgs e)
        {
            lblBoletaNumero.Values.ExtraText = boleta.NextID(); // Numero de boleta
            lblUsuario.Values.ExtraText = Session.user_fullname.ToUpper(); // Nombre de usuario
            this.ActiveControl = txtSearch;
            
        }

        private void fOrders_Resize(object sender, EventArgs e)
        {
            kSplitMain.SplitterDistance = 105;
        }

        private void fOrders_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void fOrders_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));

                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void fOrders_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void dtGrid_DoubleClick(object sender, EventArgs e)
        {
            kgToolbar.Visible = !kgToolbar.Visible;
        }

        private void bsCardsMode_Click(object sender, EventArgs e)
        {
            this.loadFamilias();
            khFamilias.Text = "FAMILIAS DE PRODUCTOS";
        }

        private void bsRowsMode_Click(object sender, EventArgs e)
        {
            panelProductos.Dock = DockStyle.Fill;
            panelCards.Visible = false;
            panelProductos.Visible = true;
            khFamilias.Text = "PRODUCTOS";
            this.loadProductos("todos");
        }

        private void btnHideToolBar_Click(object sender, EventArgs e)
        {
            kgToolbar.Visible = false;
        }

        private void btnAddProducto_Click(object sender, EventArgs e)
        {
            if (dtGrid.Rows.Count > 0)
            {
                string producto_codigo = dtGrid.CurrentRow.Cells["colcodigo"].Value.ToString();
                IncreaseDecreaseItem(producto_codigo, 1);
            }
        }

        private void btnSubProducto_Click(object sender, EventArgs e)
        {
            if (dtGrid.Rows.Count > 0)
            {
                string producto_codigo = dtGrid.CurrentRow.Cells["colcodigo"].Value.ToString();
                IncreaseDecreaseItem(producto_codigo, 0);
            }
        }

        private void btnRemoveProducto_Click(object sender, EventArgs e)
        {
            this.RemoveItem();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dtGrid.Rows.Count <= 0)
            {
                ClsCommon.Toast("PARA CANCELAR DEBES AGREGAR PRODUCTOS");
                return;
            }

            fConfirm f = new fConfirm("¿Confirmas cancelar la venta?");
            f.ShowDialog();

            if (ClsCommon.flag == 1)
            {
                dtGrid.Rows.Clear();
                CalculateTotal();
            }

        }

        private void btnSuspender_Click(object sender, EventArgs e)
        {
            if (dtGrid.Rows.Count > 0)
            {
                this.Suspend_Transaction();
            }
            else
            {
                ClsCommon.Toast("NO HAS AGREGADO PRODUCTOS A LA VENTA");
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            dtGrid.Rows.Clear();
            CalculateTotal();

            fRecovery f = new fRecovery();
            f.ShowDialog();
            if (!string.IsNullOrEmpty(ClsCommon.FileName_Ticket))
            {
                Recovery_Transaction(ClsCommon.FileName_Ticket);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dtGrid.Rows.Count <= 0)
            {
                ClsCommon.Toast("NO HAY PRODUCTOS AGREGADOS A LA VENTA");
                return;
            }

            // Crear boleta
            boleta.Numero = Convert.ToInt32(boleta.NextID());
            boleta.Total = decimal.Parse(khTotal.Values.Description);
            boleta.Items = decimal.Parse(lblItems.Values.ExtraText);
            boleta.Rut = "";
            boleta.Usuario_id = Convert.ToInt32(Session.user_id);

            // Lista de detalle boleta
            
            List<BoletaDetalle> detalle = new List<BoletaDetalle>();
            BoletaDetalle item;
            for (int i = 0; i < dtGrid.Rows.Count ; i++)
            {
                item = new BoletaDetalle
                {
                    Numero_boleta = boleta.Numero,
                    Cod_producto = dtGrid.Rows[i].Cells["colcodigo"].Value.ToString(),
                    Cantidad = float.Parse(dtGrid.Rows[i].Cells["colcantidad"].Value.ToString()),
                    Precio = float.Parse(dtGrid.Rows[i].Cells["colprecio"].Value.ToString()),
                    

                };
                detalle.Add(item);
            }
            fCash f = new fCash(boleta, detalle);
            f.ShowDialog();
            if (ClsCommon.payCommited)
            {
                dtGrid.Rows.Clear();
                lblBoletaNumero.Values.ExtraText = boleta.NextID();
                CalculateTotal();
                Delete_Retrieved_File();
            }

        }

        private void Delete_Retrieved_File()
        {
            try
            {
                if (!string.IsNullOrEmpty(Ticket_Name_Retrieved))
                {
                    File.Delete(Ticket_Name_Retrieved);
                    Ticket_Name_Retrieved = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
            {
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                    BuscarProducto_EnDatabase(txtSearch.Text.Trim());
                }
            }
        }

        private void fOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) this.Close();
            if (e.KeyData == Keys.F2) btnRecuperar_Click("", EventArgs.Empty);
            if (e.KeyData == Keys.F3) btnGuardar_Click("", EventArgs.Empty);
            if (e.KeyData == Keys.F4) btnSuspender_Click("", EventArgs.Empty);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClsUI.SoloDecimal(sender, e);
        }
    }
}
