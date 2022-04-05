
namespace EMFicheToLogo
{
    partial class frmBranch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBranch));
            this.pnlFill = new DevExpress.XtraEditors.PanelControl();
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebitCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreditCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHealthDebitCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHealthCreditCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repN2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repN2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFill
            // 
            this.pnlFill.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlFill.Appearance.BackColor2 = System.Drawing.Color.White;
            this.pnlFill.Appearance.Options.UseBackColor = true;
            this.pnlFill.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlFill.Controls.Add(this.gc);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 79);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(751, 371);
            this.pnlFill.TabIndex = 5;
            // 
            // gc
            // 
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.Location = new System.Drawing.Point(0, 0);
            this.gc.MainView = this.gv;
            this.gc.Name = "gc";
            this.gc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repN2});
            this.gc.Size = new System.Drawing.Size(751, 371);
            this.gc.TabIndex = 0;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.gv.Appearance.Row.BackColor2 = System.Drawing.Color.White;
            this.gv.Appearance.Row.Options.UseBackColor = true;
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colBranch,
            this.colDebitCode,
            this.colCreditCode,
            this.colHealthDebitCode,
            this.colHealthCreditCode});
            this.gv.GridControl = this.gc;
            this.gv.Name = "gv";
            this.gv.OptionsDetail.ShowDetailTabs = false;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.OptionsView.ShowIndicator = false;
            // 
            // colID
            // 
            this.colID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colID.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.colID.AppearanceHeader.Options.UseFont = true;
            this.colID.AppearanceHeader.Options.UseForeColor = true;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            // 
            // colBranch
            // 
            this.colBranch.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colBranch.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.colBranch.AppearanceHeader.Options.UseFont = true;
            this.colBranch.AppearanceHeader.Options.UseForeColor = true;
            this.colBranch.Caption = "Şube";
            this.colBranch.FieldName = "BRANCH";
            this.colBranch.Name = "colBranch";
            this.colBranch.OptionsColumn.AllowEdit = false;
            this.colBranch.Visible = true;
            this.colBranch.VisibleIndex = 0;
            this.colBranch.Width = 135;
            // 
            // colDebitCode
            // 
            this.colDebitCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDebitCode.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.colDebitCode.AppearanceHeader.Options.UseFont = true;
            this.colDebitCode.AppearanceHeader.Options.UseForeColor = true;
            this.colDebitCode.Caption = "Elementer Borç Kod";
            this.colDebitCode.FieldName = "DEBITCODE";
            this.colDebitCode.Name = "colDebitCode";
            this.colDebitCode.OptionsColumn.AllowEdit = false;
            this.colDebitCode.Visible = true;
            this.colDebitCode.VisibleIndex = 1;
            this.colDebitCode.Width = 140;
            // 
            // colCreditCode
            // 
            this.colCreditCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCreditCode.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.colCreditCode.AppearanceHeader.Options.UseFont = true;
            this.colCreditCode.AppearanceHeader.Options.UseForeColor = true;
            this.colCreditCode.Caption = "Elementer Alacak Kod";
            this.colCreditCode.FieldName = "CREDITCODE";
            this.colCreditCode.Name = "colCreditCode";
            this.colCreditCode.OptionsColumn.AllowEdit = false;
            this.colCreditCode.Visible = true;
            this.colCreditCode.VisibleIndex = 2;
            this.colCreditCode.Width = 140;
            // 
            // colHealthDebitCode
            // 
            this.colHealthDebitCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHealthDebitCode.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.colHealthDebitCode.AppearanceHeader.Options.UseFont = true;
            this.colHealthDebitCode.AppearanceHeader.Options.UseForeColor = true;
            this.colHealthDebitCode.Caption = "Sağlık Borç Kod";
            this.colHealthDebitCode.FieldName = "HEALTHDEBITCODE";
            this.colHealthDebitCode.Name = "colHealthDebitCode";
            this.colHealthDebitCode.OptionsColumn.AllowEdit = false;
            this.colHealthDebitCode.Visible = true;
            this.colHealthDebitCode.VisibleIndex = 3;
            this.colHealthDebitCode.Width = 140;
            // 
            // colHealthCreditCode
            // 
            this.colHealthCreditCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHealthCreditCode.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.colHealthCreditCode.AppearanceHeader.Options.UseFont = true;
            this.colHealthCreditCode.AppearanceHeader.Options.UseForeColor = true;
            this.colHealthCreditCode.Caption = "Sağlık Alacak Kod";
            this.colHealthCreditCode.FieldName = "HEALTHCREDITCODE";
            this.colHealthCreditCode.Name = "colHealthCreditCode";
            this.colHealthCreditCode.OptionsColumn.AllowEdit = false;
            this.colHealthCreditCode.Visible = true;
            this.colHealthCreditCode.VisibleIndex = 4;
            this.colHealthCreditCode.Width = 140;
            // 
            // repN2
            // 
            this.repN2.AutoHeight = false;
            this.repN2.BeepOnError = false;
            this.repN2.DisplayFormat.FormatString = "n2";
            this.repN2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repN2.EditFormat.FormatString = "n2";
            this.repN2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repN2.Name = "repN2";
            this.repN2.UseMaskAsDisplayFormat = true;
            // 
            // pnlTop
            // 
            this.pnlTop.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlTop.Appearance.BackColor2 = System.Drawing.Color.White;
            this.pnlTop.Appearance.Options.UseBackColor = true;
            this.pnlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlTop.Controls.Add(this.btnDelete);
            this.pnlTop.Controls.Add(this.btnEdit);
            this.pnlTop.Controls.Add(this.btnAdd);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(751, 79);
            this.pnlTop.TabIndex = 4;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDelete.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Appearance.Options.UseBackColor = true;
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.Location = new System.Drawing.Point(204, 24);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 36);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Sil";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEdit.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Appearance.Options.UseBackColor = true;
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEdit.ImageOptions.SvgImage")));
            this.btnEdit.Location = new System.Drawing.Point(108, 24);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 36);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Düzenle";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAdd.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Appearance.Options.UseBackColor = true;
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAdd.ImageOptions.SvgImage")));
            this.btnAdd.Location = new System.Drawing.Point(12, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 36);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 450);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBranch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Şubeler]";
            this.Load += new System.EventHandler(this.frmBranch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBranch_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repN2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlFill;
        private DevExpress.XtraGrid.GridControl gc;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colBranch;
        private DevExpress.XtraGrid.Columns.GridColumn colDebitCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repN2;
        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colCreditCode;
        private DevExpress.XtraGrid.Columns.GridColumn colHealthDebitCode;
        private DevExpress.XtraGrid.Columns.GridColumn colHealthCreditCode;
    }
}