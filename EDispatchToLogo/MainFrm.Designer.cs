
namespace EDispatchToLogo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.lblFirm = new DevExpress.XtraEditors.LabelControl();
            this.gleFirm = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnEDispatch = new DevExpress.XtraEditors.SimpleButton();
            this.btnEDispatchCollective = new DevExpress.XtraEditors.SimpleButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cmsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnInvoice = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gleFirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFirm
            // 
            this.lblFirm.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFirm.Appearance.Options.UseFont = true;
            this.lblFirm.Location = new System.Drawing.Point(90, 54);
            this.lblFirm.Name = "lblFirm";
            this.lblFirm.Size = new System.Drawing.Size(38, 13);
            this.lblFirm.TabIndex = 1;
            this.lblFirm.Text = "Firma :";
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
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // btnEDispatch
            // 
            this.btnEDispatch.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnEDispatch.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnEDispatch.Appearance.Options.UseBackColor = true;
            this.btnEDispatch.Appearance.Options.UseFont = true;
            this.btnEDispatch.Location = new System.Drawing.Point(90, 91);
            this.btnEDispatch.Name = "btnEDispatch";
            this.btnEDispatch.Size = new System.Drawing.Size(168, 51);
            this.btnEDispatch.TabIndex = 2;
            this.btnEDispatch.Text = "eİRSALİYE";
            this.btnEDispatch.Click += new System.EventHandler(this.btnEDispatch_Click);
            // 
            // btnEDispatchCollective
            // 
            this.btnEDispatchCollective.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnEDispatchCollective.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnEDispatchCollective.Appearance.Options.UseBackColor = true;
            this.btnEDispatchCollective.Appearance.Options.UseFont = true;
            this.btnEDispatchCollective.Location = new System.Drawing.Point(90, 148);
            this.btnEDispatchCollective.Name = "btnEDispatchCollective";
            this.btnEDispatchCollective.Size = new System.Drawing.Size(168, 51);
            this.btnEDispatchCollective.TabIndex = 3;
            this.btnEDispatchCollective.Text = "eİRSALİYE (Toplu)";
            this.btnEDispatchCollective.Click += new System.EventHandler(this.btnEDispatchCollective_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(554, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cmsExit
            // 
            this.cmsExit.Name = "cmsExit";
            this.cmsExit.Size = new System.Drawing.Size(44, 20);
            this.cmsExit.Text = "Çıkış";
            this.cmsExit.Click += new System.EventHandler(this.cmsExit_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnInvoice
            // 
            this.btnInvoice.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnInvoice.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnInvoice.Appearance.Options.UseBackColor = true;
            this.btnInvoice.Appearance.Options.UseFont = true;
            this.btnInvoice.Location = new System.Drawing.Point(315, 91);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(168, 51);
            this.btnInvoice.TabIndex = 5;
            this.btnInvoice.Text = "FATURA";
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(554, 232);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.btnEDispatchCollective);
            this.Controls.Add(this.btnEDispatch);
            this.Controls.Add(this.gleFirm);
            this.Controls.Add(this.lblFirm);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[eİrsaliye Aktarımı] v1.0.0.01";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gleFirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblFirm;
        private DevExpress.XtraEditors.GridLookUpEdit gleFirm;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.SimpleButton btnEDispatch;
        private DevExpress.XtraEditors.SimpleButton btnEDispatchCollective;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmsExit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private DevExpress.XtraEditors.SimpleButton btnInvoice;
    }
}

