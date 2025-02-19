
namespace EDispatchToLogo
{
    partial class FrmInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInvoice));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue4 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.btnTransfer = new DevExpress.XtraEditors.SimpleButton();
            this.btnOpenExcel = new DevExpress.XtraEditors.SimpleButton();
            this.lblExcelFile = new DevExpress.XtraEditors.LabelControl();
            this.txtFile = new DevExpress.XtraEditors.TextEdit();
            this.pnlFill = new DevExpress.XtraEditors.PanelControl();
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repN2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ssm = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::EDispatchToLogo.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repN2)).BeginInit();
            this.SuspendLayout();
            // 
            // colStatus
            // 
            this.colStatus.Caption = "DurumS";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // pnlTop
            // 
            this.pnlTop.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlTop.Appearance.BackColor2 = System.Drawing.Color.White;
            this.pnlTop.Appearance.Options.UseBackColor = true;
            this.pnlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlTop.Controls.Add(this.btnTransfer);
            this.pnlTop.Controls.Add(this.btnOpenExcel);
            this.pnlTop.Controls.Add(this.lblExcelFile);
            this.pnlTop.Controls.Add(this.txtFile);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(713, 78);
            this.pnlTop.TabIndex = 0;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnTransfer.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnTransfer.Appearance.Options.UseBackColor = true;
            this.btnTransfer.Appearance.Options.UseFont = true;
            this.btnTransfer.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTransfer.ImageOptions.SvgImage")));
            this.btnTransfer.Location = new System.Drawing.Point(596, 28);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(100, 37);
            this.btnTransfer.TabIndex = 10;
            this.btnTransfer.Text = "Aktar";
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnOpenExcel
            // 
            this.btnOpenExcel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenExcel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnOpenExcel.Appearance.Options.UseBackColor = true;
            this.btnOpenExcel.Appearance.Options.UseFont = true;
            this.btnOpenExcel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOpenExcel.ImageOptions.SvgImage")));
            this.btnOpenExcel.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnOpenExcel.Location = new System.Drawing.Point(551, 41);
            this.btnOpenExcel.Name = "btnOpenExcel";
            this.btnOpenExcel.Size = new System.Drawing.Size(28, 24);
            this.btnOpenExcel.TabIndex = 9;
            this.btnOpenExcel.Click += new System.EventHandler(this.btnOpenExcel_Click);
            // 
            // lblExcelFile
            // 
            this.lblExcelFile.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblExcelFile.Appearance.Options.UseFont = true;
            this.lblExcelFile.Location = new System.Drawing.Point(12, 25);
            this.lblExcelFile.Name = "lblExcelFile";
            this.lblExcelFile.Size = new System.Drawing.Size(76, 13);
            this.lblExcelFile.TabIndex = 5;
            this.lblExcelFile.Text = "Excel Dosyası";
            // 
            // txtFile
            // 
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(12, 44);
            this.txtFile.Name = "txtFile";
            this.txtFile.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtFile.Size = new System.Drawing.Size(533, 18);
            this.txtFile.TabIndex = 4;
            // 
            // pnlFill
            // 
            this.pnlFill.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlFill.Appearance.BackColor2 = System.Drawing.Color.White;
            this.pnlFill.Appearance.Options.UseBackColor = true;
            this.pnlFill.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlFill.Controls.Add(this.gc);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 78);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(713, 372);
            this.pnlFill.TabIndex = 1;
            // 
            // gc
            // 
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.Location = new System.Drawing.Point(0, 0);
            this.gc.MainView = this.gv;
            this.gc.Name = "gc";
            this.gc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repN2});
            this.gc.Size = new System.Drawing.Size(713, 372);
            this.gc.TabIndex = 1;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.gv.Appearance.Row.BackColor2 = System.Drawing.Color.White;
            this.gv.Appearance.Row.Options.UseBackColor = true;
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colStatusDesc,
            this.colStatus});
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Column = this.colStatus;
            gridFormatRule3.Name = "Format0";
            formatConditionRuleValue3.Appearance.BackColor = System.Drawing.Color.Salmon;
            formatConditionRuleValue3.Appearance.BackColor2 = System.Drawing.Color.SeaShell;
            formatConditionRuleValue3.Appearance.Options.HighPriority = true;
            formatConditionRuleValue3.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue3.Value1 = ((short)(1));
            gridFormatRule3.Rule = formatConditionRuleValue3;
            gridFormatRule4.ApplyToRow = true;
            gridFormatRule4.Column = this.colStatus;
            gridFormatRule4.Name = "Format1";
            formatConditionRuleValue4.Appearance.BackColor = System.Drawing.Color.LightGreen;
            formatConditionRuleValue4.Appearance.BackColor2 = System.Drawing.Color.Azure;
            formatConditionRuleValue4.Appearance.Options.HighPriority = true;
            formatConditionRuleValue4.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue4.Value1 = ((short)(2));
            gridFormatRule4.Rule = formatConditionRuleValue4;
            this.gv.FormatRules.Add(gridFormatRule3);
            this.gv.FormatRules.Add(gridFormatRule4);
            this.gv.GridControl = this.gc;
            this.gv.Name = "gv";
            this.gv.OptionsDetail.ShowDetailTabs = false;
            this.gv.OptionsView.AllowCellMerge = true;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.OptionsView.ShowIndicator = false;
            // 
            // colCode
            // 
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCode.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.AppearanceHeader.Options.UseForeColor = true;
            this.colCode.Caption = "Kod / Fiş No";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 144;
            // 
            // colStatusDesc
            // 
            this.colStatusDesc.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatusDesc.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.colStatusDesc.AppearanceHeader.Options.UseFont = true;
            this.colStatusDesc.AppearanceHeader.Options.UseForeColor = true;
            this.colStatusDesc.Caption = "Durum";
            this.colStatusDesc.FieldName = "StatusDesc";
            this.colStatusDesc.Name = "colStatusDesc";
            this.colStatusDesc.OptionsColumn.AllowEdit = false;
            this.colStatusDesc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colStatusDesc.Visible = true;
            this.colStatusDesc.VisibleIndex = 1;
            this.colStatusDesc.Width = 79;
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
            // ssm
            // 
            this.ssm.ClosingDelay = 500;
            // 
            // FrmInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 450);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Fatura]";
            this.Load += new System.EventHandler(this.FrmInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repN2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.PanelControl pnlFill;
        private DevExpress.XtraEditors.LabelControl lblExcelFile;
        private DevExpress.XtraEditors.TextEdit txtFile;
        private DevExpress.XtraSplashScreen.SplashScreenManager ssm;
        private DevExpress.XtraGrid.GridControl gc;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repN2;
        private DevExpress.XtraEditors.SimpleButton btnTransfer;
        private DevExpress.XtraEditors.SimpleButton btnOpenExcel;
    }
}