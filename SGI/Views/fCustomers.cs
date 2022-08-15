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
    public partial class fCustomers : KryptonForm
    {
        #region 'VARIABLES'
        private readonly Cliente cli = new Cliente();
        private readonly CuentaCorriente ctacte = new CuentaCorriente();

        private DataTable dtCli = new DataTable();
        private DataTable dtCtaCte = new DataTable();

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private KryptonForm kform;

        #endregion
        public fCustomers(KryptonForm kf)
        {
            InitializeComponent();
            this.kform = kf;
            this.Data();
            
        }


        #region 'METODOS'
        private void DataCuentasCorrientes()
        {
            dtCtaCte.Columns.Clear();
            ctacte.Rut_cliente = ClsCommon.QuitarFormatoRut(txtRut.Text.Trim());
            dtCtaCte = ctacte.Data();
            dtGridCuentaCte.DataSource = dtCtaCte;
        }

        private void Data()
        {
            this.dtCli.Columns.Clear();
            this.dtCli = this.cli.Data();
            dtGrid.DataSource = dtCli;

        }

        private void ResetUI()
        {
            txtRut.Enabled = true;
            txtRut.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtComuna.Clear();
            txtCiudad.Clear();
            txtTelefono.Clear();
            dtGridCuentaCte.Columns.Clear();
            txtAbonar.Clear();
            txtRutAbono.Clear();
            khTotal.Values.Description = "0.0";
        }

        private void CreateorUpdate()
        {
            // Seleccionar primera pestaña
            this.kryptonNavigator1.SelectedIndex = 1;

            if (string.IsNullOrEmpty(this.txtRut.Text))
            {
                ClsCommon.Toast("Ingrese rut del cliente");
                this.txtRut.Focus();
                return;
            }
            if (ClsCommon.ValidaRut(txtRut.Text.Trim()) == false)
            {
                ClsCommon.Toast(ClsCommon.RutNoValido);
                txtRut.Focus();
                return;
            }

            cli.Rut = ClsCommon.QuitarFormatoRut(txtRut.Text.Trim());
            cli.Nombre = txtNombre.Text.Trim();
            cli.Direccion = txtDireccion.Text.Trim();
            cli.Comuna = txtComuna.Text.Trim();
            cli.Ciudad = txtCiudad.Text.Trim();
            cli.Telefono = decimal.Parse(txtTelefono.Text.Trim());

            ClsCommon.Toast(cli.SearchRut(ClsCommon.QuitarFormatoRut(txtRut.Text.Trim())) == true ? cli.Update() : cli.Create());

            this.Data();

            this.kryptonNavigator1.SelectedIndex = 0;

            this.ResetUI();
        }

        private void Destroy()
        {
            cli.Rut = ClsCommon.QuitarFormatoRut(txtRut.Text.Trim());
            ClsCommon.Toast(cli.Destroy());

            this.ResetUI();

            this.Data();

            ClsCommon.flag = 0;

            this.kryptonNavigator1.SelectedIndex = 0;
        }

        #endregion 'METODOS'

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fCustomers_FormClosed(object sender, FormClosedEventArgs e)
        {
            kform.Show();
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

        private void dtGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                this.txtRut.Text = ClsCommon.FormatearRut(this.dtGrid.CurrentRow.Cells["RUT"].Value.ToString());
                this.txtRut.Enabled = false;
                this.txtNombre.Text = this.dtGrid.CurrentRow.Cells["NOMBRE"].Value.ToString();
                this.txtDireccion.Text = this.dtGrid.CurrentRow.Cells["DIRECCION"].Value.ToString();
                this.txtComuna.Text = this.dtGrid.CurrentRow.Cells["COMUNA"].Value.ToString();
                this.txtCiudad.Text = this.dtGrid.CurrentRow.Cells["CIUDAD"].Value.ToString();
                this.txtTelefono.Text = this.dtGrid.CurrentRow.Cells["TELEFONO"].Value.ToString();

                DataCuentasCorrientes();

                this.kryptonNavigator1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.ResetUI();
            this.kryptonNavigator1.SelectedIndex = 1;
            txtRut.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTelefono.Text.Trim().Length != 11)
            {
                ClsCommon.Toast("El Teléfono debe tener 11 dígitos");
                return; //Salimos
            }

            if (ClsCommon.ValidaRut(txtRut.Text.Trim()) == false)
            {
                ClsCommon.Toast(ClsCommon.RutNoValido);
                return; //Salimos
            }

            //Si es correcto seguimos

            this.CreateorUpdate();
        }

        private void btnUpdateCtaCte_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRut.Text))
            {
                ClsCommon.Toast("Ingrese rut de cliente");
                txtRut.Focus();
                return;
            }
            this.DataCuentasCorrientes();
        }

        private void btnDestroy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRut.Text))
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

        private void txtRut_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtRut_KeyUp(object sender, KeyEventArgs e)
        {
            txtRut.Text = ClsCommon.FormatearRut(txtRut.Text);

            txtRut.SelectionStart = txtRut.Text.Length;
            txtRut.SelectionLength = 0;
        }

        private void txtRutAbono_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtRutAbono_KeyUp(object sender, KeyEventArgs e)
        {
            txtRutAbono.Text = ClsCommon.FormatearRut(txtRutAbono.Text);

            txtRutAbono.SelectionStart = txtRutAbono.Text.Length;
            txtRutAbono.SelectionLength = 0;
        }

        private void txtRut_TextChanged(object sender, EventArgs e)
        {
            txtRutAbono.Text = txtRut.Text;
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

        private void kpAbonar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (ClsCommon.ValidaRut(txtRutAbono.Text))
            {
                this.ctacte.Rut_cliente = ClsCommon.QuitarFormatoRut(txtRutAbono.Text);
                dtCtaCte = this.ctacte.Search();

                for (int i = 0; i < dtCtaCte.Rows.Count; i++)
                {
                    khTotal.Values.Description = dtCtaCte.Rows[i].Field<decimal>("saldo").ToString();
                }

                if (decimal.Parse(khTotal.Values.Description) < 0)
                {
                    khTotal.Values.Description = "0.0";
                }

                return;
            }

            ClsCommon.Toast(ClsCommon.RutNoValido);
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            if (ClsCommon.ValidaRut(txtRutAbono.Text))
            {
                if (decimal.Parse(khTotal.Values.Description) == 0)
                {
                    ClsCommon.Toast("Cliente no tiene deuda");
                    return;
                }
                this.ctacte.Rut_cliente = ClsCommon.QuitarFormatoRut(txtRutAbono.Text);
                this.ctacte.Abono = decimal.Parse(khTotal.Values.Description);
                
                if (this.ctacte.Pay())
                {
                    ClsCommon.Toast("Monto total de cliente pagado");
                    ResetUI();
                    DataCuentasCorrientes();
                    Data();
                    this.kryptonNavigator1.SelectedIndex = 0;

                }
                else
                {
                    ClsCommon.Toast("No se logró abonar a cuenta de cliente");
                }

                return;
            }

            ClsCommon.Toast(ClsCommon.RutNoValido);
        }

        private void txtAbonar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClsUI.SoloDecimal(sender, e);
        }

        private void txtAbonar_Validated(object sender, EventArgs e)
        {
            txtAbonar.Text = ClsUI.Divisa(txtAbonar.Text.Trim());
        }

        private void btnAbonar_Click(object sender, EventArgs e)
        {
            if (ClsCommon.ValidaRut(txtRutAbono.Text))
            {
                this.ctacte.Rut_cliente = ClsCommon.QuitarFormatoRut(txtRutAbono.Text);
                this.ctacte.Abono = decimal.Parse(txtAbonar.Text);
                if (this.ctacte.Pay())
                {
                    ClsCommon.Toast("Monto abonado a cuenta de cliente");
                    ResetUI();
                    DataCuentasCorrientes();
                    Data();
                    this.kryptonNavigator1.SelectedIndex = 0;
                }
                else
                {
                    ClsCommon.Toast("No se logró abonar a cuenta de cliente");
                }

                return;
            }

            ClsCommon.Toast(ClsCommon.RutNoValido);
        }
    }
}
