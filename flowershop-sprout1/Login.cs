using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace flowershop_sprout
{
    public partial class Login : Form
    {
        private string connectionString = "server=127.0.0.1; database=flower_shop; uid=root; pwd=sukhoi57;";

        public Login()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text.Trim();
            string password = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Step 1: Retrieve the Salt
                    string saltQuery = "SELECT salt FROM users WHERE username = @username";
                    using (MySqlCommand saltCmd = new MySqlCommand(saltQuery, conn))
                    {
                        saltCmd.Parameters.AddWithValue("@username", username);
                        string storedSalt = saltCmd.ExecuteScalar()?.ToString();

                        if (string.IsNullOrEmpty(storedSalt))
                        {
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Step 2: Retrieve the Hashed Password
                        string query = "SELECT password FROM users WHERE username = @username";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", username);
                            object result = cmd.ExecuteScalar();

                            if (result != null)
                            {
                                string storedHashedPassword = result.ToString();

                                // Step 3: Combine Password + Salt before Verifying
                                string combinedPassword = password + storedSalt;

                                if (BCrypt.Net.BCrypt.Verify(combinedPassword, storedHashedPassword))
                                {
                                    MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Hide();
                                    zeShop zeshop = new zeShop();
                                    zeshop.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = !checkBox1.Checked;

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forgotpass forgotpass = new Forgotpass();
            forgotpass.Show();
            this.Hide();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Hide();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(128, 0, 0, 0);
        }

        private void Login_Load_1(object sender, EventArgs e)
        {

        }
    }
}
