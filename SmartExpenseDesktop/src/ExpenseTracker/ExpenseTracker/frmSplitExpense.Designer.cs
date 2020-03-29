namespace SET.ExpenseTracker
{
    partial class frmSplitExpense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplitExpense));
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoSplitByAmount = new System.Windows.Forms.RadioButton();
            this.rdoCustomSplitPercentage = new System.Windows.Forms.RadioButton();
            this.rdoEqualSplit = new System.Windows.Forms.RadioButton();
            this.dgAllExpense = new System.Windows.Forms.DataGridView();
            this.cboGroups = new System.Windows.Forms.ComboBox();
            this.dtTransactionDatePicker = new System.Windows.Forms.DateTimePicker();
            this.dgSplit = new System.Windows.Forms.DataGridView();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtExpenseDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAllExpense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSplit)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(191, 459);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 41);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(316, 459);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 41);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.rdoSplitByAmount);
            this.groupBox1.Controls.Add(this.rdoCustomSplitPercentage);
            this.groupBox1.Controls.Add(this.rdoEqualSplit);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.dgAllExpense);
            this.groupBox1.Controls.Add(this.cboGroups);
            this.groupBox1.Controls.Add(this.dtTransactionDatePicker);
            this.groupBox1.Controls.Add(this.dgSplit);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.txtExpenseDesc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 519);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // rdoSplitByAmount
            // 
            this.rdoSplitByAmount.AutoSize = true;
            this.rdoSplitByAmount.Location = new System.Drawing.Point(308, 218);
            this.rdoSplitByAmount.Name = "rdoSplitByAmount";
            this.rdoSplitByAmount.Size = new System.Drawing.Size(127, 21);
            this.rdoSplitByAmount.TabIndex = 17;
            this.rdoSplitByAmount.Text = "Split by Amount";
            this.rdoSplitByAmount.UseVisualStyleBackColor = true;
            this.rdoSplitByAmount.CheckedChanged += new System.EventHandler(this.rdoSplitByAmount_CheckedChanged);
            // 
            // rdoCustomSplitPercentage
            // 
            this.rdoCustomSplitPercentage.AutoSize = true;
            this.rdoCustomSplitPercentage.Location = new System.Drawing.Point(184, 218);
            this.rdoCustomSplitPercentage.Name = "rdoCustomSplitPercentage";
            this.rdoCustomSplitPercentage.Size = new System.Drawing.Size(91, 21);
            this.rdoCustomSplitPercentage.TabIndex = 16;
            this.rdoCustomSplitPercentage.Text = "Split by %";
            this.rdoCustomSplitPercentage.UseVisualStyleBackColor = true;
            this.rdoCustomSplitPercentage.CheckedChanged += new System.EventHandler(this.rdoCustomSplitPercentage_CheckedChanged);
            // 
            // rdoEqualSplit
            // 
            this.rdoEqualSplit.AutoSize = true;
            this.rdoEqualSplit.Checked = true;
            this.rdoEqualSplit.Location = new System.Drawing.Point(45, 218);
            this.rdoEqualSplit.Name = "rdoEqualSplit";
            this.rdoEqualSplit.Size = new System.Drawing.Size(106, 21);
            this.rdoEqualSplit.TabIndex = 15;
            this.rdoEqualSplit.TabStop = true;
            this.rdoEqualSplit.Text = "Split Equally";
            this.rdoEqualSplit.UseVisualStyleBackColor = true;
            // 
            // dgAllExpense
            // 
            this.dgAllExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAllExpense.Location = new System.Drawing.Point(472, 21);
            this.dgAllExpense.Name = "dgAllExpense";
            this.dgAllExpense.RowHeadersWidth = 51;
            this.dgAllExpense.RowTemplate.Height = 24;
            this.dgAllExpense.Size = new System.Drawing.Size(530, 432);
            this.dgAllExpense.TabIndex = 14;
            this.dgAllExpense.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAllExpense_CellClick);
            // 
            // cboGroups
            // 
            this.cboGroups.FormattingEnabled = true;
            this.cboGroups.Location = new System.Drawing.Point(208, 97);
            this.cboGroups.Name = "cboGroups";
            this.cboGroups.Size = new System.Drawing.Size(225, 24);
            this.cboGroups.TabIndex = 13;
            // 
            // dtTransactionDatePicker
            // 
            this.dtTransactionDatePicker.Location = new System.Drawing.Point(208, 56);
            this.dtTransactionDatePicker.Name = "dtTransactionDatePicker";
            this.dtTransactionDatePicker.Size = new System.Drawing.Size(225, 22);
            this.dtTransactionDatePicker.TabIndex = 12;
            // 
            // dgSplit
            // 
            this.dgSplit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSplit.Location = new System.Drawing.Point(41, 249);
            this.dgSplit.Name = "dgSplit";
            this.dgSplit.RowHeadersWidth = 51;
            this.dgSplit.RowTemplate.Height = 24;
            this.dgSplit.Size = new System.Drawing.Size(392, 204);
            this.dgSplit.TabIndex = 11;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(208, 181);
            this.txtAmount.MaxLength = 100;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(225, 22);
            this.txtAmount.TabIndex = 9;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // txtExpenseDesc
            // 
            this.txtExpenseDesc.Location = new System.Drawing.Point(208, 140);
            this.txtExpenseDesc.MaxLength = 100;
            this.txtExpenseDesc.Name = "txtExpenseDesc";
            this.txtExpenseDesc.Size = new System.Drawing.Size(225, 22);
            this.txtExpenseDesc.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Expense Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Expense Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Expense Desc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Group Name";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Location = new System.Drawing.Point(880, 461);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(58, 58);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Location = new System.Drawing.Point(944, 459);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(58, 58);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmSplitExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 543);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSplitExpense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Split Management";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAllExpense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSplit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtExpenseDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgSplit;
        private System.Windows.Forms.DateTimePicker dtTransactionDatePicker;
        private System.Windows.Forms.ComboBox cboGroups;
        private System.Windows.Forms.DataGridView dgAllExpense;
        private System.Windows.Forms.RadioButton rdoCustomSplitPercentage;
        private System.Windows.Forms.RadioButton rdoEqualSplit;
        private System.Windows.Forms.RadioButton rdoSplitByAmount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
    }
}