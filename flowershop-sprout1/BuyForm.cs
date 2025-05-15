using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DrawingImage = System.Drawing.Image;
using PdfImage = iTextSharp.text.Image;





namespace flowershop_sprout
{
    public partial class BuyForm : Form
    {
        private string connectionString = "server=127.0.0.1; database=flower_shop; uid=root; pwd=sukhoi57;";
        private MySqlConnection connection;

        public BuyForm()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
        }

        private void BuyForm_Load(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void LoadProductList()
        {
            try
            {
                string query = "SELECT id, plant_name, price, image_path FROM Products WHERE stock_quantity > 0";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmbProducts.DisplayMember = "plant_name";
                cmbProducts.ValueMember = "id";
                cmbProducts.DataSource = dt;

                cmbProducts.SelectedIndexChanged += cmbProducts_SelectedIndexChanged;
                cmbProducts.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem != null)
            {
                DataRowView row = (DataRowView)cmbProducts.SelectedItem;
                txtPrice.Text = row["price"].ToString();

                string imagePath = row["image_path"].ToString();
                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    DrawingImage img = DrawingImage.FromFile(imagePath);
                }
                else
                {
                    pictureBoxFlower.Image = null;
                }
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedValue == null || string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Please select a product and enter quantity.");
                return;
            }

            int productId = Convert.ToInt32(cmbProducts.SelectedValue);
            int quantity = Convert.ToInt32(txtQuantity.Text);
            decimal price = Convert.ToDecimal(txtPrice.Text);
            decimal totalPrice = quantity * price;

            try
            {
                string stockCheckQuery = "SELECT stock_quantity FROM Products WHERE id = @id";
                MySqlCommand checkCmd = new MySqlCommand(stockCheckQuery, connection);
                checkCmd.Parameters.AddWithValue("@id", productId);

                connection.Open();
                int stock = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (quantity > stock)
                {
                    MessageBox.Show("Not enough stock!");
                    return;
                }

                // 1. Deduct stock
                string updateQuery = "UPDATE Products SET stock_quantity = stock_quantity - @qty WHERE id = @id";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection);
                updateCmd.Parameters.AddWithValue("@qty", quantity);
                updateCmd.Parameters.AddWithValue("@id", productId);
                updateCmd.ExecuteNonQuery();

                // 2. Insert into transactions
                string insertTransactionQuery = "INSERT INTO transactions (product_id, quantity, total_price) VALUES (@pid, @qty, @total)";
                MySqlCommand insertCmd = new MySqlCommand(insertTransactionQuery, connection);
                insertCmd.Parameters.AddWithValue("@pid", productId);
                insertCmd.Parameters.AddWithValue("@qty", quantity);
                insertCmd.Parameters.AddWithValue("@total", totalPrice);
                insertCmd.ExecuteNonQuery();

                MessageBox.Show("Purchase successful!");
                LoadProductList(); // Refresh
                txtQuantity.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Purchase error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            zeShop zashop = new zeShop();
            zashop.Show();
            this.Hide();

        }

        private void GenerateTransactionPDF(string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    // Add title
                    var title = new Paragraph("Transaction Report",
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18f, iTextSharp.text.Font.BOLD));

                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);
                    doc.Add(new Chunk("\n"));

                    // Table
                    PdfPTable table = new PdfPTable(4);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 3f, 1f, 2f, 3f });

                    // Add headers
                    string[] headers = { "Product Name", "Quantity", "Total Price", "Purchase Date" };
                    foreach (var header in headers)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(header, FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD)));
                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);
                    }

                    // Get transaction data
                    string query = @"
                SELECT p.plant_name, t.quantity, t.total_price, t.purchase_date
                FROM transactions t
                JOIN products p ON t.product_id = p.id
                ORDER BY t.purchase_date DESC";

                    using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1; database=flower_shop; uid=root; pwd=sukhoi57;"))
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                table.AddCell(reader["plant_name"].ToString());
                                table.AddCell(reader["quantity"].ToString());
                                table.AddCell(reader["total_price"].ToString());
                                table.AddCell(Convert.ToDateTime(reader["purchase_date"]).ToString("yyyy-MM-dd HH:mm"));
                            }
                        }
                    }

                    doc.Add(table);
                    doc.Close();
                    writer.Close();
                }

                MessageBox.Show("PDF report generated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to generate PDF: " + ex.Message);
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveDialog.FileName = "TransactionReport.pdf";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                GenerateTransactionPDF(saveDialog.FileName);
            }
        }
    }
}
