
namespace EMFicheToLogo
{
    partial class frmProdSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProdSummary));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.txtFicheDesc = new DevExpress.XtraEditors.TextEdit();
            this.lblFicheDesc = new DevExpress.XtraEditors.LabelControl();
            this.deFicheDate = new DevExpress.XtraEditors.DateEdit();
            this.lblFicheDate = new DevExpress.XtraEditors.LabelControl();
            this.btnTransfer = new DevExpress.XtraEditors.SimpleButton();
            this.btnList = new DevExpress.XtraEditors.SimpleButton();
            this.btnOpenExcel = new DevExpress.XtraEditors.SimpleButton();
            this.lblExcelFile = new DevExpress.XtraEditors.LabelControl();
            this.txtFile = new DevExpress.XtraEditors.TextEdit();
            this.pnlFill = new DevExpress.XtraEditors.PanelControl();
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInsuranceFirm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebitCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreditCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebitTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repN2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCreditTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ssm = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::EMFicheToLogo.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFicheDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFicheDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFicheDate.Properties)).BeginInit();
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
            this.pnlTop.Controls.Add(this.txtFicheDesc);
            this.pnlTop.Controls.Add(this.lblFicheDesc);
            this.pnlTop.Controls.Add(this.deFicheDate);
            this.pnlTop.Controls.Add(this.lblFicheDate);
            this.pnlTop.Controls.Add(this.btnTransfer);
            this.pnlTop.Controls.Add(this.btnList);
            this.pnlTop.Controls.Add(this.btnOpenExcel);
            this.pnlTop.Controls.Add(this.lblExcelFile);
            this.pnlTop.Controls.Add(this.txtFile);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1163, 108);
            this.pnlTop.TabIndex = 0;
            // 
            // txtFicheDesc
            // 
            this.txtFicheDesc.Location = new System.Drawing.Point(292, 21);
            this.txtFicheDesc.Name = "txtFicheDesc";
            this.txtFicheDesc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtFicheDesc.Properties.Appearance.Options.UseFont = true;
            this.txtFicheDesc.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtFicheDesc.Size = new System.Drawing.Size(253, 18);
            this.txtFicheDesc.TabIndex = 11;
            // 
            // lblFicheDesc
            // 
            this.lblFicheDesc.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFicheDesc.Appearance.Options.UseFont = true;
            this.lblFicheDesc.Location = new System.Drawing.Point(210, 21);
            this.lblFicheDesc.Name = "lblFicheDesc";
            this.lblFicheDesc.Size = new System.Drawing.Size(76, 13);
            this.lblFicheDesc.TabIndex = 10;
            this.lblFicheDesc.Text = "Fiş Açıklama :";
            // 
            // deFicheDate
            // 
            this.deFicheDate.EditValue = new System.DateTime(2022, 3, 23, 16, 5, 37, 0);
            this.deFicheDate.Location = new System.Drawing.Point(74, 21);
            this.deFicheDate.Name = "deFicheDate";
            this.deFicheDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.deFicheDate.Properties.Appearance.Options.UseFont = true;
            this.deFicheDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.deFicheDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFicheDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFicheDate.Size = new System.Drawing.Size(112, 18);
            this.deFicheDate.TabIndex = 9;
            // 
            // lblFicheDate
            // 
            this.lblFicheDate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFicheDate.Appearance.Options.UseFont = true;
            this.lblFicheDate.Location = new System.Drawing.Point(12, 21);
            this.lblFicheDate.Name = "lblFicheDate";
            this.lblFicheDate.Size = new System.Drawing.Size(56, 13);
            this.lblFicheDate.TabIndex = 8;
            this.lblFicheDate.Text = "Fiş Tarihi :";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnTransfer.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnTransfer.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnTransfer.Appearance.Options.UseBackColor = true;
            this.btnTransfer.Appearance.Options.UseFont = true;
            this.btnTransfer.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTransfer.ImageOptions.SvgImage")));
            this.btnTransfer.Location = new System.Drawing.Point(1051, 46);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(100, 37);
            this.btnTransfer.TabIndex = 7;
            this.btnTransfer.Text = "Aktar";
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnList
            // 
            this.btnList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnList.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnList.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnList.Appearance.Options.UseBackColor = true;
            this.btnList.Appearance.Options.UseFont = true;
            this.btnList.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnList.ImageOptions.SvgImage")));
            this.btnList.Location = new System.Drawing.Point(934, 46);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(100, 37);
            this.btnList.TabIndex = 6;
            this.btnList.Text = "Listele";
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnOpenExcel
            // 
            this.btnOpenExcel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenExcel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnOpenExcel.Appearance.Options.UseBackColor = true;
            this.btnOpenExcel.Appearance.Options.UseFont = true;
            this.btnOpenExcel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOpenExcel.ImageOptions.SvgImage")));
            this.btnOpenExcel.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnOpenExcel.Location = new System.Drawing.Point(551, 69);
            this.btnOpenExcel.Name = "btnOpenExcel";
            this.btnOpenExcel.Size = new System.Drawing.Size(28, 24);
            this.btnOpenExcel.TabIndex = 5;
            this.btnOpenExcel.Click += new System.EventHandler(this.btnOpenExcel_Click);
            // 
            // lblExcelFile
            // 
            this.lblExcelFile.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblExcelFile.Appearance.Options.UseFont = true;
            this.lblExcelFile.Location = new System.Drawing.Point(12, 56);
            this.lblExcelFile.Name = "lblExcelFile";
            this.lblExcelFile.Size = new System.Drawing.Size(76, 13);
            this.lblExcelFile.TabIndex = 4;
            this.lblExcelFile.Text = "Excel Dosyası";
            // 
            // txtFile
            // 
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(12, 75);
            this.txtFile.Name = "txtFile";
            this.txtFile.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtFile.Size = new System.Drawing.Size(533, 18);
            this.txtFile.TabIndex = 3;
            // 
            // pnlFill
            // 
            this.pnlFill.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlFill.Appearance.BackColor2 = System.Drawing.Color.White;
            this.pnlFill.Appearance.Options.UseBackColor = true;
            this.pnlFill.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlFill.Controls.Add(this.gc);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 108);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(1163, 662);
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
            this.gc.Size = new System.Drawing.Size(1163, 662);
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
            this.colInsuranceFirm,
            this.colBranch,
            this.colDebitCode,
            this.colCreditCode,
            this.colDebitTotal,
            this.colCreditTotal,
            this.colStatusDesc,
            this.colStatus});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colStatus;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.Salmon;
            formatConditionRuleValue1.Appearance.BackColor2 = System.Drawing.Color.SeaShell;
            formatConditionRuleValue1.Appearance.Options.HighPriority = true;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = ((short)(1));
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.colStatus;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.LightGreen;
            formatConditionRuleValue2.Appearance.BackColor2 = System.Drawing.Color.Azure;
            formatConditionRuleValue2.Appearance.Options.HighPriority = true;
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = ((short)(2));
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.gv.FormatRules.Add(gridFormatRule1);
            this.gv.FormatRules.Add(gridFormatRule2);
            this.gv.GridControl = this.gc;
            this.gv.Name = "gv";
            this.gv.OptionsDetail.ShowDetailTabs = false;
            this.gv.OptionsView.AllowCellMerge = true;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.OptionsView.ShowIndicator = false;
            // 
            // colInsuranceFirm
            // 
            this.colInsuranceFirm.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colInsuranceFirm.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.colInsuranceFirm.AppearanceHeader.Options.UseFont = true;
            this.colInsuranceFirm.AppearanceHeader.Options.UseForeColor = true;
            this.colInsuranceFirm.Caption = "Sigorta Şirketi";
            this.colInsuranceFirm.FieldName = "InsuranceFirm";
            this.colInsuranceFirm.Name = "colInsuranceFirm";
            this.colInsuranceFirm.OptionsColumn.AllowEdit = false;
            this.colInsuranceFirm.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colInsuranceFirm.Visible = true;
            this.colInsuranceFirm.VisibleIndex = 0;
            this.colInsuranceFirm.Width = 201;
            // 
            // colBranch
            // 
            this.colBranch.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colBranch.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.colBranch.AppearanceHeader.Options.UseFont = true;
            this.colBranch.AppearanceHeader.Options.UseForeColor = true;
            this.colBranch.Caption = "Şube";
            this.colBranch.FieldName = "Branch";
            this.colBranch.Name = "colBranch";
            this.colBranch.OptionsColumn.AllowEdit = false;
            this.colBranch.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colBranch.Visible = true;
            this.colBranch.VisibleIndex = 1;
            this.colBranch.Width = 145;
            // 
            // colDebitCode
            // 
            this.colDebitCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDebitCode.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.colDebitCode.AppearanceHeader.Options.UseFont = true;
            this.colDebitCode.AppearanceHeader.Options.UseForeColor = true;
            this.colDebitCode.Caption = "Borç Kod";
            this.colDebitCode.FieldName = "DebitCode";
            this.colDebitCode.Name = "colDebitCode";
            this.colDebitCode.OptionsColumn.AllowEdit = false;
            this.colDebitCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colDebitCode.Visible = true;
            this.colDebitCode.VisibleIndex = 2;
            this.colDebitCode.Width = 145;
            // 
            // colCreditCode
            // 
            this.colCreditCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCreditCode.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.colCreditCode.AppearanceHeader.Options.UseFont = true;
            this.colCreditCode.AppearanceHeader.Options.UseForeColor = true;
            this.colCreditCode.Caption = "Alacak Kod";
            this.colCreditCode.FieldName = "CreditCode";
            this.colCreditCode.Name = "colCreditCode";
            this.colCreditCode.OptionsColumn.AllowEdit = false;
            this.colCreditCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCreditCode.Visible = true;
            this.colCreditCode.VisibleIndex = 3;
            this.colCreditCode.Width = 145;
            // 
            // colDebitTotal
            // 
            this.colDebitTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDebitTotal.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.colDebitTotal.AppearanceHeader.Options.UseFont = true;
            this.colDebitTotal.AppearanceHeader.Options.UseForeColor = true;
            this.colDebitTotal.Caption = "Borç Toplam";
            this.colDebitTotal.ColumnEdit = this.repN2;
            this.colDebitTotal.FieldName = "DebitTotal";
            this.colDebitTotal.Name = "colDebitTotal";
            this.colDebitTotal.OptionsColumn.AllowEdit = false;
            this.colDebitTotal.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colDebitTotal.Visible = true;
            this.colDebitTotal.VisibleIndex = 4;
            this.colDebitTotal.Width = 145;
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
            // colCreditTotal
            // 
            this.colCreditTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCreditTotal.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.colCreditTotal.AppearanceHeader.Options.UseFont = true;
            this.colCreditTotal.AppearanceHeader.Options.UseForeColor = true;
            this.colCreditTotal.Caption = "Alacak Toplam";
            this.colCreditTotal.ColumnEdit = this.repN2;
            this.colCreditTotal.FieldName = "CreditTotal";
            this.colCreditTotal.Name = "colCreditTotal";
            this.colCreditTotal.OptionsColumn.AllowEdit = false;
            this.colCreditTotal.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCreditTotal.Visible = true;
            this.colCreditTotal.VisibleIndex = 5;
            this.colCreditTotal.Width = 152;
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
            this.colStatusDesc.VisibleIndex = 6;
            // 
            // ssm
            // 
            this.ssm.ClosingDelay = 500;
            // 
            // frmProdSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 770);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProdSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[ÜRETİM İCMAL]";
            this.Load += new System.EventHandler(this.frmProdSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFicheDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFicheDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFicheDate.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtFile;
        private DevExpress.XtraEditors.LabelControl lblExcelFile;
        private DevExpress.XtraEditors.SimpleButton btnOpenExcel;
        private DevExpress.XtraEditors.SimpleButton btnTransfer;
        private DevExpress.XtraEditors.SimpleButton btnList;
        private DevExpress.XtraSplashScreen.SplashScreenManager ssm;
        private DevExpress.XtraGrid.GridControl gc;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn colInsuranceFirm;
        private DevExpress.XtraGrid.Columns.GridColumn colBranch;
        private DevExpress.XtraGrid.Columns.GridColumn colDebitCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCreditCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDebitTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colCreditTotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repN2;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.DateEdit deFicheDate;
        private DevExpress.XtraEditors.LabelControl lblFicheDate;
        private DevExpress.XtraEditors.LabelControl lblFicheDesc;
        private DevExpress.XtraEditors.TextEdit txtFicheDesc;
    }
}