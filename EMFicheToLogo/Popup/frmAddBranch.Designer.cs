
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
            this.txtHealthCreditCode = new DevExpress.XtraEditors.TextEdit();
            this.lblHealthCreditCode = new DevExpress.XtraEditors.LabelControl();
            this.txtHealthDebitCode = new DevExpress.XtraEditors.TextEdit();
            this.lblHealthDebitCode = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHealthCreditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHealthDebitCode.Properties)).BeginInit();
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
            this.btnCancel.Location = new System.Drawing.Point(263, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 37);
            this.btnCancel.TabIndex = 18;
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
            this.btnSave.Location = new System.Drawing.Point(150, 137);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 37);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDebitCode
            // 
            this.txtDebitCode.Location = new System.Drawing.Point(150, 36);
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
            this.lblDebitCode.Location = new System.Drawing.Point(25, 38);
            this.lblDebitCode.Name = "lblDebitCode";
            this.lblDebitCode.Size = new System.Drawing.Size(116, 13);
            this.lblDebitCode.TabIndex = 13;
            this.lblDebitCode.Text = "Elementer Borç Kod :";
            // 
            // txtBranch
            // 
            this.txtBranch.Location = new System.Drawing.Point(150, 12);
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
            this.lblBranch.Location = new System.Drawing.Point(110, 14);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(34, 13);
            this.lblBranch.TabIndex = 11;
            this.lblBranch.Text = "Şube :";
            // 
            // txtCreditCode
            // 
            this.txtCreditCode.Location = new System.Drawing.Point(150, 60);
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
            this.lblCreditCode.Location = new System.Drawing.Point(12, 62);
            this.lblCreditCode.Name = "lblCreditCode";
            this.lblCreditCode.Size = new System.Drawing.Size(129, 13);
            this.lblCreditCode.TabIndex = 17;
            this.lblCreditCode.Text = "Elementer Alacak Kod :";
            // 
            // erp
            // 
            this.erp.ContainerControl = this;
            // 
            // txtHealthCreditCode
            // 
            this.txtHealthCreditCode.Location = new System.Drawing.Point(150, 108);
            this.txtHealthCreditCode.Name = "txtHealthCreditCode";
            this.txtHealthCreditCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtHealthCreditCode.Properties.Appearance.Options.UseFont = true;
            this.txtHealthCreditCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtHealthCreditCode.Size = new System.Drawing.Size(202, 18);
            this.txtHealthCreditCode.TabIndex = 16;
            // 
            // lblHealthCreditCode
            // 
            this.lblHealthCreditCode.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblHealthCreditCode.Appearance.Options.UseFont = true;
            this.lblHealthCreditCode.Location = new System.Drawing.Point(39, 110);
            this.lblHealthCreditCode.Name = "lblHealthCreditCode";
            this.lblHealthCreditCode.Size = new System.Drawing.Size(105, 13);
            this.lblHealthCreditCode.TabIndex = 21;
            this.lblHealthCreditCode.Text = "Sağlık Alacak Kod :";
            // 
            // txtHealthDebitCode
            // 
            this.txtHealthDebitCode.Location = new System.Drawing.Point(150, 84);
            this.txtHealthDebitCode.Name = "txtHealthDebitCode";
            this.txtHealthDebitCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtHealthDebitCode.Properties.Appearance.Options.UseFont = true;
            this.txtHealthDebitCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtHealthDebitCode.Size = new System.Drawing.Size(202, 18);
            this.txtHealthDebitCode.TabIndex = 15;
            // 
            // lblHealthDebitCode
            // 
            this.lblHealthDebitCode.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblHealthDebitCode.Appearance.Options.UseFont = true;
            this.lblHealthDebitCode.Location = new System.Drawing.Point(52, 86);
            this.lblHealthDebitCode.Name = "lblHealthDebitCode";
            this.lblHealthDebitCode.Size = new System.Drawing.Size(92, 13);
            this.lblHealthDebitCode.TabIndex = 19;
            this.lblHealthDebitCode.Text = "Sağlık Borç Kod :";
            // 
            // frmAddBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 181);
            this.Controls.Add(this.txtHealthCreditCode);
            this.Controls.Add(this.lblHealthCreditCode);
            this.Controls.Add(this.txtHealthDebitCode);
            this.Controls.Add(this.lblHealthDebitCode);
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
            ((System.ComponentModel.ISupportInitialize)(this.txtHealthCreditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHealthDebitCode.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtHealthCreditCode;
        private DevExpress.XtraEditors.LabelControl lblHealthCreditCode;
        private DevExpress.XtraEditors.TextEdit txtHealthDebitCode;
        private DevExpress.XtraEditors.LabelControl lblHealthDebitCode;
    }
}