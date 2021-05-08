
namespace SGI.Views
{
    partial class fProducts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fProducts));
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.btnExit = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDestroy = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtSearch = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.buttonSpecAny2 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kpList = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kpEdit = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kpFamily = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.dtGrid = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.COLCODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDescripcion = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny3 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.buttonSpecAny4 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.txtBarcode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny5 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.buttonSpecAny6 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.cmb = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpList)).BeginInit();
            this.kpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpEdit)).BeginInit();
            this.kpEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpFamily)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnExit});
            this.kryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeader1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(1144, 44);
            this.kryptonHeader1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonHeader1.StateCommon.Border.Width = 0;
            this.kryptonHeader1.TabIndex = 0;
            this.kryptonHeader1.Values.Description = "";
            this.kryptonHeader1.Values.Heading = "::: Productos";
            this.kryptonHeader1.Values.Image = null;
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnExit.UniqueName = "46D981A75C00467722A544B6DCF452D9";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 50);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OverrideDefault.Back.Color1 = System.Drawing.Color.Black;
            this.btnAdd.OverrideDefault.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnAdd.Size = new System.Drawing.Size(75, 56);
            this.btnAdd.StateCommon.Back.Color1 = System.Drawing.Color.Black;
            this.btnAdd.StateCommon.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnAdd.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnAdd.StateCommon.Border.Width = 0;
            this.btnAdd.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnAdd.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnAdd.StateNormal.Back.Color1 = System.Drawing.Color.Black;
            this.btnAdd.StateNormal.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Values.Image")));
            this.btnAdd.Values.Text = "";
            // 
            // btnDestroy
            // 
            this.btnDestroy.Location = new System.Drawing.Point(202, 50);
            this.btnDestroy.Name = "btnDestroy";
            this.btnDestroy.OverrideDefault.Back.Color1 = System.Drawing.Color.Black;
            this.btnDestroy.OverrideDefault.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnDestroy.Size = new System.Drawing.Size(75, 56);
            this.btnDestroy.StateCommon.Back.Color1 = System.Drawing.Color.Black;
            this.btnDestroy.StateCommon.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnDestroy.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDestroy.StateCommon.Border.Width = 0;
            this.btnDestroy.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnDestroy.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnDestroy.StateNormal.Back.Color1 = System.Drawing.Color.Black;
            this.btnDestroy.StateNormal.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnDestroy.TabIndex = 2;
            this.btnDestroy.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnDestroy.Values.Image")));
            this.btnDestroy.Values.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(107, 50);
            this.btnSave.Name = "btnSave";
            this.btnSave.OverrideDefault.Back.Color1 = System.Drawing.Color.Black;
            this.btnSave.OverrideDefault.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnSave.Size = new System.Drawing.Size(75, 56);
            this.btnSave.StateCommon.Back.Color1 = System.Drawing.Color.Black;
            this.btnSave.StateCommon.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnSave.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSave.StateCommon.Border.Width = 0;
            this.btnSave.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnSave.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnSave.StateNormal.Back.Color1 = System.Drawing.Color.Black;
            this.btnSave.StateNormal.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnSave.TabIndex = 3;
            this.btnSave.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Values.Image")));
            this.btnSave.Values.Text = "";
            // 
            // txtSearch
            // 
            this.txtSearch.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1,
            this.buttonSpecAny2});
            this.txtSearch.Location = new System.Drawing.Point(570, 106);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(562, 44);
            this.txtSearch.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.txtSearch.StateCommon.Border.Color2 = System.Drawing.Color.Gray;
            this.txtSearch.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtSearch.StateCommon.Border.Rounding = 1;
            this.txtSearch.StateCommon.Border.Width = 3;
            this.txtSearch.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.StateCommon.Content.Padding = new System.Windows.Forms.Padding(2, 6, -1, -1);
            this.txtSearch.TabIndex = 4;
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.Checked = ComponentFactory.Krypton.Toolkit.ButtonCheckState.Unchecked;
            this.buttonSpecAny1.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.buttonSpecAny1.Image = ((System.Drawing.Image)(resources.GetObject("buttonSpecAny1.Image")));
            this.buttonSpecAny1.UniqueName = "7AF85AC7B87D4C05B4ACC11C8B065BA5";
            // 
            // buttonSpecAny2
            // 
            this.buttonSpecAny2.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.buttonSpecAny2.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            this.buttonSpecAny2.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl;
            this.buttonSpecAny2.Text = "BUSCAR";
            this.buttonSpecAny2.UniqueName = "A651DF55150540C05798B1CFF3E85A84";
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Bar.CheckButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.BreadCrumb;
            this.kryptonNavigator1.Bar.TabBorderStyle = ComponentFactory.Krypton.Toolkit.TabBorderStyle.OneNote;
            this.kryptonNavigator1.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.kryptonNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Group.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.TabLowProfile;
            this.kryptonNavigator1.Group.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.TabLowProfile;
            this.kryptonNavigator1.Header.HeaderStyleBar = ComponentFactory.Krypton.Toolkit.HeaderStyle.Primary;
            this.kryptonNavigator1.Location = new System.Drawing.Point(107, 156);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.NavigatorMode = ComponentFactory.Krypton.Navigator.NavigatorMode.HeaderGroupTab;
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kpList,
            this.kpEdit,
            this.kpFamily});
            this.kryptonNavigator1.SelectedIndex = 2;
            this.kryptonNavigator1.Size = new System.Drawing.Size(942, 459);
            this.kryptonNavigator1.TabIndex = 5;
            // 
            // kpList
            // 
            this.kpList.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpList.Controls.Add(this.dtGrid);
            this.kpList.Flags = 65534;
            this.kpList.ImageMedium = ((System.Drawing.Image)(resources.GetObject("kpList.ImageMedium")));
            this.kpList.LastVisibleSet = true;
            this.kpList.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpList.Name = "kpList";
            this.kpList.Size = new System.Drawing.Size(940, 389);
            this.kpList.Text = "LISTADO";
            this.kpList.TextDescription = "";
            this.kpList.TextTitle = "LISTADO";
            this.kpList.ToolTipTitle = "Page ToolTip";
            this.kpList.UniqueName = "C5A6FF2B565843FE7EB4E6B66EEF1D8B";
            // 
            // kpEdit
            // 
            this.kpEdit.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpEdit.Controls.Add(this.cmb);
            this.kpEdit.Controls.Add(this.txtBarcode);
            this.kpEdit.Controls.Add(this.txtDescripcion);
            this.kpEdit.Flags = 65534;
            this.kpEdit.ImageMedium = ((System.Drawing.Image)(resources.GetObject("kpEdit.ImageMedium")));
            this.kpEdit.LastVisibleSet = true;
            this.kpEdit.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpEdit.Name = "kpEdit";
            this.kpEdit.Size = new System.Drawing.Size(940, 389);
            this.kpEdit.Text = "GESTIONAR";
            this.kpEdit.TextDescription = "";
            this.kpEdit.TextTitle = "GESTIONAR";
            this.kpEdit.ToolTipTitle = "Page ToolTip";
            this.kpEdit.UniqueName = "A9B401EA03814B95368F6F2D6A4A3B50";
            // 
            // kpFamily
            // 
            this.kpFamily.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpFamily.Flags = 65534;
            this.kpFamily.ImageMedium = ((System.Drawing.Image)(resources.GetObject("kpFamily.ImageMedium")));
            this.kpFamily.LastVisibleSet = true;
            this.kpFamily.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpFamily.Name = "kpFamily";
            this.kpFamily.Size = new System.Drawing.Size(940, 389);
            this.kpFamily.Text = "FAMILIAS";
            this.kpFamily.TextDescription = "";
            this.kpFamily.TextTitle = "FAMILIAS";
            this.kpFamily.ToolTipTitle = "Page ToolTip";
            this.kpFamily.UniqueName = "2F582F14F5BE407E3F94E6CFE69208FE";
            // 
            // dtGrid
            // 
            this.dtGrid.AllowUserToAddRows = false;
            this.dtGrid.AllowUserToDeleteRows = false;
            this.dtGrid.AllowUserToResizeRows = false;
            this.dtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COLCODIGO,
            this.COLNAME});
            this.dtGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGrid.Location = new System.Drawing.Point(0, 0);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.ReadOnly = true;
            this.dtGrid.RowHeadersVisible = false;
            this.dtGrid.RowHeadersWidth = 50;
            this.dtGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrid.Size = new System.Drawing.Size(940, 389);
            this.dtGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dtGrid.StateCommon.DataCell.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.dtGrid.StateCommon.DataCell.Content.Color1 = System.Drawing.Color.Black;
            this.dtGrid.StateCommon.DataCell.Content.Color2 = System.Drawing.Color.Black;
            this.dtGrid.StateCommon.HeaderColumn.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.dtGrid.StateCommon.HeaderColumn.Border.Rounding = 0;
            this.dtGrid.StateCommon.HeaderColumn.Border.Width = 0;
            this.dtGrid.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtGrid.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtGrid.TabIndex = 0;
            // 
            // COLCODIGO
            // 
            this.COLCODIGO.HeaderText = "CODIGO";
            this.COLCODIGO.Name = "COLCODIGO";
            this.COLCODIGO.ReadOnly = true;
            // 
            // COLNAME
            // 
            this.COLNAME.HeaderText = "DESCRIPCION";
            this.COLNAME.Name = "COLNAME";
            this.COLNAME.ReadOnly = true;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny3,
            this.buttonSpecAny4});
            this.txtDescripcion.Location = new System.Drawing.Point(20, 14);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(468, 44);
            this.txtDescripcion.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.txtDescripcion.StateCommon.Border.Color2 = System.Drawing.Color.Gray;
            this.txtDescripcion.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtDescripcion.StateCommon.Border.Rounding = 1;
            this.txtDescripcion.StateCommon.Border.Width = 3;
            this.txtDescripcion.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.StateCommon.Content.Padding = new System.Windows.Forms.Padding(2, 6, -1, -1);
            this.txtDescripcion.TabIndex = 5;
            // 
            // buttonSpecAny3
            // 
            this.buttonSpecAny3.Checked = ComponentFactory.Krypton.Toolkit.ButtonCheckState.Unchecked;
            this.buttonSpecAny3.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.buttonSpecAny3.Image = ((System.Drawing.Image)(resources.GetObject("buttonSpecAny3.Image")));
            this.buttonSpecAny3.UniqueName = "7AF85AC7B87D4C05B4ACC11C8B065BA5";
            // 
            // buttonSpecAny4
            // 
            this.buttonSpecAny4.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.buttonSpecAny4.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            this.buttonSpecAny4.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl;
            this.buttonSpecAny4.Text = "DESCRIPCION";
            this.buttonSpecAny4.UniqueName = "A651DF55150540C05798B1CFF3E85A84";
            // 
            // txtBarcode
            // 
            this.txtBarcode.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny5,
            this.buttonSpecAny6});
            this.txtBarcode.Location = new System.Drawing.Point(20, 71);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(468, 44);
            this.txtBarcode.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.txtBarcode.StateCommon.Border.Color2 = System.Drawing.Color.Gray;
            this.txtBarcode.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtBarcode.StateCommon.Border.Rounding = 1;
            this.txtBarcode.StateCommon.Border.Width = 3;
            this.txtBarcode.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.StateCommon.Content.Padding = new System.Windows.Forms.Padding(2, 6, -1, -1);
            this.txtBarcode.TabIndex = 6;
            // 
            // buttonSpecAny5
            // 
            this.buttonSpecAny5.Checked = ComponentFactory.Krypton.Toolkit.ButtonCheckState.Unchecked;
            this.buttonSpecAny5.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.buttonSpecAny5.Image = ((System.Drawing.Image)(resources.GetObject("buttonSpecAny5.Image")));
            this.buttonSpecAny5.UniqueName = "7AF85AC7B87D4C05B4ACC11C8B065BA5";
            // 
            // buttonSpecAny6
            // 
            this.buttonSpecAny6.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.buttonSpecAny6.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            this.buttonSpecAny6.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl;
            this.buttonSpecAny6.Text = "CODIGO";
            this.buttonSpecAny6.UniqueName = "A651DF55150540C05798B1CFF3E85A84";
            // 
            // cmb
            // 
            this.cmb.DropDownWidth = 468;
            this.cmb.Location = new System.Drawing.Point(20, 126);
            this.cmb.Name = "cmb";
            this.cmb.Size = new System.Drawing.Size(468, 21);
            this.cmb.TabIndex = 7;
            this.cmb.Text = "kryptonComboBox1";
            // 
            // fProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 678);
            this.Controls.Add(this.kryptonNavigator1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDestroy);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.kryptonHeader1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "fProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fProducts";
            this.Load += new System.EventHandler(this.fProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpList)).EndInit();
            this.kpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpEdit)).EndInit();
            this.kpEdit.ResumeLayout(false);
            this.kpEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpFamily)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnExit;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDestroy;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearch;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny2;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kpList;
        private ComponentFactory.Krypton.Navigator.KryptonPage kpEdit;
        private ComponentFactory.Krypton.Navigator.KryptonPage kpFamily;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dtGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLCODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLNAME;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBarcode;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny5;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDescripcion;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny3;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny4;
    }
}