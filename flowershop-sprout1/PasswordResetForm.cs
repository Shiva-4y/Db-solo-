using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace flowershop_sprout
{
    public partial class PasswordResetForm : Form
    {
        private string connectionString = "server=127.0.0.1; database=flower_shop; uid=root; pwd=sukhoi57;";
        private string username;

        public PasswordResetForm(string user)
        {
            InitializeComponent();
            username = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newPassword = textBox1.Text.Trim();
            string confirmPassword = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in both password fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Step 1: Generate a new Salt
            string newSalt = BCrypt.Net.BCrypt.GenerateSalt();

            // Step 2: Hash the new password + salt
            string combinedPassword = newPassword + newSalt;
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(combinedPassword);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Step 3: Update both password and salt in the database
                string updateQuery = "UPDATE users SET password = @password, salt = @salt WHERE username = @username";
                using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@salt", newSalt);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Password reset successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(128, 0, 0, 0);
        }
    



private void PasswordResetForm_Load(object sender, EventArgs e)
        {

        }
    }
}
