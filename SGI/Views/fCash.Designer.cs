
namespace SGI.Views
{
    partial class fCash
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCash));
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.btnExit = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kpEfectivo = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.txtRut1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.buttonSpecAny2 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnPagar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtEfectivo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny14 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.buttonSpecAny15 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.khVuelto = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.khTotal = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.kpCtaCte = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.lblFechaCompromiso = new System.Windows.Forms.Label();
            this.dateFechaCompromiso = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.btnAutorizar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.khTotalCtaCte = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.txtRut = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny29 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.buttonSpecAny30 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kpEdit = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpEfectivo)).BeginInit();
            this.kpEfectivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpCtaCte)).BeginInit();
            this.kpCtaCte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnExit});
            this.kryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeader1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(474, 44);
            this.kryptonHeader1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonHeader1.StateCommon.Border.Width = 0;
            this.kryptonHeader1.TabIndex = 3;
            this.kryptonHeader1.Values.Description = "";
            this.kryptonHeader1.Values.Heading = "::: Pagar";
            this.kryptonHeader1.Values.Image = null;
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnExit.UniqueName = "46D981A75C00467722A544B6DCF452D9";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Bar.CheckButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.BreadCrumb;
            this.kryptonNavigator1.Bar.TabBorderStyle = ComponentFactory.Krypton.Toolkit.TabBorderStyle.OneNote;
            this.kryptonNavigator1.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.kryptonNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Group.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.TabLowProfile;
            this.kryptonNavigator1.Group.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.TabLowProfile;
            this.kryptonNavigator1.Header.HeaderStyleBar = ComponentFactory.Krypton.Toolkit.HeaderStyle.Primary;
            this.kryptonNavigator1.Location = new System.Drawing.Point(0, 44);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.NavigatorMode = ComponentFactory.Krypton.Navigator.NavigatorMode.HeaderGroupTab;
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kpEfectivo,
            this.kpCtaCte,
            this.kryptonPage1});
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(474, 360);
            this.kryptonNavigator1.TabIndex = 8;
            this.kryptonNavigator1.Click += new System.EventHandler(this.kryptonNavigator1_Click);
            // 
            // kpEfectivo
            // 
            this.kpEfectivo.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpEfectivo.Controls.Add(this.txtRut1);
            this.kpEfectivo.Controls.Add(this.btnPagar);
            this.kpEfectivo.Controls.Add(this.txtEfectivo);
            this.kpEfectivo.Controls.Add(this.khVuelto);
            this.kpEfectivo.Controls.Add(this.khTotal);
            this.kpEfectivo.Flags = 65534;
            this.kpEfectivo.ImageMedium = ((System.Drawing.Image)(resources.GetObject("kpEfectivo.ImageMedium")));
            this.kpEfectivo.LastVisibleSet = true;
            this.kpEfectivo.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpEfectivo.Name = "kpEfectivo";
            this.kpEfectivo.Size = new System.Drawing.Size(472, 290);
            this.kpEfectivo.Text = "EFECTIVO (F2)";
            this.kpEfectivo.TextDescription = "";
            this.kpEfectivo.TextTitle = "EFECTIVO";
            this.kpEfectivo.ToolTipTitle = "Page ToolTip";
            this.kpEfectivo.UniqueName = "C5A6FF2B565843FE7EB4E6B66EEF1D8B";
            this.kpEfectivo.Load += new System.EventHandler(this.kpEfectivo_Load);
            // 
            // txtRut1
            // 
            this.txtRut1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1,
            this.buttonSpecAny2});
            this.txtRut1.Location = new System.Drawing.Point(75, 15);
            this.txtRut1.Name = "txtRut1";
            this.txtRut1.Size = new System.Drawing.Size(269, 44);
            this.txtRut1.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.txtRut1.StateCommon.Border.Color2 = System.Drawing.Color.Gray;
            this.txtRut1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtRut1.StateCommon.Border.Rounding = 1;
            this.txtRut1.StateCommon.Border.Width = 3;
            this.txtRut1.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRut1.StateCommon.Content.Padding = new System.Windows.Forms.Padding(2, 6, -1, -1);
            this.txtRut1.TabIndex = 0;
            this.txtRut1.Text = "99.999.999-9";
            this.txtRut1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRut1_KeyPress);
            this.txtRut1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRut1_KeyUp);
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
            this.buttonSpecAny2.Text = "RUT";
            this.buttonSpecAny2.UniqueName = "A651DF55150540C05798B1CFF3E85A84";
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(132, 237);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.OverrideDefault.Back.Color1 = System.Drawing.Color.Black;
            this.btnPagar.OverrideDefault.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnPagar.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPagar.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPagar.Size = new System.Drawing.Size(130, 45);
            this.btnPagar.StateCommon.Back.Color1 = System.Drawing.Color.Black;
            this.btnPagar.StateCommon.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnPagar.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPagar.StateCommon.Border.Width = 0;
            this.btnPagar.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnPagar.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnPagar.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPagar.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPagar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.StateNormal.Back.Color1 = System.Drawing.Color.Black;
            this.btnPagar.StateNormal.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnPagar.TabIndex = 2;
            this.btnPagar.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnPagar.Values.Image")));
            this.btnPagar.Values.Text = "Pagar";
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny14,
            this.buttonSpecAny15});
            this.txtEfectivo.Location = new System.Drawing.Point(75, 65);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(269, 44);
            this.txtEfectivo.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.txtEfectivo.StateCommon.Border.Color2 = System.Drawing.Color.Gray;
            this.txtEfectivo.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtEfectivo.StateCommon.Border.Rounding = 1;
            this.txtEfectivo.StateCommon.Border.Width = 3;
            this.txtEfectivo.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.StateCommon.Content.Padding = new System.Windows.Forms.Padding(2, 6, -1, -1);
            this.txtEfectivo.TabIndex = 1;
            this.txtEfectivo.Text = "0.00";
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEfectivo.TextChanged += new System.EventHandler(this.txtEfectivo_TextChanged);
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
            this.txtEfectivo.Validated += new System.EventHandler(this.txtEfectivo_Validated);
            // 
            // buttonSpecAny14
            // 
            this.buttonSpecAny14.Checked = ComponentFactory.Krypton.Toolkit.ButtonCheckState.Unchecked;
            this.buttonSpecAny14.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.buttonSpecAny14.Image = ((System.Drawing.Image)(resources.GetObject("buttonSpecAny14.Image")));
            this.buttonSpecAny14.UniqueName = "7AF85AC7B87D4C05B4ACC11C8B065BA5";
            // 
            // buttonSpecAny15
            // 
            this.buttonSpecAny15.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.buttonSpecAny15.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            this.buttonSpecAny15.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl;
            this.buttonSpecAny15.Text = "EFECTIVO";
            this.buttonSpecAny15.UniqueName = "A651DF55150540C05798B1CFF3E85A84";
            // 
            // khVuelto
            // 
            this.khVuelto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.khVuelto.AutoSize = false;
            this.khVuelto.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.khVuelto.Location = new System.Drawing.Point(75, 163);
            this.khVuelto.Name = "khVuelto";
            this.khVuelto.Size = new System.Drawing.Size(269, 42);
            this.khVuelto.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khVuelto.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khVuelto.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.khVuelto.StateCommon.Border.Rounding = 3;
            this.khVuelto.StateCommon.Border.Width = 2;
            this.khVuelto.StateCommon.Content.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khVuelto.StateCommon.Content.LongText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khVuelto.StateCommon.Content.LongText.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khVuelto.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khVuelto.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khVuelto.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khVuelto.TabIndex = 15;
            this.khVuelto.Values.Description = "0.0";
            this.khVuelto.Values.Heading = "VUELTO";
            this.khVuelto.Values.Image = null;
            // 
            // khTotal
            // 
            this.khTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.khTotal.AutoSize = false;
            this.khTotal.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.khTotal.Location = new System.Drawing.Point(75, 115);
            this.khTotal.Name = "khTotal";
            this.khTotal.Size = new System.Drawing.Size(269, 42);
            this.khTotal.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khTotal.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khTotal.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.khTotal.StateCommon.Border.Rounding = 3;
            this.khTotal.StateCommon.Border.Width = 2;
            this.khTotal.StateCommon.Content.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khTotal.StateCommon.Content.LongText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khTotal.StateCommon.Content.LongText.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khTotal.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khTotal.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khTotal.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khTotal.TabIndex = 14;
            this.khTotal.Values.Description = "0.0";
            this.khTotal.Values.Heading = "TOTAL";
            this.khTotal.Values.Image = null;
            // 
            // kpCtaCte
            // 
            this.kpCtaCte.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpCtaCte.Controls.Add(this.lblFechaCompromiso);
            this.kpCtaCte.Controls.Add(this.dateFechaCompromiso);
            this.kpCtaCte.Controls.Add(this.btnAutorizar);
            this.kpCtaCte.Controls.Add(this.khTotalCtaCte);
            this.kpCtaCte.Controls.Add(this.txtRut);
            this.kpCtaCte.Flags = 65534;
            this.kpCtaCte.ImageMedium = ((System.Drawing.Image)(resources.GetObject("kpCtaCte.ImageMedium")));
            this.kpCtaCte.LastVisibleSet = true;
            this.kpCtaCte.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpCtaCte.Name = "kpCtaCte";
            this.kpCtaCte.Size = new System.Drawing.Size(472, 290);
            this.kpCtaCte.Text = "CUENTA CORRIENTE (F3)";
            this.kpCtaCte.TextDescription = "";
            this.kpCtaCte.TextTitle = "CUENTA CORRIENTE";
            this.kpCtaCte.ToolTipTitle = "Page ToolTip";
            this.kpCtaCte.UniqueName = "6F9DF648615B4DAE3FA78A3A9A30C444";
            // 
            // lblFechaCompromiso
            // 
            this.lblFechaCompromiso.AutoSize = true;
            this.lblFechaCompromiso.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaCompromiso.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCompromiso.Location = new System.Drawing.Point(11, 88);
            this.lblFechaCompromiso.Name = "lblFechaCompromiso";
            this.lblFechaCompromiso.Size = new System.Drawing.Size(212, 21);
            this.lblFechaCompromiso.TabIndex = 21;
            this.lblFechaCompromiso.Text = "Fecha de Compromiso";
            // 
            // dateFechaCompromiso
            // 
            this.dateFechaCompromiso.CalendarTodayDate = new System.DateTime(2021, 6, 17, 0, 0, 0, 0);
            this.dateFechaCompromiso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaCompromiso.Location = new System.Drawing.Point(11, 112);
            this.dateFechaCompromiso.Name = "dateFechaCompromiso";
            this.dateFechaCompromiso.Size = new System.Drawing.Size(234, 27);
            this.dateFechaCompromiso.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.dateFechaCompromiso.StateCommon.Border.Color2 = System.Drawing.Color.Gray;
            this.dateFechaCompromiso.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dateFechaCompromiso.StateCommon.Border.Rounding = 3;
            this.dateFechaCompromiso.StateCommon.Border.Width = 3;
            this.dateFechaCompromiso.TabIndex = 1;
            this.dateFechaCompromiso.ValueNullable = new System.DateTime(2021, 5, 8, 22, 13, 24, 0);
            // 
            // btnAutorizar
            // 
            this.btnAutorizar.Location = new System.Drawing.Point(132, 237);
            this.btnAutorizar.Name = "btnAutorizar";
            this.btnAutorizar.OverrideDefault.Back.Color1 = System.Drawing.Color.Black;
            this.btnAutorizar.OverrideDefault.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnAutorizar.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnAutorizar.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnAutorizar.Size = new System.Drawing.Size(130, 45);
            this.btnAutorizar.StateCommon.Back.Color1 = System.Drawing.Color.Black;
            this.btnAutorizar.StateCommon.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnAutorizar.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnAutorizar.StateCommon.Border.Width = 0;
            this.btnAutorizar.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnAutorizar.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnAutorizar.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnAutorizar.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnAutorizar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutorizar.StateNormal.Back.Color1 = System.Drawing.Color.Black;
            this.btnAutorizar.StateNormal.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnAutorizar.TabIndex = 2;
            this.btnAutorizar.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnAutorizar.Values.Image")));
            this.btnAutorizar.Values.Text = "Autorizar";
            this.btnAutorizar.Click += new System.EventHandler(this.btnAutorizar_Click);
            // 
            // khTotalCtaCte
            // 
            this.khTotalCtaCte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.khTotalCtaCte.AutoSize = false;
            this.khTotalCtaCte.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.khTotalCtaCte.Location = new System.Drawing.Point(75, 163);
            this.khTotalCtaCte.Name = "khTotalCtaCte";
            this.khTotalCtaCte.Size = new System.Drawing.Size(269, 42);
            this.khTotalCtaCte.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khTotalCtaCte.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khTotalCtaCte.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.khTotalCtaCte.StateCommon.Border.Rounding = 3;
            this.khTotalCtaCte.StateCommon.Border.Width = 2;
            this.khTotalCtaCte.StateCommon.Content.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khTotalCtaCte.StateCommon.Content.LongText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khTotalCtaCte.StateCommon.Content.LongText.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khTotalCtaCte.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khTotalCtaCte.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.khTotalCtaCte.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khTotalCtaCte.TabIndex = 15;
            this.khTotalCtaCte.Values.Description = "0.0";
            this.khTotalCtaCte.Values.Heading = "TOTAL";
            this.khTotalCtaCte.Values.Image = null;
            // 
            // txtRut
            // 
            this.txtRut.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny29,
            this.buttonSpecAny30});
            this.txtRut.Location = new System.Drawing.Point(11, 32);
            this.txtRut.Name = "txtRut";
            this.txtRut.Size = new System.Drawing.Size(381, 44);
            this.txtRut.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.txtRut.StateCommon.Border.Color2 = System.Drawing.Color.Gray;
            this.txtRut.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtRut.StateCommon.Border.Rounding = 1;
            this.txtRut.StateCommon.Border.Width = 3;
            this.txtRut.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRut.StateCommon.Content.Padding = new System.Windows.Forms.Padding(2, 6, -1, -1);
            this.txtRut.TabIndex = 0;
            this.txtRut.Text = "99.999.999-9";
            this.txtRut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRut_KeyPress);
            this.txtRut.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRut_KeyUp);
            // 
            // buttonSpecAny29
            // 
            this.buttonSpecAny29.Checked = ComponentFactory.Krypton.Toolkit.ButtonCheckState.Unchecked;
            this.buttonSpecAny29.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.buttonSpecAny29.Image = ((System.Drawing.Image)(resources.GetObject("buttonSpecAny29.Image")));
            this.buttonSpecAny29.UniqueName = "7AF85AC7B87D4C05B4ACC11C8B065BA5";
            // 
            // buttonSpecAny30
            // 
            this.buttonSpecAny30.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.buttonSpecAny30.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            this.buttonSpecAny30.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl;
            this.buttonSpecAny30.Text = "RUT";
            this.buttonSpecAny30.UniqueName = "A651DF55150540C05798B1CFF3E85A84";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.ImageMedium = ((System.Drawing.Image)(resources.GetObject("kryptonPage1.ImageMedium")));
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(472, 295);
            this.kryptonPage1.Text = "TARJETA (F4)";
            this.kryptonPage1.TextDescription = "";
            this.kryptonPage1.TextTitle = "TARJETA";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "9FD39CBE2EAE467B6FB4D6F323A52AF4";
            // 
            // kpEdit
            // 
            this.kpEdit.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpEdit.Flags = 65534;
            this.kpEdit.ImageMedium = ((System.Drawing.Image)(resources.GetObject("kpEdit.ImageMedium")));
            this.kpEdit.LastVisibleSet = true;
            this.kpEdit.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpEdit.Name = "kpEdit";
            this.kpEdit.Size = new System.Drawing.Size(426, 228);
            this.kpEdit.Text = "GESTIONAR";
            this.kpEdit.TextDescription = "";
            this.kpEdit.TextTitle = "GESTIONAR";
            this.kpEdit.ToolTipTitle = "Page ToolTip";
            this.kpEdit.UniqueName = "A9B401EA03814B95368F6F2D6A4A3B50";
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Black;
            // 
            // fCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 404);
            this.Controls.Add(this.kryptonNavigator1);
            this.Controls.Add(this.kryptonHeader1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "fCash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fCash";
            this.Load += new System.EventHandler(this.fCash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpEfectivo)).EndInit();
            this.kpEfectivo.ResumeLayout(false);
            this.kpEfectivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpCtaCte)).EndInit();
            this.kpCtaCte.ResumeLayout(false);
            this.kpCtaCte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnExit;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kpEfectivo;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kpCtaCte;
        private ComponentFactory.Krypton.Navigator.KryptonPage kpEdit;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader khVuelto;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader khTotal;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtEfectivo;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny14;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny15;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPagar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAutorizar;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader khTotalCtaCte;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtRut;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny29;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny30;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtRut1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny2;
        private System.Windows.Forms.Label lblFechaCompromiso;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dateFechaCompromiso;
    }
}