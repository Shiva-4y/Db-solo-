namespace flowershop_sprout
{
    partial class PasswordResetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordResetForm));
            label1 = new Label();
            panel1 = new Panel();
            button1 = new Button();
            textBox2 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(53, 10);
            label1.Name = "label1";
            label1.Size = new Size(311, 45);
            label1.TabIndex = 0;
            label1.Text = "Reset Your Password";
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(129, 79);
            panel1.Name = "panel1";
            panel1.Size = new Size(413, 272);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.Location = new Point(182, 193);
            button1.Name = "button1";
            button1.Size = new Size(139, 23);
            button1.TabIndex = 10;
            button1.Text = "Reset";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(71, 152);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(250, 23);
            textBox2.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(53, 236);
            label4.Name = "label4";
            label4.Size = new Size(137, 15);
            label4.TabIndex = 7;
            label4.Text = "No Account? Sign-up ->";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(71, 128);
            label3.Name = "label3";
            label3.Size = new Size(180, 21);
            label3.TabIndex = 7;
            label3.Text = "Confirm New Password*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(71, 78);
            label2.Name = "label2";
            label2.Size = new Size(119, 21);
            label2.TabIndex = 6;
            label2.Text = "New Password*";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(71, 102);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 23);
            textBox1.TabIndex = 8;
            // 
            // PasswordResetForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(663, 395);
            Controls.Add(panel1);
            Name = "PasswordResetForm";
            Text = "PasswordResetForm";
            Load += PasswordResetForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label4;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox1;
        private Button button1;
    }
}