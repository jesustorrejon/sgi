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
    public partial class fCash : KryptonForm
    {
        private Boleta boleta = new Boleta();
        private List<BoletaDetalle> listDetalle = new List<BoletaDetalle>();
        private CuentaCorriente ctacte = new CuentaCorriente();
        private Producto prod = new Producto();


        public fCash(Boleta bol, List<BoletaDetalle> detalle)
        {
            InitializeComponent();
            boleta = bol;
            listDetalle = detalle;

            khTotal.Values.Description = boleta.Total.ToString();
            khTotalCtaCte.Values.Description = boleta.Total.ToString();
            dateFechaCompromiso.Value = DateTime.Now;

            kryptonNavigator1.SelectedIndex = 0;
            FocusTextBox();
        }

        #region 'METODOS'

        private void calculateTotal()
        {
            decimal total, efectivo, vuelto;

            total = decimal.Parse(khTotal.Values.Description);
            if (string.IsNullOrEmpty(txtEfectivo.Text))
            {
                efectivo = 0;
            }
            else
            {
                efectivo = decimal.Parse(txtEfectivo.Text);
            }

            vuelto = efectivo - total;

            khVuelto.Values.Description = vuelto.ToString();
        }

        private void FocusTextBox()
        {
            if (kryptonNavigator1.SelectedIndex == 0)
            {
                this.txtRut1.Focus();
                return;
            }
            if (kryptonNavigator1.SelectedIndex == 1)
            {
                this.txtRut.Focus();
                return;
            }

        }

        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kpEfectivo_Load(object sender, EventArgs e)
        {
            
        }

        private void kpCtaCte_Load(object sender, EventArgs e)
        {
            
        }

        private void txtEfectivo_Validated(object sender, EventArgs e)
        {
            txtEfectivo.Text = ClsUI.Divisa(txtEfectivo.Text.Trim());
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClsUI.SoloDecimal(sender, e);
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            calculateTotal();
        }

        private void fCash_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtRut1;
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (ClsCommon.ValidaRut(txtRut1.Text))
            {
                boleta.Fecha_compromiso = DateTime.Now;
                boleta.Rut = ClsCommon.QuitarFormatoRut(txtRut1.Text.Trim());
                boleta.Mediopago = "EFECTIVO";

                if (prod.noStock(listDetalle))
                {
                    ClsCommon.Toast("No hay stock suficiente");
                    return;
                }

                if (boleta.Create(boleta, listDetalle) == false)
                {
                    ClsCommon.Toast("Cliente no registrado");
                    txtRut1.Text = "99.999.999-9";
                    txtRut1.Focus();
                    return;
                }

                ClsCommon.Toast($"Boleta N° {boleta.Numero} registrada");
                ClsCommon.payCommited = true;
                this.Close();
                return;
            }
            else
            {
                ClsCommon.Toast(ClsCommon.RutNoValido);
                txtRut1.Focus();
            }
            
            
            
        }

        private void kryptonNavigator1_Click(object sender, EventArgs e)
        {
            this.FocusTextBox();
        }

        private void txtRut1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtRut1_KeyUp(object sender, KeyEventArgs e)
        {
            txtRut1.Text = ClsCommon.FormatearRut(txtRut1.Text);

            txtRut1.SelectionStart = txtRut1.Text.Length;
            txtRut1.SelectionLength = 0;
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

        private void btnAutorizar_Click(object sender, EventArgs e)
        {
            if (ClsCommon.ValidaRut(txtRut.Text))
            {
                if (txtRut.Text.Trim() == "99.999.999-9")
                {
                    ClsCommon.Toast("Rut no autorizado");
                    txtRut.Focus();
                    return;
                }

                boleta.Fecha_compromiso = dateFechaCompromiso.Value;
                boleta.Rut = ClsCommon.QuitarFormatoRut(txtRut.Text.Trim());
                boleta.Mediopago = "CUENTA CORRIENTE";
                
                if (boleta.Create(boleta, listDetalle) == false)
                {
                    ClsCommon.Toast("Cliente no registrado");
                    txtRut1.Focus();
                    return;
                }

                ctacte.Create(boleta); // registrar cargo en cuenta corriente de cliente

                ClsCommon.Toast($"Boleta N° {boleta.Numero} registrada");
                ClsCommon.payCommited = true;
                this.Close();
                return;
            }
            else
            {
                ClsCommon.Toast(ClsCommon.RutNoValido);
                txtRut.Focus();
            }
        }
    }
}
