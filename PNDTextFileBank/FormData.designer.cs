namespace PNDTextFileBank
{
    partial class FormData
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboType = new System.Windows.Forms.ComboBox();
            this.BtnQuery = new System.Windows.Forms.Button();
            this.BtnExport = new System.Windows.Forms.Button();
            this.TextPrice = new System.Windows.Forms.TextBox();
            this.TextTax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnChangeDb = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TextDatabase = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(12, 96);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.Size = new System.Drawing.Size(760, 453);
            this.DGV.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PND Type";
            // 
            // ComboType
            // 
            this.ComboType.FormattingEnabled = true;
            this.ComboType.Items.AddRange(new object[] {
            "PND3",
            "PND53"});
            this.ComboType.Location = new System.Drawing.Point(93, 58);
            this.ComboType.Name = "ComboType";
            this.ComboType.Size = new System.Drawing.Size(110, 21);
            this.ComboType.TabIndex = 2;
            // 
            // BtnQuery
            // 
            this.BtnQuery.Location = new System.Drawing.Point(217, 57);
            this.BtnQuery.Name = "BtnQuery";
            this.BtnQuery.Size = new System.Drawing.Size(75, 23);
            this.BtnQuery.TabIndex = 7;
            this.BtnQuery.Text = "Execute";
            this.BtnQuery.UseVisualStyleBackColor = true;
            this.BtnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.Location = new System.Drawing.Point(298, 57);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(75, 23);
            this.BtnExport.TabIndex = 8;
            this.BtnExport.Text = "Export";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // TextPrice
            // 
            this.TextPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextPrice.Location = new System.Drawing.Point(602, 20);
            this.TextPrice.Name = "TextPrice";
            this.TextPrice.ReadOnly = true;
            this.TextPrice.Size = new System.Drawing.Size(150, 20);
            this.TextPrice.TabIndex = 9;
            // 
            // TextTax
            // 
            this.TextTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextTax.Location = new System.Drawing.Point(602, 59);
            this.TextTax.Name = "TextTax";
            this.TextTax.ReadOnly = true;
            this.TextTax.Size = new System.Drawing.Size(150, 20);
            this.TextTax.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(526, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Total Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(526, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Total Tax";
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(379, 57);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(75, 23);
            this.BtnExit.TabIndex = 13;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnChangeDb
            // 
            this.BtnChangeDb.Location = new System.Drawing.Point(217, 18);
            this.BtnChangeDb.Name = "BtnChangeDb";
            this.BtnChangeDb.Size = new System.Drawing.Size(237, 23);
            this.BtnChangeDb.TabIndex = 14;
            this.BtnChangeDb.Text = "Change Database";
            this.BtnChangeDb.UseVisualStyleBackColor = true;
            this.BtnChangeDb.Click += new System.EventHandler(this.BtnChangeDb_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Database";
            // 
            // TextDatabase
            // 
            this.TextDatabase.Location = new System.Drawing.Point(93, 20);
            this.TextDatabase.Name = "TextDatabase";
            this.TextDatabase.ReadOnly = true;
            this.TextDatabase.Size = new System.Drawing.Size(110, 20);
            this.TextDatabase.TabIndex = 16;
            // 
            // FormData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.TextDatabase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnChangeDb);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextTax);
            this.Controls.Add(this.TextPrice);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.BtnQuery);
            this.Controls.Add(this.ComboType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGV);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PND Bank | Data Query";
            this.Load += new System.EventHandler(this.FormData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboType;
        private System.Windows.Forms.Button BtnQuery;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.TextBox TextPrice;
        private System.Windows.Forms.TextBox TextTax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnChangeDb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextDatabase;
    }
}