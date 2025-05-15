namespace flowershop_sprout
{
    partial class Forgotpass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forgotpass));
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            Searchbtn = new Button();
            comboBox1 = new ComboBox();
            textBox2 = new TextBox();
            button2 = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(111, 9);
            label1.Name = "label1";
            label1.Size = new Size(290, 40);
            label1.TabIndex = 0;
            label1.Text = "Recover your account";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(111, 109);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(307, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(141, 154);
            button1.Name = "button1";
            button1.Size = new Size(94, 34);
            button1.TabIndex = 2;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(111, 66);
            label2.Name = "label2";
            label2.Size = new Size(307, 30);
            label2.TabIndex = 3;
            label2.Text = "Enter the name of your account";
            // 
            // Searchbtn
            // 
            Searchbtn.Location = new Point(277, 154);
            Searchbtn.Name = "Searchbtn";
            Searchbtn.Size = new Size(102, 34);
            Searchbtn.TabIndex = 4;
            Searchbtn.Text = "Search";
            Searchbtn.UseVisualStyleBackColor = true;
            Searchbtn.Click += Searchbtn_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(150, 294);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(229, 23);
            comboBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(150, 334);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(229, 23);
            textBox2.TabIndex = 6;
            // 
            // button2
            // 
            button2.Location = new Point(192, 373);
            button2.Name = "button2";
            button2.Size = new Size(141, 34);
            button2.TabIndex = 7;
            button2.Text = "Confirm";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(180, 250);
            label3.Name = "label3";
            label3.Size = new Size(176, 30);
            label3.TabIndex = 8;
            label3.Text = "Security Question";
            // 
            // Forgotpass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(541, 445);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(comboBox1);
            Controls.Add(Searchbtn);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Forgotpass";
            Text = "Forgotpass";
            Load += Forgotpass_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
        private Button Searchbtn;
        private ComboBox comboBox1;
        private TextBox textBox2;
        private Button button2;
        private Label label3;
    }
}