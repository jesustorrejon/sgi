using ComponentFactory.Krypton.Navigator;
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
    public partial class fLogin : KryptonForm
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text.Trim()))
            {
                ClsCommon.Toast("Ingresa el usuario");
                txtUsuario.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                ClsCommon.Toast("Ingresa la contraseña");
                txtPassword.Focus();
                return;
            }

            User us = new User
            {
                Username = txtUsuario.Text.Trim().ToUpper(),
                Password = ClsCommon.EncrypByMD5(txtPassword.Text.Trim())
                //Password = txtPassword.Text.Trim()
            };

            DataTable dt = us.Login();
            if (dt !=null && dt.Rows.Count > 0)
            {
                Session.user_id = dt.Rows[0].Field<decimal>("id");
                Session.username = dt.Rows[0].Field<string>("usuario");
                Session.user_fullname = dt.Rows[0].Field<string>("nombre");
                Session.user_status = dt.Rows[0].Field<string>("estado");
                Session.user_profile = dt.Rows[0].Field<string>("perfil");

                if (Session.user_status != "ACTIVO")
                {
                    ClsCommon.Toast($"Usuario {Session.user_status.ToLower()}");
                    return;
                }

                this.Hide();

                using (fMenu f = new fMenu())
                {
                    f.ShowDialog();
                }

                this.Close();
            }
            else
            {
                txtUsuario.Clear();
                txtPassword.Clear();
                ClsCommon.Toast("Usuario o Clave incorrectas");
                txtUsuario.Focus();
            }

            
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            if (navigatorLeft.NavigatorMode == NavigatorMode.HeaderBarCheckButtonGroup)
            {
                navigatorLeft.NavigatorMode = NavigatorMode.HeaderBarCheckButtonOnly;
                buttonLeft.TypeRestricted = PaletteNavButtonSpecStyle.ArrowRight; // cambiar icono de buttonspec a derecha

                this.Size = new Size(355, 328);
                lblHead.Location = new Point(45, 9);
                txtUsuario.Location = new Point(55, 41);
                txtPassword.Location = new Point(55, 119);
                btnLogin.Location = new Point(55, 205);
                lblLeyenda.Location = new Point(55,244);
            }
            else
            {
                navigatorLeft.NavigatorMode = NavigatorMode.HeaderBarCheckButtonGroup;
                buttonLeft.TypeRestricted = PaletteNavButtonSpecStyle.ArrowLeft; // cambiar icono de buttonspec a derecha

                this.Size = new Size(498, 328);
                lblHead.Location = new Point(202, 9);
                txtUsuario.Location = new Point(202, 44);
                txtPassword.Location = new Point(202, 94);
                btnLogin.Location = new Point(202, 175);
                lblLeyenda.Location = new Point(198, 244);
            }
        }

        private void fLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) btnLogin_Click("", EventArgs.Empty);


        }
    }
}
