using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace flowershop_sprout
{
    public partial class Signup : Form
    {
        private string connectionString = "server=127.0.0.1; database=flower_shop; uid=root; pwd=sukhoi57;";
        private bool passwordVisible = false; // Track visibility

        public Signup()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.closed_eyes; // Set default icon

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(128, 0, 0, 0); // RGBA: 128 = 50% transparency

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text;
            string password = textBox2.Text;


            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }
            if (!IsValidPassword(password))
            {
                MessageBox.Show("Password must be at least 6 characters long, include an uppercase letter, a digit, and a special character.");
                return;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password); //hash

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();


                    string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);
                        int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (userExists > 0)
                        {
                            MessageBox.Show("Username already exists. Choose another one.");
                            return;
                        }
                    }


                    string query = "INSERT INTO users (username, password) VALUES (@username, @password)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Signup Successful!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Signup Failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible; // Toggle visibility state
            textBox2.UseSystemPasswordChar = !passwordVisible; // Toggle password mask

            // Swap eye icons
            pictureBox1.Image = passwordVisible ? Properties.Resources.closed_eyes : Properties.Resources.eye_43;
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }
        private bool IsValidPassword(string password)
        {
            if (password.Length < 6) {
                return false;
            }
            bool hasUpper = password.Any(char.IsUpper);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecial = password.Any(ch => !char.IsLetterOrDigit(ch));
            return hasUpper && hasDigit && hasSpecial;
        }
    }
}
