namespace flowershop_sprout
{
    partial class BuyForm
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
            cmbProducts = new ComboBox();
            txtPrice = new TextBox();
            Price = new Label();
            btnBuy = new Button();
            txtQuantity = new TextBox();
            pictureBoxFlower = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            linkLabel1 = new LinkLabel();
            btnExportPDF = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFlower).BeginInit();
            SuspendLayout();
            // 
            // cmbProducts
            // 
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(148, 56);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(121, 23);
            cmbProducts.TabIndex = 0;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(329, 56);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(100, 23);
            txtPrice.TabIndex = 1;
            // 
            // Price
            // 
            Price.AutoSize = true;
            Price.Location = new Point(329, 38);
            Price.Name = "Price";
            Price.Size = new Size(33, 15);
            Price.TabIndex = 2;
            Price.Text = "Price";
            // 
            // btnBuy
            // 
            btnBuy.Location = new Point(329, 241);
            btnBuy.Name = "btnBuy";
            btnBuy.Size = new Size(91, 32);
            btnBuy.TabIndex = 3;
            btnBuy.Text = "Buy";
            btnBuy.UseVisualStyleBackColor = true;
            btnBuy.Click += btnBuy_Click;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(494, 56);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 23);
            txtQuantity.TabIndex = 4;
            // 
            // pictureBoxFlower
            // 
            pictureBoxFlower.Location = new Point(148, 85);
            pictureBoxFlower.Name = "pictureBoxFlower";
            pictureBoxFlower.Size = new Size(464, 141);
            pictureBoxFlower.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxFlower.TabIndex = 5;
            pictureBoxFlower.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(494, 38);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 6;
            label1.Text = "Quantity";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(148, 38);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 7;
            label2.Text = "Choose a flower";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(341, 370);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(60, 15);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "linkLabel1";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // btnExportPDF
            // 
            btnExportPDF.Location = new Point(622, 361);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(110, 33);
            btnExportPDF.TabIndex = 9;
            btnExportPDF.Text = "Generate Report";
            btnExportPDF.UseVisualStyleBackColor = true;
            btnExportPDF.Click += btnExportPDF_Click;
            // 
            // BuyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExportPDF);
            Controls.Add(linkLabel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBoxFlower);
            Controls.Add(txtQuantity);
            Controls.Add(btnBuy);
            Controls.Add(Price);
            Controls.Add(txtPrice);
            Controls.Add(cmbProducts);
            Name = "BuyForm";
            Text = "BuyForm";
            Load += BuyForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxFlower).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbProducts;
        private TextBox txtPrice;
        private Label Price;
        private Button btnBuy;
        private TextBox txtQuantity;
        private PictureBox pictureBoxFlower;
        private Label label1;
        private Label label2;
        private LinkLabel linkLabel1;
        private Button btnExportPDF;
    }
}