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

namespace flowershop_sprout
{
    public partial class zeShop : Form
    {
        private string connectionString = "server=127.0.0.1; database=flower_shop; uid=root; pwd=sukhoi57;";
        MySqlConnection connection;

        public zeShop()
        {
            InitializeComponent();
        }

        private void zeShop_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(217, 212, 201); // #D9D4C9
            connection = new MySqlConnection(connectionString);
            LoadProducts();  // Load data when the form opens
            cmbCategory.Items.Add("Indoor");
            cmbCategory.Items.Add("Outdoor");
            cmbCategory.Items.Add("Aquatic");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void LoadProducts()
        {
            try
            {
                string query = "SELECT id, plant_name, category, price, stock_quantity, description, image_path FROM Products";
                DataTable dt = new DataTable();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }

                dgvProducts.DataSource = dt;

                // Optional: Auto-adjust column width
                dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO Products (plant_name, category, price, stock_quantity, description, image_path) " +
                               "VALUES (@name, @category, @price, @stock, @description, @imagePath)";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", txtPlantName.Text);
                    cmd.Parameters.AddWithValue("@category", cmbCategory.Text);
                    cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(txtStockQuantity.Text));
                    cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@imagePath", pbPlantImage.ImageLocation ?? "");

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Plant added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }


        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is selected
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                txtPlantName.Text = row.Cells["plant_name"].Value.ToString();
                cmbCategory.Text = row.Cells["category"].Value.ToString();
                txtPrice.Text = row.Cells["price"].Value.ToString();
                txtStockQuantity.Text = row.Cells["stock_quantity"].Value.ToString();
                txtDescription.Text = row.Cells["description"].Value.ToString();

                // Load image if available
                string imagePath = row.Cells["image_path"].Value.ToString();
                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    pbPlantImage.Image = Image.FromFile(imagePath);
                }
                else
                {
                    pbPlantImage.Image = null; // Clear the picture box if no image exists
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE Products SET plant_name = @name, category = @category, price = @price, " +
                               "stock_quantity = @stock, description = @description, image_path = @imagePath " +
                               "WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", dgvProducts.CurrentRow.Cells["id"].Value);
                    cmd.Parameters.AddWithValue("@name", txtPlantName.Text);
                    cmd.Parameters.AddWithValue("@category", cmbCategory.Text);
                    cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(txtStockQuantity.Text));
                    cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@imagePath", pbPlantImage.ImageLocation ?? "");

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts(); // Refresh the DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm Deletion",
       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM Products WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", dgvProducts.CurrentRow.Cells["id"].Value);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProducts(); // Refresh the DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPlantName.Clear();
            cmbCategory.SelectedIndex = -1; // Clear dropdown selection
            txtPrice.Clear();
            txtStockQuantity.Clear();
            txtDescription.Clear();
            pbPlantImage.Image = null; // Clear the image preview
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"; // Filter for image types
            openFileDialog1.Title = "Select Plant Image";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPlantImage.Image = Image.FromFile(openFileDialog1.FileName);
                pbPlantImage.ImageLocation = openFileDialog1.FileName; // Store the path for database saving
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BuyForm buyform = new BuyForm();
            buyform.Show();
            this.Hide();
        }
    }
}
