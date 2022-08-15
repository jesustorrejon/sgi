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
    public partial class fUsers : KryptonForm
    {

        #region VARIABLES
        private int id = 0;
        private readonly User us = new User();
        private DataTable data = new DataTable();
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private KryptonForm kform;

        #endregion

        #region Metodos
        private void Data()
        {
            this.dtGrid.Columns.Clear();
            this.data = us.Data();
            this.dtGrid.DataSource = data;
            this.dtGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dtGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dtGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dtGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dtGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dtGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        }

        private void ResetUI()
        {
            this.txtNombre.Clear();
            this.txtTelefono.Clear();
            this.txtUsername.Clear();
            this.txtPassword.Clear();
            this.btnAdminPerfil.Checked = true;
            this.btnEstado.Checked = true;

            this.txtNombre.Focus();
        }

        private void CreateOrUpdate()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                ClsCommon.Toast("Debes ingresar el nombre");
                txtNombre.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                ClsCommon.Toast("Debes ingresar el nombre de usuario");
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                ClsCommon.Toast("Debes ingresar la clave de usuario");
                txtPassword.Focus();
                return;
            }

            us.Name = txtNombre.Text.Trim();
            us.Phone = txtTelefono.Text.Trim();
            us.Username = txtUsername.Text.Trim();
            us.Password = ClsCommon.EncrypByMD5(txtPassword.Text.Trim());
            us.Profile = (btnAdminPerfil.Checked ? "Administrador" : "Empleado");
            us.Status = (btnEstado.Checked ? "Activo" : "Suspendido");

            ClsCommon.Toast(us.SearchCode(txtUsername.Text) == true ? us.Update() : us.Create()) ;

            
            this.Data();
            this.kryptonNavigator1.SelectedIndex = 0;
            this.ResetUI();
        }

        private void Destroy()
        {
            if (this.id <= 0)
            {
                ClsCommon.Toast("Debes seleccionar el registro a eliminar");
                this.dtGrid.Focus();
                return;
            }

            us.Id = id;
            ClsCommon.Toast(us.Destroy());

            this.ResetUI();
            this.Data();

            ClsCommon.flag = 0;

            kryptonNavigator1.SelectedIndex = 0;
        }




        #endregion
        public fUsers( KryptonForm kf)
        {
            InitializeComponent();
            this.kform = kf;
            this.Data();
        }

        private void fUsers_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.CreateOrUpdate();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtGrid_DoubleClick(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dtGrid.CurrentRow.Cells["ID"].Value);
            txtUsername.Text = dtGrid.CurrentRow.Cells["USUARIO"].Value.ToString();
            txtNombre.Text = dtGrid.CurrentRow.Cells["NOMBRE"].Value.ToString();
            txtTelefono.Text = dtGrid.CurrentRow.Cells["TELEFONO"].Value.ToString();

            btnEstado.Checked = (dtGrid.CurrentRow.Cells["ESTADO"].Value.ToString().Trim().ToUpper() == "ACTIVO" ? true : false);

            if(dtGrid.CurrentRow.Cells["ESTADO"].Value.ToString().Trim().ToUpper() == "ADMINISTRADOR")
            {
                btnAdminPerfil.Checked = true;
                btnEmpleadoPerfil.Checked = false;
            }
            else
            {
                btnAdminPerfil.Checked = false;
                btnEmpleadoPerfil.Checked = true;
            }

            kryptonNavigator1.SelectedIndex = 1;
        }

        private void btnDestroy_Click(object sender, EventArgs e)
        {
            fConfirm f = new fConfirm("Eliminar Registro");
            f.ShowDialog();

            if (ClsCommon.flag == 1)
            {
                this.Destroy();
                ClsCommon.flag = 0;
            }
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
                dtGrid.Columns.Clear();

                // Traer datos de procedimiento almacenado al datagrid
                this.data = this.us.Search(txtSearch.Text);
                dtGrid.DataSource = data;

                
                this.dtGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dtGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dtGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dtGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dtGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dtGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.ResetUI();

            kryptonNavigator1.SelectedIndex = 1;
        }

        private void kryptonNavigator1_Selected(object sender, ComponentFactory.Krypton.Navigator.KryptonPageEventArgs e)
        {
            if (e.Item.Name.ToString().Trim().ToUpper() == "KPGESTIONAR")
            {
                txtNombre.Focus();
            }
        }

        private void btnAdminPerfil_Click(object sender, EventArgs e)
        {
            btnEmpleadoPerfil.Checked = false;
            btnAdminPerfil.Checked = true;
        }

        private void btnEmpleadoPerfil_Click(object sender, EventArgs e)
        {
            btnAdminPerfil.Checked = false;
            btnEmpleadoPerfil.Checked = true;
        }

        private void fUsers_FormClosed(object sender, FormClosedEventArgs e)
        {
            kform.Show(); 
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

        private void kryptonHeader1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }
    }
}
