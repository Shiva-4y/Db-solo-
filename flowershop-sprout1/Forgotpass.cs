using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic; // For List
using System.Windows.Forms;

namespace flowershop_sprout
{
    public partial class Forgotpass : Form
    {
        private string connectionString = "server=127.0.0.1; database=flower_shop; uid=root; pwd=sukhoi57;";
        private string generatedOTP;
        private DateTime otpGeneratedTime; // Track OTP creation time

        public Forgotpass()
        {
            InitializeComponent();
            InitializeVisibility(); // Ensure initial visibility state
        }

        // 👁️ Initialize hidden fields
        private void InitializeVisibility()
        {
            label3.Visible = false;
            textBox2.Visible = false;
            comboBox1.Visible = false;
            button2.Visible = false;
        }

        private void Forgotpass_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        // 🔍 Search Account Button
        private void Searchbtn_Click(object sender, EventArgs e)
        {
            DeleteExpiredOTPs();
            string username = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter your account name.",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT username, security_question FROM users WHERE username = @username";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // ✅ User Found
                        {
                            string securityQuestion = reader["security_question"].ToString();

                            // 🔹 Predefined Security Questions
                            List<string> predefinedQuestions = new List<string>
                            {
                                "What is your pet's name?",
                                "What is your mother's maiden name?",
                                "What was the name of your first school?",
                                "Is it pink?",
                                "Do you love me?",
                                "Would you kill if necessary?",
                                "What is your favorite food?",
                                "What city were you born in?"
                            };

                            // 🔹 Display security questions in ComboBox
                            comboBox1.Items.Clear();
                            comboBox1.Items.Add("-- Select your security question --"); // Placeholder
                            foreach (var question in predefinedQuestions)
                            {
                                comboBox1.Items.Add(question);
                            }

                            // 🔹 Add the user's stored security question if missing
                            if (!comboBox1.Items.Contains(securityQuestion))
                            {
                                comboBox1.Items.Add(securityQuestion);
                            }

                            comboBox1.SelectedIndex = 0; // Placeholder as default

                            // 🔹 Store correct security question for verification
                            comboBox1.Tag = securityQuestion;

                            // 👁️ Show hidden fields
                            comboBox1.Visible = true;
                            textBox2.Visible = true;
                            button2.Visible = true;

                            MessageBox.Show("Security question found. Please answer it.",
                                            "Verification Required",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Account not found. Please try again.",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);

                            InitializeVisibility(); // 🔒 Keep fields hidden if user doesn't exist
                        }
                    }
                }
            }
        }

        // 🔐 Verify Security Answer Button (Button 2)
        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        // 📥 Save OTP to Database
        private void SaveOTPToDatabase(string username, string otp, MySqlConnection conn)
        {
            string insertQuery = @"
            INSERT INTO password_resets (username, otp, created_at)
            VALUES (@username, @otp, NOW())";

            using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@otp", otp);
                cmd.ExecuteNonQuery();
            }
        }

        // 🚫 Delete Expired OTPs
        private void DeleteExpiredOTPs()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string deleteQuery = "DELETE FROM password_resets WHERE created_at < NOW() - INTERVAL 2 MINUTE";
                using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 🔢 OTP Generator
        private string GenerateOTP()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999).ToString(); // 6-digit OTP
        }

        // ❌ Close Button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string answer = textBox2.Text.Trim();

            if (comboBox1.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select your security question.",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string selectedQuestion = comboBox1.SelectedItem.ToString();
            if (selectedQuestion != comboBox1.Tag?.ToString())
            {
                MessageBox.Show("The selected security question does not match your account's security question.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(answer))
            {
                MessageBox.Show("Please enter your security answer.",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT security_answer FROM users WHERE username = @username";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    string storedAnswer = cmd.ExecuteScalar()?.ToString();

                    if (storedAnswer != null && answer.Equals(storedAnswer, StringComparison.OrdinalIgnoreCase))
                    {
                        // ✅ Generate OTP if security answer matches
                        generatedOTP = GenerateOTP();
                        otpGeneratedTime = DateTime.Now;

                        MessageBox.Show($"Your OTP Code: {generatedOTP}\nThis OTP will expire in 2 minutes.",
                                        "OTP Generated",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        SaveOTPToDatabase(username, generatedOTP, conn);

                        // Open OTP Verification Form
                        OtpVerificationForm otpForm = new OtpVerificationForm(generatedOTP, otpGeneratedTime, username);
                        otpForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect security answer. Please try again.",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
