namespace flowershop_sprout
{
    partial class zeShop
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
            label1 = new Label();
            cmbCategory = new ComboBox();
            btnAdd = new Button();
            label2 = new Label();
            txtDescription = new TextBox();
            txtPlantName = new TextBox();
            dgvProducts = new DataGridView();
            txtPrice = new TextBox();
            label3 = new Label();
            txtStockQuantity = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            pbPlantImage = new PictureBox();
            label7 = new Label();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnBrowseImage = new Button();
            openFileDialog1 = new OpenFileDialog();
            btnRefresh = new Button();
            linkLabel1 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPlantImage).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(302, 9);
            label1.Name = "label1";
            label1.Size = new Size(197, 15);
            label1.TabIndex = 0;
            label1.Text = "“I am free and that is why I am lost.”";
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(391, 59);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(108, 23);
            cmbCategory.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(36, 165);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 40);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 4;
            label2.Text = "Plant Name";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(514, 59);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(162, 63);
            txtDescription.TabIndex = 5;
            // 
            // txtPlantName
            // 
            txtPlantName.Location = new Point(27, 58);
            txtPlantName.Name = "txtPlantName";
            txtPlantName.Size = new Size(141, 23);
            txtPlantName.TabIndex = 6;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(36, 209);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(769, 199);
            dgvProducts.TabIndex = 9;
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(192, 59);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(66, 23);
            txtPrice.TabIndex = 11;
            txtPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(192, 40);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 10;
            label3.Text = "Price";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtStockQuantity
            // 
            txtStockQuantity.Location = new Point(275, 59);
            txtStockQuantity.Name = "txtStockQuantity";
            txtStockQuantity.Size = new Size(97, 23);
            txtStockQuantity.TabIndex = 13;
            txtStockQuantity.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(275, 41);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 12;
            label4.Text = "Stock Quantity";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(391, 41);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 14;
            label5.Text = "Category";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(514, 41);
            label6.Name = "label6";
            label6.Size = new Size(67, 15);
            label6.TabIndex = 15;
            label6.Text = "Description";
            // 
            // pbPlantImage
            // 
            pbPlantImage.Location = new Point(688, 59);
            pbPlantImage.Name = "pbPlantImage";
            pbPlantImage.Size = new Size(128, 113);
            pbPlantImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPlantImage.TabIndex = 16;
            pbPlantImage.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(688, 41);
            label7.Name = "label7";
            label7.Size = new Size(44, 15);
            label7.TabIndex = 17;
            label7.Text = "Picture";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(132, 165);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(93, 23);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(232, 165);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(86, 23);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(324, 165);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(89, 23);
            btnClear.TabIndex = 20;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.Location = new Point(688, 178);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(89, 23);
            btnBrowseImage.TabIndex = 21;
            btnBrowseImage.Text = "Browse Image";
            btnBrowseImage.UseVisualStyleBackColor = true;
            btnBrowseImage.Click += btnBrowseImage_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(514, 165);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 22;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(745, 411);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(56, 15);
            linkLabel1.TabIndex = 23;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "buy here!";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // zeShop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(837, 433);
            Controls.Add(linkLabel1);
            Controls.Add(btnRefresh);
            Controls.Add(btnBrowseImage);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(label7);
            Controls.Add(pbPlantImage);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtStockQuantity);
            Controls.Add(label4);
            Controls.Add(txtPrice);
            Controls.Add(label3);
            Controls.Add(dgvProducts);
            Controls.Add(txtPlantName);
            Controls.Add(txtDescription);
            Controls.Add(label2);
            Controls.Add(btnAdd);
            Controls.Add(cmbCategory);
            Controls.Add(label1);
            Name = "zeShop";
            Text = "zeShop";
            Load += zeShop_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPlantImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbCategory;
        private Button btnAdd;
        private Label label2;
        private TextBox txtDescription;
        private TextBox txtPlantName;
        private DataGridView dgvProducts;
        private TextBox txtPrice;
        private Label label3;
        private TextBox txtStockQuantity;
        private Label label4;
        private Label label5;
        private Label label6;
        private PictureBox pbPlantImage;
        private Label label7;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnBrowseImage;
        private OpenFileDialog openFileDialog1;
        private Button btnRefresh;
        private LinkLabel linkLabel1;
    }
}