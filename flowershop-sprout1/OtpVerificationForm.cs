using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace flowershop_sprout
{
    public partial class OtpVerificationForm : Form
    {
        private string generatedOtp;
        private DateTime otpGeneratedTime;
        private string username; // Added username to pass in the PasswordResetForm

        public OtpVerificationForm(string otp, DateTime otpTime, string user)
        {
            InitializeComponent();
            generatedOtp = otp;
            otpGeneratedTime = otpTime;
            username = user;

            // Start a countdown timer
            System.Windows.Forms.Timer countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000; // 1 second interval
            countdownTimer.Tick += (sender, e) =>
            {
                TimeSpan timeElapsed = DateTime.Now - otpGeneratedTime;
                int secondsRemaining = 120 - (int)timeElapsed.TotalSeconds;

                if (secondsRemaining <= 0)
                {
                    countdownTimer.Stop();
                    countdownTimer.Dispose();
                    MessageBox.Show("Your OTP has expired. Please request a new one.", "OTP Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            };
            countdownTimer.Start();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Equals(generatedOtp, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("OTP Verified! Proceed to reset your password.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                PasswordResetForm resetForm = new PasswordResetForm(username);
                resetForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid OTP. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OtpVerificationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
    

