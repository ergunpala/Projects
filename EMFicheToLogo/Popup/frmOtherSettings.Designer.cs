
namespace EMFicheToLogo.Popup
{
    partial class frmOtherSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOtherSettings));
            this.grpParam = new System.Windows.Forms.GroupBox();
            this.txtranchClCode = new DevExpress.XtraEditors.TextEdit();
            this.lblBranchClCode = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.erp = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.grpParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtranchClCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).BeginInit();
            this.SuspendLayout();
            // 
            // grpParam
            // 
            this.grpParam.Controls.Add(this.txtranchClCode);
            this.grpParam.Controls.Add(this.lblBranchClCode);
            this.grpParam.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpParam.Location = new System.Drawing.Point(0, 0);
            this.grpParam.Name = "grpParam";
            this.grpParam.Size = new System.Drawing.Size(251, 216);
            this.grpParam.TabIndex = 0;
            this.grpParam.TabStop = false;
            this.grpParam.Text = "Parametreler";
            // 
            // txtranchClCode
            // 
            this.txtranchClCode.Location = new System.Drawing.Point(16, 48);
            this.txtranchClCode.Name = "txtranchClCode";
            this.txtranchClCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtranchClCode.Properties.Appearance.Options.UseFont = true;
            this.txtranchClCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtranchClCode.Size = new System.Drawing.Size(202, 18);
            this.txtranchClCode.TabIndex = 8;
            // 
            // lblBranchClCode
            // 
            this.lblBranchClCode.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBranchClCode.Appearance.Options.UseFont = true;
            this.lblBranchClCode.Location = new System.Drawing.Point(16, 29);
            this.lblBranchClCode.Name = "lblBranchClCode";
            this.lblBranchClCode.Size = new System.Drawing.Size(95, 13);
            this.lblBranchClCode.TabIndex = 7;
            this.lblBranchClCode.Text = "Şubeler Cari Hes.";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancel.ImageOptions.SvgImage")));
            this.btnCancel.Location = new System.Drawing.Point(139, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 37);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "İptal";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Location = new System.Drawing.Point(26, 226);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 37);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // erp
            // 
            this.erp.ContainerControl = this;
            // 
            // frmOtherSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 275);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpParam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOtherSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Diğer Parametreler]";
            this.Load += new System.EventHandler(this.frmOtherSettings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOtherSettings_KeyDown);
            this.grpParam.ResumeLayout(false);
            this.grpParam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtranchClCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpParam;
        private DevExpress.XtraEditors.TextEdit txtranchClCode;
        private DevExpress.XtraEditors.LabelControl lblBranchClCode;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider erp;
    }
}