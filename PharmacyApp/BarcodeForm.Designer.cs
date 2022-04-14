namespace PharmacyApp
{
    partial class BarcodeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCamera = new System.Windows.Forms.ComboBox();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.MedicinePanel = new System.Windows.Forms.Panel();
            this.btnBuy = new System.Windows.Forms.Button();
            this.ckBuyMedicine = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMedicine = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.barcodePicture = new System.Windows.Forms.PictureBox();
            this.MedicinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barcodePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camera:";
            // 
            // cmbCamera
            // 
            this.cmbCamera.FormattingEnabled = true;
            this.cmbCamera.Location = new System.Drawing.Point(111, 33);
            this.cmbCamera.Name = "cmbCamera";
            this.cmbCamera.Size = new System.Drawing.Size(200, 21);
            this.cmbCamera.TabIndex = 1;
            // 
            // btnBarcode
            // 
            this.btnBarcode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBarcode.Location = new System.Drawing.Point(32, 393);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(98, 30);
            this.btnBarcode.TabIndex = 3;
            this.btnBarcode.Text = "Start";
            this.btnBarcode.UseVisualStyleBackColor = false;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // MedicinePanel
            // 
            this.MedicinePanel.Controls.Add(this.btnBuy);
            this.MedicinePanel.Controls.Add(this.ckBuyMedicine);
            this.MedicinePanel.Controls.Add(this.label7);
            this.MedicinePanel.Controls.Add(this.numCount);
            this.MedicinePanel.Controls.Add(this.label6);
            this.MedicinePanel.Controls.Add(this.txtMedicine);
            this.MedicinePanel.Controls.Add(this.btnAdd);
            this.MedicinePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.MedicinePanel.Location = new System.Drawing.Point(495, 0);
            this.MedicinePanel.Name = "MedicinePanel";
            this.MedicinePanel.Size = new System.Drawing.Size(405, 450);
            this.MedicinePanel.TabIndex = 13;
            // 
            // btnBuy
            // 
            this.btnBuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnBuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBuy.Location = new System.Drawing.Point(190, 332);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 31);
            this.btnBuy.TabIndex = 10;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = false;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // ckBuyMedicine
            // 
            this.ckBuyMedicine.FormattingEnabled = true;
            this.ckBuyMedicine.Location = new System.Drawing.Point(190, 30);
            this.ckBuyMedicine.Name = "ckBuyMedicine";
            this.ckBuyMedicine.Size = new System.Drawing.Size(212, 259);
            this.ckBuyMedicine.TabIndex = 9;
            this.ckBuyMedicine.SelectedIndexChanged += new System.EventHandler(this.ckBuyMedicine_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label7.Location = new System.Drawing.Point(10, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Count";
            // 
            // numCount
            // 
            this.numCount.Location = new System.Drawing.Point(13, 104);
            this.numCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCount.Name = "numCount";
            this.numCount.Size = new System.Drawing.Size(132, 20);
            this.numCount.TabIndex = 2;
            this.numCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label6.Location = new System.Drawing.Point(9, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Medicine";
            // 
            // txtMedicine
            // 
            this.txtMedicine.Enabled = false;
            this.txtMedicine.Location = new System.Drawing.Point(13, 32);
            this.txtMedicine.Name = "txtMedicine";
            this.txtMedicine.Size = new System.Drawing.Size(132, 20);
            this.txtMedicine.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAdd.Location = new System.Drawing.Point(13, 153);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 31);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Location = new System.Drawing.Point(32, 343);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(279, 20);
            this.txtBarcode.TabIndex = 14;
            // 
            // barcodePicture
            // 
            this.barcodePicture.Location = new System.Drawing.Point(32, 74);
            this.barcodePicture.Name = "barcodePicture";
            this.barcodePicture.Size = new System.Drawing.Size(447, 263);
            this.barcodePicture.TabIndex = 15;
            this.barcodePicture.TabStop = false;
            // 
            // BarcodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.barcodePicture);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.MedicinePanel);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.cmbCamera);
            this.Controls.Add(this.label1);
            this.Name = "BarcodeForm";
            this.Text = "BarcodeForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BarcodeForm_FormClosing);
            this.Load += new System.EventHandler(this.BarcodeForm_Load);
            this.MedicinePanel.ResumeLayout(false);
            this.MedicinePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barcodePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCamera;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.Panel MedicinePanel;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.CheckedListBox ckBuyMedicine;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMedicine;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.PictureBox barcodePicture;
    }
}