
namespace SGI.Views
{
    partial class fConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fConfirm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblmsg = new System.Windows.Forms.Label();
            this.btnYes = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNo = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblmsg
            // 
            this.lblmsg.BackColor = System.Drawing.Color.Transparent;
            this.lblmsg.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg.ForeColor = System.Drawing.Color.White;
            this.lblmsg.Location = new System.Drawing.Point(22, 8);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(274, 142);
            this.lblmsg.TabIndex = 1;
            this.lblmsg.Text = "¿Confirmas eliminar el registro?";
            this.lblmsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(326, 12);
            this.btnYes.Name = "btnYes";
            this.btnYes.OverrideDefault.Back.Color1 = System.Drawing.Color.Black;
            this.btnYes.OverrideDefault.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnYes.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnYes.OverrideDefault.Border.Rounding = 0;
            this.btnYes.OverrideDefault.Border.Width = 0;
            this.btnYes.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.Yellow;
            this.btnYes.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.Yellow;
            this.btnYes.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Size = new System.Drawing.Size(75, 56);
            this.btnYes.StateCommon.Back.Color1 = System.Drawing.Color.Black;
            this.btnYes.StateCommon.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnYes.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnYes.StateCommon.Border.Rounding = 0;
            this.btnYes.StateCommon.Border.Width = 0;
            this.btnYes.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Yellow;
            this.btnYes.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Yellow;
            this.btnYes.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.StateTracking.Back.Color1 = System.Drawing.Color.DimGray;
            this.btnYes.StateTracking.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnYes.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnYes.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnYes.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.TabIndex = 2;
            this.btnYes.Values.Text = "SI";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(326, 92);
            this.btnNo.Name = "btnNo";
            this.btnNo.OverrideDefault.Back.Color1 = System.Drawing.Color.Black;
            this.btnNo.OverrideDefault.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnNo.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNo.OverrideDefault.Border.Rounding = 0;
            this.btnNo.OverrideDefault.Border.Width = 0;
            this.btnNo.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.Yellow;
            this.btnNo.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.Yellow;
            this.btnNo.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.Size = new System.Drawing.Size(75, 56);
            this.btnNo.StateCommon.Back.Color1 = System.Drawing.Color.Black;
            this.btnNo.StateCommon.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnNo.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNo.StateCommon.Border.Rounding = 0;
            this.btnNo.StateCommon.Border.Width = 0;
            this.btnNo.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Yellow;
            this.btnNo.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Yellow;
            this.btnNo.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.StateTracking.Back.Color1 = System.Drawing.Color.DimGray;
            this.btnNo.StateTracking.Back.Color2 = System.Drawing.Color.DimGray;
            this.btnNo.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnNo.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnNo.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.TabIndex = 3;
            this.btnNo.Values.Text = "NO";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // fConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(431, 160);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "fConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fConfirm";
            this.Load += new System.EventHandler(this.fConfirm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblmsg;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnYes;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNo;
    }
}