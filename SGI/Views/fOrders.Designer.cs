
namespace SGI.Views
{
    partial class fOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fOrders));
            this.kSplitMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.lblUsuario = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblBoletaNumero = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnCancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSuspender = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnGuardar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnRecuperar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.btnExit = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kSplitProductos = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.panelProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCards = new System.Windows.Forms.FlowLayoutPanel();
            this.khFamilias = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.bsCardsMode = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.bsRowsMode = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kgToolbar = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.btnHideToolBar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnRemoveProducto = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSubProducto = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAddProducto = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dtGrid = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.COLCODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLDESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLPRECIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLCANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLSUBTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.khTotal = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.lblItems = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSearch = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny3 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonDockingManager1 = new ComponentFactory.Krypton.Docking.KryptonDockingManager();
            ((System.ComponentModel.ISupportInitialize)(this.kSplitMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kSplitMain.Panel1)).BeginInit();
            this.kSplitMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kSplitMain.Panel2)).BeginInit();
            this.kSplitMain.Panel2.SuspendLayout();
            this.kSplitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kSplitProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kSplitProductos.Panel1)).BeginInit();
            this.kSplitProductos.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kSplitProductos.Panel2)).BeginInit();
            this.kSplitProductos.Panel2.SuspendLayout();
            this.kSplitProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgToolbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgToolbar.Panel)).BeginInit();
            this.kgToolbar.Panel.SuspendLayout();
            this.kgToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kSplitMain
            // 
            this.kSplitMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.kSplitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kSplitMain.Location = new System.Drawing.Point(0, 0);
            this.kSplitMain.Name = "kSplitMain";
            this.kSplitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // kSplitMain.Panel1
            // 
            this.kSplitMain.Panel1.Controls.Add(this.lblUsuario);
            this.kSplitMain.Panel1.Controls.Add(this.lblBoletaNumero);
            this.kSplitMain.Panel1.Controls.Add(this.btnCancelar);
            this.kSplitMain.Panel1.Controls.Add(this.btnSuspender);
            this.kSplitMain.Panel1.Controls.Add(this.btnGuardar);
            this.kSplitMain.Panel1.Controls.Add(this.btnRecuperar);
            this.kSplitMain.Panel1.Controls.Add(this.kryptonHeader1);
            this.kSplitMain.Panel1.StateNormal.Color1 = System.Drawing.Color.Silver;
            // 
            // kSplitMain.Panel2
            // 
            this.kSplitMain.Panel2.Controls.Add(this.kSplitProductos);
            this.kSplitMain.Panel2.Controls.Add(this.kryptonPanel1);
            this.kSplitMain.Panel2.StateNormal.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.kSplitMain.Size = new System.Drawing.Size(1158, 652);
            this.kSplitMain.SplitterDistance = 100;
            this.kSplitMain.SplitterWidth = 1;
            this.kSplitMain.TabIndex = 0;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUsuario.Location = new System.Drawing.Point(1116, 44);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(42, 56);
            this.lblUsuario.StateCommon.LongText.Color1 = System.Drawing.Color.White;
            this.lblUsuario.StateCommon.LongText.Color2 = System.Drawing.Color.White;
            this.lblUsuario.StateCommon.LongText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.lblUsuario.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.lblUsuario.StateCommon.ShortText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.TabIndex = 11;
            this.lblUsuario.Values.ExtraText = "-";
            this.lblUsuario.Values.Image = ((System.Drawing.Image)(resources.GetObject("lblUsuario.Values.Image")));
            this.lblUsuario.Values.Text = "";
            // 
            // lblBoletaNumero
            // 
            this.lblBoletaNumero.Location = new System.Drawing.Point(589, 74);
            this.lblBoletaNumero.Name = "lblBoletaNumero";
            this.lblBoletaNumero.Size = new System.Drawing.Size(90, 22);
            this.lblBoletaNumero.StateCommon.LongText.Color1 = System.Drawing.Color.White;
            this.lblBoletaNumero.StateCommon.LongText.Color2 = System.Drawing.Color.White;
            this.lblBoletaNumero.StateCommon.LongText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoletaNumero.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.lblBoletaNumero.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.lblBoletaNumero.StateCommon.ShortText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoletaNumero.TabIndex = 10;
            this.lblBoletaNumero.Values.ExtraText = "0";
            this.lblBoletaNumero.Values.Text = "Boleta #";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(420, 50);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OverrideDefault.Back.Color1 = System.Drawing.Color.Black;
            this.btnCancelar.OverrideDefault.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnCancelar.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnCancelar.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnCancelar.Size = new System.Drawing.Size(130, 45);
            this.btnCancelar.StateCommon.Back.Color1 = System.Drawing.Color.Black;
            this.btnCancelar.StateCommon.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnCancelar.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCancelar.StateCommon.Border.Width = 0;
            this.btnCancelar.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnCancelar.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnCancelar.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnCancelar.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnCancelar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.StateNormal.Back.Color1 = System.Drawing.Color.Black;
            this.btnCancelar.StateNormal.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Values.Image")));
            this.btnCancelar.Values.Text = "Cancelar\r\n(ESC)";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSuspender
            // 
            this.btnSuspender.Location = new System.Drawing.Point(284, 50);
            this.btnSuspender.Name = "btnSuspender";
            this.btnSuspender.OverrideDefault.Back.Color1 = System.Drawing.Color.Black;
            this.btnSuspender.OverrideDefault.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnSuspender.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSuspender.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSuspender.Size = new System.Drawing.Size(130, 45);
            this.btnSuspender.StateCommon.Back.Color1 = System.Drawing.Color.Black;
            this.btnSuspender.StateCommon.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnSuspender.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSuspender.StateCommon.Border.Width = 0;
            this.btnSuspender.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnSuspender.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnSuspender.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSuspender.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSuspender.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuspender.StateNormal.Back.Color1 = System.Drawing.Color.Black;
            this.btnSuspender.StateNormal.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnSuspender.TabIndex = 8;
            this.btnSuspender.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnSuspender.Values.Image")));
            this.btnSuspender.Values.Text = "Suspender\r\n(F4)";
            this.btnSuspender.Click += new System.EventHandler(this.btnSuspender_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(148, 50);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.OverrideDefault.Back.Color1 = System.Drawing.Color.Black;
            this.btnGuardar.OverrideDefault.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnGuardar.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnGuardar.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnGuardar.Size = new System.Drawing.Size(130, 45);
            this.btnGuardar.StateCommon.Back.Color1 = System.Drawing.Color.Black;
            this.btnGuardar.StateCommon.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnGuardar.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnGuardar.StateCommon.Border.Width = 0;
            this.btnGuardar.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnGuardar.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnGuardar.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnGuardar.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnGuardar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.StateNormal.Back.Color1 = System.Drawing.Color.Black;
            this.btnGuardar.StateNormal.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Values.Image")));
            this.btnGuardar.Values.Text = "Pagar\r\n(F3)";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnRecuperar
            // 
            this.btnRecuperar.Location = new System.Drawing.Point(12, 50);
            this.btnRecuperar.Name = "btnRecuperar";
            this.btnRecuperar.OverrideDefault.Back.Color1 = System.Drawing.Color.Black;
            this.btnRecuperar.OverrideDefault.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnRecuperar.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRecuperar.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnRecuperar.Size = new System.Drawing.Size(130, 45);
            this.btnRecuperar.StateCommon.Back.Color1 = System.Drawing.Color.Black;
            this.btnRecuperar.StateCommon.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnRecuperar.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnRecuperar.StateCommon.Border.Width = 0;
            this.btnRecuperar.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnRecuperar.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnRecuperar.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRecuperar.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnRecuperar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecuperar.StateNormal.Back.Color1 = System.Drawing.Color.Black;
            this.btnRecuperar.StateNormal.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnRecuperar.TabIndex = 6;
            this.btnRecuperar.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnRecuperar.Values.Image")));
            this.btnRecuperar.Values.Text = "Recuperar\r\n(F2)";
            this.btnRecuperar.Click += new System.EventHandler(this.btnRecuperar_Click);
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnExit});
            this.kryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeader1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(1158, 44);
            this.kryptonHeader1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonHeader1.StateCommon.Border.Width = 0;
            this.kryptonHeader1.TabIndex = 2;
            this.kryptonHeader1.Values.Description = "";
            this.kryptonHeader1.Values.Heading = "::: Pedidos";
            this.kryptonHeader1.Values.Image = null;
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnExit.UniqueName = "46D981A75C00467722A544B6DCF452D9";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // kSplitProductos
            // 
            this.kSplitProductos.Cursor = System.Windows.Forms.Cursors.Default;
            this.kSplitProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kSplitProductos.Location = new System.Drawing.Point(0, 0);
            this.kSplitProductos.Name = "kSplitProductos";
            // 
            // kSplitProductos.Panel1
            // 
            this.kSplitProductos.Panel1.Controls.Add(this.panelProductos);
            this.kSplitProductos.Panel1.Controls.Add(this.panelCards);
            this.kSplitProductos.Panel1.Controls.Add(this.khFamilias);
            // 
            // kSplitProductos.Panel2
            // 
            this.kSplitProductos.Panel2.Controls.Add(this.kgToolbar);
            this.kSplitProductos.Panel2.Controls.Add(this.dtGrid);
            this.kSplitProductos.Size = new System.Drawing.Size(1158, 465);
            this.kSplitProductos.SplitterDistance = 534;
            this.kSplitProductos.TabIndex = 1;
            // 
            // panelProductos
            // 
            this.panelProductos.AutoScroll = true;
            this.panelProductos.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelProductos.Location = new System.Drawing.Point(249, 44);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.Size = new System.Drawing.Size(285, 421);
            this.panelProductos.TabIndex = 2;
            // 
            // panelCards
            // 
            this.panelCards.AutoScroll = true;
            this.panelCards.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelCards.Location = new System.Drawing.Point(0, 44);
            this.panelCards.Name = "panelCards";
            this.panelCards.Size = new System.Drawing.Size(243, 421);
            this.panelCards.TabIndex = 1;
            // 
            // khFamilias
            // 
            this.khFamilias.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.bsCardsMode,
            this.bsRowsMode});
            this.khFamilias.Dock = System.Windows.Forms.DockStyle.Top;
            this.khFamilias.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.khFamilias.Location = new System.Drawing.Point(0, 0);
            this.khFamilias.Name = "khFamilias";
            this.khFamilias.Size = new System.Drawing.Size(534, 44);
            this.khFamilias.StateCommon.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.khFamilias.StateCommon.Border.Width = 0;
            this.khFamilias.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.khFamilias.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.khFamilias.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khFamilias.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.khFamilias.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.khFamilias.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.khFamilias.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.khFamilias.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khFamilias.TabIndex = 0;
            this.khFamilias.Values.Description = "";
            this.khFamilias.Values.Heading = "FAMILIAS DE PRODUCTOS";
            this.khFamilias.Values.Image = null;
            // 
            // bsCardsMode
            // 
            this.bsCardsMode.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.bsCardsMode.Image = ((System.Drawing.Image)(resources.GetObject("bsCardsMode.Image")));
            this.bsCardsMode.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.bsCardsMode.UniqueName = "83008134488E4D009C9D7EC24C641C85";
            this.bsCardsMode.Click += new System.EventHandler(this.bsCardsMode_Click);
            // 
            // bsRowsMode
            // 
            this.bsRowsMode.Image = ((System.Drawing.Image)(resources.GetObject("bsRowsMode.Image")));
            this.bsRowsMode.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.bsRowsMode.UniqueName = "64AA32656F5E4F714EA4859A187A86D5";
            this.bsRowsMode.Click += new System.EventHandler(this.bsRowsMode_Click);
            // 
            // kgToolbar
            // 
            this.kgToolbar.Dock = System.Windows.Forms.DockStyle.Right;
            this.kgToolbar.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.TabDockAutoHidden;
            this.kgToolbar.Location = new System.Drawing.Point(529, 0);
            this.kgToolbar.Name = "kgToolbar";
            // 
            // kgToolbar.Panel
            // 
            this.kgToolbar.Panel.Controls.Add(this.btnHideToolBar);
            this.kgToolbar.Panel.Controls.Add(this.btnRemoveProducto);
            this.kgToolbar.Panel.Controls.Add(this.btnSubProducto);
            this.kgToolbar.Panel.Controls.Add(this.btnAddProducto);
            this.kgToolbar.Size = new System.Drawing.Size(90, 465);
            this.kgToolbar.StateCommon.Back.Color1 = System.Drawing.Color.Gray;
            this.kgToolbar.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kgToolbar.TabIndex = 1;
            this.kgToolbar.Visible = false;
            // 
            // btnHideToolBar
            // 
            this.btnHideToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHideToolBar.Location = new System.Drawing.Point(0, 180);
            this.btnHideToolBar.Name = "btnHideToolBar";
            this.btnHideToolBar.OverrideDefault.Back.Color1 = System.Drawing.Color.Black;
            this.btnHideToolBar.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHideToolBar.Size = new System.Drawing.Size(88, 60);
            this.btnHideToolBar.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnHideToolBar.StateCommon.Border.Rounding = 0;
            this.btnHideToolBar.StateCommon.Border.Width = 0;
            this.btnHideToolBar.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnHideToolBar.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnHideToolBar.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnHideToolBar.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnHideToolBar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHideToolBar.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHideToolBar.StateNormal.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnHideToolBar.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnHideToolBar.StateNormal.Border.Rounding = 1;
            this.btnHideToolBar.StateNormal.Border.Width = 1;
            this.btnHideToolBar.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHideToolBar.StateTracking.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnHideToolBar.TabIndex = 5;
            this.btnHideToolBar.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnHideToolBar.Values.Image")));
            this.btnHideToolBar.Values.Text = "";
            this.btnHideToolBar.Click += new System.EventHandler(this.btnHideToolBar_Click);
            // 
            // btnRemoveProducto
            // 
            this.btnRemoveProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRemoveProducto.Location = new System.Drawing.Point(0, 120);
            this.btnRemoveProducto.Name = "btnRemoveProducto";
            this.btnRemoveProducto.OverrideDefault.Back.Color1 = System.Drawing.Color.Black;
            this.btnRemoveProducto.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRemoveProducto.Size = new System.Drawing.Size(88, 60);
            this.btnRemoveProducto.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnRemoveProducto.StateCommon.Border.Rounding = 0;
            this.btnRemoveProducto.StateCommon.Border.Width = 0;
            this.btnRemoveProducto.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnRemoveProducto.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnRemoveProducto.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRemoveProducto.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnRemoveProducto.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveProducto.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRemoveProducto.StateNormal.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnRemoveProducto.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnRemoveProducto.StateNormal.Border.Rounding = 1;
            this.btnRemoveProducto.StateNormal.Border.Width = 1;
            this.btnRemoveProducto.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRemoveProducto.StateTracking.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnRemoveProducto.TabIndex = 4;
            this.btnRemoveProducto.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveProducto.Values.Image")));
            this.btnRemoveProducto.Values.Text = "";
            this.btnRemoveProducto.Click += new System.EventHandler(this.btnRemoveProducto_Click);
            // 
            // btnSubProducto
            // 
            this.btnSubProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubProducto.Location = new System.Drawing.Point(0, 60);
            this.btnSubProducto.Name = "btnSubProducto";
            this.btnSubProducto.OverrideDefault.Back.Color1 = System.Drawing.Color.Black;
            this.btnSubProducto.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSubProducto.Size = new System.Drawing.Size(88, 60);
            this.btnSubProducto.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSubProducto.StateCommon.Border.Rounding = 0;
            this.btnSubProducto.StateCommon.Border.Width = 0;
            this.btnSubProducto.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnSubProducto.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnSubProducto.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSubProducto.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSubProducto.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubProducto.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSubProducto.StateNormal.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnSubProducto.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSubProducto.StateNormal.Border.Rounding = 1;
            this.btnSubProducto.StateNormal.Border.Width = 1;
            this.btnSubProducto.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSubProducto.StateTracking.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnSubProducto.TabIndex = 3;
            this.btnSubProducto.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnSubProducto.Values.Image")));
            this.btnSubProducto.Values.Text = "";
            this.btnSubProducto.Click += new System.EventHandler(this.btnSubProducto_Click);
            // 
            // btnAddProducto
            // 
            this.btnAddProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddProducto.Location = new System.Drawing.Point(0, 0);
            this.btnAddProducto.Name = "btnAddProducto";
            this.btnAddProducto.OverrideDefault.Back.Color1 = System.Drawing.Color.Black;
            this.btnAddProducto.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddProducto.Size = new System.Drawing.Size(88, 60);
            this.btnAddProducto.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnAddProducto.StateCommon.Border.Rounding = 0;
            this.btnAddProducto.StateCommon.Border.Width = 0;
            this.btnAddProducto.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnAddProducto.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnAddProducto.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnAddProducto.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnAddProducto.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProducto.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddProducto.StateNormal.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnAddProducto.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnAddProducto.StateNormal.Border.Rounding = 1;
            this.btnAddProducto.StateNormal.Border.Width = 1;
            this.btnAddProducto.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddProducto.StateTracking.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnAddProducto.TabIndex = 2;
            this.btnAddProducto.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnAddProducto.Values.Image")));
            this.btnAddProducto.Values.Text = "";
            this.btnAddProducto.Click += new System.EventHandler(this.btnAddProducto_Click);
            // 
            // dtGrid
            // 
            this.dtGrid.AllowUserToAddRows = false;
            this.dtGrid.AllowUserToDeleteRows = false;
            this.dtGrid.AllowUserToOrderColumns = true;
            this.dtGrid.AllowUserToResizeColumns = false;
            this.dtGrid.AllowUserToResizeRows = false;
            this.dtGrid.ColumnHeadersHeight = 41;
            this.dtGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COLCODIGO,
            this.COLDESCRIPCION,
            this.COLPRECIO,
            this.COLCANTIDAD,
            this.COLSUBTOTAL});
            this.dtGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGrid.Location = new System.Drawing.Point(0, 0);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.ReadOnly = true;
            this.dtGrid.RowHeadersVisible = false;
            this.dtGrid.RowHeadersWidth = 50;
            this.dtGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrid.Size = new System.Drawing.Size(619, 465);
            this.dtGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dtGrid.StateCommon.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dtGrid.StateCommon.DataCell.Border.Rounding = 1;
            this.dtGrid.StateCommon.DataCell.Border.Width = 1;
            this.dtGrid.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtGrid.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dtGrid.StateCommon.HeaderColumn.Border.Rounding = 0;
            this.dtGrid.StateCommon.HeaderColumn.Border.Width = 0;
            this.dtGrid.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtGrid.StateCommon.HeaderRow.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dtGrid.StateCommon.HeaderRow.Border.Rounding = 1;
            this.dtGrid.StateCommon.HeaderRow.Border.Width = 1;
            this.dtGrid.StateNormal.HeaderRow.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dtGrid.StateNormal.HeaderRow.Border.Rounding = 2;
            this.dtGrid.StateNormal.HeaderRow.Border.Width = 2;
            this.dtGrid.TabIndex = 0;
            this.dtGrid.DoubleClick += new System.EventHandler(this.dtGrid_DoubleClick);
            // 
            // COLCODIGO
            // 
            this.COLCODIGO.HeaderText = "CODIGO";
            this.COLCODIGO.Name = "COLCODIGO";
            this.COLCODIGO.ReadOnly = true;
            this.COLCODIGO.Visible = false;
            // 
            // COLDESCRIPCION
            // 
            this.COLDESCRIPCION.HeaderText = "DESCRIPCION";
            this.COLDESCRIPCION.Name = "COLDESCRIPCION";
            this.COLDESCRIPCION.ReadOnly = true;
            this.COLDESCRIPCION.Width = 120;
            // 
            // COLPRECIO
            // 
            this.COLPRECIO.HeaderText = "PRECIO";
            this.COLPRECIO.Name = "COLPRECIO";
            this.COLPRECIO.ReadOnly = true;
            // 
            // COLCANTIDAD
            // 
            this.COLCANTIDAD.HeaderText = "CANTIDAD";
            this.COLCANTIDAD.Name = "COLCANTIDAD";
            this.COLCANTIDAD.ReadOnly = true;
            // 
            // COLSUBTOTAL
            // 
            this.COLSUBTOTAL.HeaderText = "SUBTOTAL";
            this.COLSUBTOTAL.Name = "COLSUBTOTAL";
            this.COLSUBTOTAL.ReadOnly = true;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.khTotal);
            this.kryptonPanel1.Controls.Add(this.lblItems);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.txtSearch);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 465);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1158, 86);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Gray;
            this.kryptonPanel1.StateCommon.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Linear;
            this.kryptonPanel1.TabIndex = 0;
            // 
            // khTotal
            // 
            this.khTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.khTotal.AutoSize = false;
            this.khTotal.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.khTotal.Location = new System.Drawing.Point(877, 30);
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
            this.khTotal.TabIndex = 13;
            this.khTotal.Values.Description = "0.0";
            this.khTotal.Values.Heading = "TOTAL";
            this.khTotal.Values.Image = null;
            // 
            // lblItems
            // 
            this.lblItems.Location = new System.Drawing.Point(877, 6);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(106, 22);
            this.lblItems.StateCommon.LongText.Color1 = System.Drawing.Color.White;
            this.lblItems.StateCommon.LongText.Color2 = System.Drawing.Color.White;
            this.lblItems.StateCommon.LongText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItems.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.lblItems.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.lblItems.StateCommon.ShortText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItems.TabIndex = 12;
            this.lblItems.Values.ExtraText = "0";
            this.lblItems.Values.Text = "Productos:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(310, 22);
            this.kryptonLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.White;
            this.kryptonLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.White;
            this.kryptonLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 11;
            this.kryptonLabel1.Values.Text = "Escanea el codigo de barra (Focus Esc)";
            // 
            // txtSearch
            // 
            this.txtSearch.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny3});
            this.txtSearch.Location = new System.Drawing.Point(12, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(385, 44);
            this.txtSearch.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.txtSearch.StateCommon.Border.Color2 = System.Drawing.Color.Gray;
            this.txtSearch.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtSearch.StateCommon.Border.Rounding = 1;
            this.txtSearch.StateCommon.Border.Width = 3;
            this.txtSearch.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.StateCommon.Content.Padding = new System.Windows.Forms.Padding(2, 6, -1, -1);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // buttonSpecAny3
            // 
            this.buttonSpecAny3.Checked = ComponentFactory.Krypton.Toolkit.ButtonCheckState.Unchecked;
            this.buttonSpecAny3.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.buttonSpecAny3.Image = ((System.Drawing.Image)(resources.GetObject("buttonSpecAny3.Image")));
            this.buttonSpecAny3.UniqueName = "7AF85AC7B87D4C05B4ACC11C8B065BA5";
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Black;
            // 
            // fOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 652);
            this.Controls.Add(this.kSplitMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "fOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fOrders";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fOrders_FormClosed);
            this.Load += new System.EventHandler(this.fOrders_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fOrders_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fOrders_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fOrders_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fOrders_MouseUp);
            this.Resize += new System.EventHandler(this.fOrders_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.kSplitMain.Panel1)).EndInit();
            this.kSplitMain.Panel1.ResumeLayout(false);
            this.kSplitMain.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kSplitMain.Panel2)).EndInit();
            this.kSplitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kSplitMain)).EndInit();
            this.kSplitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kSplitProductos.Panel1)).EndInit();
            this.kSplitProductos.Panel1.ResumeLayout(false);
            this.kSplitProductos.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kSplitProductos.Panel2)).EndInit();
            this.kSplitProductos.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kSplitProductos)).EndInit();
            this.kSplitProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgToolbar.Panel)).EndInit();
            this.kgToolbar.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgToolbar)).EndInit();
            this.kgToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kSplitMain;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnExit;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUsuario;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBoletaNumero;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSuspender;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGuardar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRecuperar;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearch;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny3;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader khTotal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblItems;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kSplitProductos;
        private System.Windows.Forms.FlowLayoutPanel panelProductos;
        private System.Windows.Forms.FlowLayoutPanel panelCards;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader khFamilias;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny bsCardsMode;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny bsRowsMode;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dtGrid;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup kgToolbar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnHideToolBar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRemoveProducto;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSubProducto;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLCODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLDESCRIPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLPRECIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLCANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLSUBTOTAL;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private ComponentFactory.Krypton.Docking.KryptonDockingManager kryptonDockingManager1;
    }
}