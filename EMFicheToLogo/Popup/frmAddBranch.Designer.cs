
namespace EMFicheToLogo.Popup
{
    partial class frmAddBranch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddBranch));
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtDebitCode = new DevExpress.XtraEditors.TextEdit();
            this.lblDebitCode = new DevExpress.XtraEditors.LabelControl();
            this.txtBranch = new DevExpress.XtraEditors.TextEdit();
            this.lblBranch = new DevExpress.XtraEditors.LabelControl();
            this.txtCreditCode = new DevExpress.XtraEditors.TextEdit();
            this.lblCreditCode = new DevExpress.XtraEditors.LabelControl();
            this.erp = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancel.ImageOptions.SvgImage")));
            this.btnCancel.Location = new System.Drawing.Point(190, 89);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 37);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "İptal";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Location = new System.Drawing.Point(77, 89);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 37);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDebitCode
            // 
            this.txtDebitCode.Location = new System.Drawing.Point(77, 36);
            this.txtDebitCode.Name = "txtDebitCode";
            this.txtDebitCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDebitCode.Properties.Appearance.Options.UseFont = true;
            this.txtDebitCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtDebitCode.Size = new System.Drawing.Size(202, 18);
            this.txtDebitCode.TabIndex = 13;
            // 
            // lblDebitCode
            // 
            this.lblDebitCode.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDebitCode.Appearance.Options.UseFont = true;
            this.lblDebitCode.Location = new System.Drawing.Point(16, 38);
            this.lblDebitCode.Name = "lblDebitCode";
            this.lblDebitCode.Size = new System.Drawing.Size(55, 13);
            this.lblDebitCode.TabIndex = 13;
            this.lblDebitCode.Text = "Borç Kod :";
            // 
            // txtBranch
            // 
            this.txtBranch.Location = new System.Drawing.Point(77, 12);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtBranch.Properties.Appearance.Options.UseFont = true;
            this.txtBranch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtBranch.Size = new System.Drawing.Size(202, 18);
            this.txtBranch.TabIndex = 12;
            // 
            // lblBranch
            // 
            this.lblBranch.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBranch.Appearance.Options.UseFont = true;
            this.lblBranch.Location = new System.Drawing.Point(37, 14);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(34, 13);
            this.lblBranch.TabIndex = 11;
            this.lblBranch.Text = "Şube :";
            // 
            // txtCreditCode
            // 
            this.txtCreditCode.Location = new System.Drawing.Point(77, 60);
            this.txtCreditCode.Name = "txtCreditCode";
            this.txtCreditCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCreditCode.Properties.Appearance.Options.UseFont = true;
            this.txtCreditCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtCreditCode.Size = new System.Drawing.Size(202, 18);
            this.txtCreditCode.TabIndex = 14;
            // 
            // lblCreditCode
            // 
            this.lblCreditCode.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCreditCode.Appearance.Options.UseFont = true;
            this.lblCreditCode.Location = new System.Drawing.Point(3, 62);
            this.lblCreditCode.Name = "lblCreditCode";
            this.lblCreditCode.Size = new System.Drawing.Size(68, 13);
            this.lblCreditCode.TabIndex = 17;
            this.lblCreditCode.Text = "Alacak Kod :";
            // 
            // erp
            // 
            this.erp.ContainerControl = this;
            // 
            // frmAddBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 129);
            this.Controls.Add(this.txtCreditCode);
            this.Controls.Add(this.lblCreditCode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDebitCode);
            this.Controls.Add(this.lblDebitCode);
            this.Controls.Add(this.txtBranch);
            this.Controls.Add(this.lblBranch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddBranch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Şube Ekle - Düzenle]";
            this.Load += new System.EventHandler(this.frmAddBranch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAddBranch_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtDebitCode;
        private DevExpress.XtraEditors.LabelControl lblDebitCode;
        private DevExpress.XtraEditors.TextEdit txtBranch;
        private DevExpress.XtraEditors.LabelControl lblBranch;
        private DevExpress.XtraEditors.TextEdit txtCreditCode;
        private DevExpress.XtraEditors.LabelControl lblCreditCode;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider erp;
    }
}