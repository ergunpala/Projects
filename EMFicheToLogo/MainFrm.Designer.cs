
namespace EMFicheToLogo
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.gleFirm = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnProdSummary = new DevExpress.XtraEditors.SimpleButton();
            this.btnPosSummary = new DevExpress.XtraEditors.SimpleButton();
            this.btnPosReturnSummary = new DevExpress.XtraEditors.SimpleButton();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFirm = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOther = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gleFirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gleFirm
            // 
            this.gleFirm.Location = new System.Drawing.Point(134, 51);
            this.gleFirm.Name = "gleFirm";
            this.gleFirm.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gleFirm.Properties.Appearance.Options.UseFont = true;
            this.gleFirm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.gleFirm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleFirm.Properties.DisplayMember = "NAME";
            this.gleFirm.Properties.NullText = "Firma Seçiniz...";
            this.gleFirm.Properties.PopupView = this.gridLookUpEdit1View;
            this.gleFirm.Properties.ValueMember = "NR";
            this.gleFirm.Size = new System.Drawing.Size(349, 22);
            this.gleFirm.TabIndex = 0;
            this.gleFirm.ToolTip = "Firma Seçiniz...";
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNR,
            this.colDESC});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colNR
            // 
            this.colNR.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNR.AppearanceHeader.Options.UseFont = true;
            this.colNR.Caption = "NR";
            this.colNR.FieldName = "NR";
            this.colNR.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colNR.Name = "colNR";
            this.colNR.OptionsColumn.AllowEdit = false;
            this.colNR.Visible = true;
            this.colNR.VisibleIndex = 0;
            // 
            // colDESC
            // 
            this.colDESC.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDESC.AppearanceHeader.Options.UseFont = true;
            this.colDESC.Caption = "Firma";
            this.colDESC.FieldName = "NAME";
            this.colDESC.Name = "colDESC";
            this.colDESC.OptionsColumn.AllowEdit = false;
            this.colDESC.Visible = true;
            this.colDESC.VisibleIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(90, 54);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Firma :";
            // 
            // btnProdSummary
            // 
            this.btnProdSummary.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnProdSummary.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnProdSummary.Appearance.Options.UseBackColor = true;
            this.btnProdSummary.Appearance.Options.UseFont = true;
            this.btnProdSummary.Location = new System.Drawing.Point(18, 114);
            this.btnProdSummary.Name = "btnProdSummary";
            this.btnProdSummary.Size = new System.Drawing.Size(168, 51);
            this.btnProdSummary.TabIndex = 2;
            this.btnProdSummary.Text = "ÜRETİM İCMAL";
            this.btnProdSummary.Click += new System.EventHandler(this.btnProdSummary_Click);
            // 
            // btnPosSummary
            // 
            this.btnPosSummary.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnPosSummary.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPosSummary.Appearance.Options.UseBackColor = true;
            this.btnPosSummary.Appearance.Options.UseFont = true;
            this.btnPosSummary.Location = new System.Drawing.Point(192, 114);
            this.btnPosSummary.Name = "btnPosSummary";
            this.btnPosSummary.Size = new System.Drawing.Size(168, 51);
            this.btnPosSummary.TabIndex = 3;
            this.btnPosSummary.Text = "POS İCMAL";
            this.btnPosSummary.Click += new System.EventHandler(this.btnPosSummary_Click);
            // 
            // btnPosReturnSummary
            // 
            this.btnPosReturnSummary.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnPosReturnSummary.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPosReturnSummary.Appearance.Options.UseBackColor = true;
            this.btnPosReturnSummary.Appearance.Options.UseFont = true;
            this.btnPosReturnSummary.Location = new System.Drawing.Point(366, 114);
            this.btnPosReturnSummary.Name = "btnPosReturnSummary";
            this.btnPosReturnSummary.Size = new System.Drawing.Size(168, 51);
            this.btnPosReturnSummary.TabIndex = 4;
            this.btnPosReturnSummary.Text = "POS İADE İCMAL";
            this.btnPosReturnSummary.Click += new System.EventHandler(this.btnPosReturnSummary_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ayarlarToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(554, 24);
            this.menu.TabIndex = 8;
            this.menu.Text = "menuStrip1";
            // 
            // ayarlarToolStripMenuItem
            // 
            this.ayarlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFirm,
            this.btnBranch,
            this.btnOther,
            this.toolStripSeparator1,
            this.btnExit});
            this.ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            this.ayarlarToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.ayarlarToolStripMenuItem.Text = "Ayarlar";
            // 
            // btnFirm
            // 
            this.btnFirm.Name = "btnFirm";
            this.btnFirm.Size = new System.Drawing.Size(117, 22);
            this.btnFirm.Text = "Firmalar";
            this.btnFirm.Click += new System.EventHandler(this.btnFirm_Click);
            // 
            // btnBranch
            // 
            this.btnBranch.Name = "btnBranch";
            this.btnBranch.Size = new System.Drawing.Size(117, 22);
            this.btnBranch.Text = "Şubeler";
            this.btnBranch.Click += new System.EventHandler(this.btnBranch_Click);
            // 
            // btnOther
            // 
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(117, 22);
            this.btnOther.Text = "Diğer";
            this.btnOther.Click += new System.EventHandler(this.btnOther_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 22);
            this.btnExit.Text = "Çıkış";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(554, 210);
            this.Controls.Add(this.btnPosReturnSummary);
            this.Controls.Add(this.btnPosSummary);
            this.Controls.Add(this.btnProdSummary);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gleFirm);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Mahsup Fişi Aktarımı] v1.0.0.01";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gleFirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GridLookUpEdit gleFirm;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colNR;
        private DevExpress.XtraGrid.Columns.GridColumn colDESC;
        private DevExpress.XtraEditors.SimpleButton btnProdSummary;
        private DevExpress.XtraEditors.SimpleButton btnPosSummary;
        private DevExpress.XtraEditors.SimpleButton btnPosReturnSummary;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnFirm;
        private System.Windows.Forms.ToolStripMenuItem btnBranch;
        private System.Windows.Forms.ToolStripMenuItem btnOther;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
    }
}

