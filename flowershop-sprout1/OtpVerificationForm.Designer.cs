namespace flowershop_sprout
{
    partial class OtpVerificationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OtpVerificationForm));
            textBox1 = new TextBox();
            Confirm = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(94, 90);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(258, 23);
            textBox1.TabIndex = 0;
            // 
            // Confirm
            // 
            Confirm.Location = new Point(157, 132);
            Confirm.Name = "Confirm";
            Confirm.Size = new Size(129, 30);
            Confirm.TabIndex = 1;
            Confirm.Text = "Confirm";
            Confirm.UseVisualStyleBackColor = true;
            Confirm.Click += Confirm_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(81, 23);
            label1.Name = "label1";
            label1.Size = new Size(280, 45);
            label1.TabIndex = 2;
            label1.Text = "Type the OTP here";
            // 
            // OtpVerificationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(442, 247);
            Controls.Add(label1);
            Controls.Add(Confirm);
            Controls.Add(textBox1);
            Name = "OtpVerificationForm";
            Text = "OtpVerificationForm";
            Load += OtpVerificationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button Confirm;
        private Label label1;
    }
}