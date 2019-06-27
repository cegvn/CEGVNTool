namespace CEGVNTool
{
    partial class FindImportInstanceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindImportInstanceForm));
            this.dtgView = new System.Windows.Forms.DataGridView();
            this.dwgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sheetNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sheetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeBtn = new System.Windows.Forms.Button();
            this.gotoSheetBtn = new System.Windows.Forms.Button();
            this.gotoViewBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgView)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgView
            // 
            this.dtgView.AllowUserToAddRows = false;
            this.dtgView.AllowUserToDeleteRows = false;
            this.dtgView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dwgName,
            this.viewName,
            this.sheetNumber,
            this.sheetName,
            this.id});
            this.dtgView.Location = new System.Drawing.Point(12, 12);
            this.dtgView.Name = "dtgView";
            this.dtgView.RowHeadersWidth = 4;
            this.dtgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgView.Size = new System.Drawing.Size(860, 508);
            this.dtgView.TabIndex = 0;
            // 
            // dwgName
            // 
            this.dwgName.HeaderText = "DWG Name";
            this.dwgName.Name = "dwgName";
            this.dwgName.Width = 153;
            // 
            // viewName
            // 
            this.viewName.HeaderText = "View Name";
            this.viewName.Name = "viewName";
            this.viewName.Width = 300;
            // 
            // sheetNumber
            // 
            this.sheetNumber.HeaderText = "Sheet Number";
            this.sheetNumber.Name = "sheetNumber";
            // 
            // sheetName
            // 
            this.sheetName.HeaderText = "Sheet Name";
            this.sheetName.Name = "sheetName";
            this.sheetName.Width = 300;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // closeBtn
            // 
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(792, 526);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(80, 23);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            // 
            // gotoSheetBtn
            // 
            this.gotoSheetBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.gotoSheetBtn.Location = new System.Drawing.Point(706, 526);
            this.gotoSheetBtn.Name = "gotoSheetBtn";
            this.gotoSheetBtn.Size = new System.Drawing.Size(80, 23);
            this.gotoSheetBtn.TabIndex = 2;
            this.gotoSheetBtn.Text = "Go To Sheet";
            this.gotoSheetBtn.UseVisualStyleBackColor = true;
            this.gotoSheetBtn.Click += new System.EventHandler(this.gotoSheetBtn_Click);
            // 
            // gotoViewBtn
            // 
            this.gotoViewBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.gotoViewBtn.Location = new System.Drawing.Point(620, 526);
            this.gotoViewBtn.Name = "gotoViewBtn";
            this.gotoViewBtn.Size = new System.Drawing.Size(80, 23);
            this.gotoViewBtn.TabIndex = 3;
            this.gotoViewBtn.Text = "Go to View";
            this.gotoViewBtn.UseVisualStyleBackColor = true;
            this.gotoViewBtn.Click += new System.EventHandler(this.gotoViewBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 531);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // FindImportInstanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gotoViewBtn);
            this.Controls.Add(this.gotoSheetBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.dtgView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FindImportInstanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CEG Tool - Find Import Instances";
            this.Load += new System.EventHandler(this.FindImportInstanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgView;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button gotoSheetBtn;
        private System.Windows.Forms.Button gotoViewBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dwgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn viewName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sheetNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn sheetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.Label label1;
    }
}