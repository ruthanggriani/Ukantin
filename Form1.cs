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
using MySql.Data;
//using MySql.Data.MySqlClient;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Status;

namespace Transaksi
{
    public partial class Form1 : Form
    {
        DataTable dbdataset = new DataTable();
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;

        public Form1()
        {
            alamat = "server=localhost; database=db_unklabkantin; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = string.Format("select * from tblpembayaran");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[0].HeaderText = "ID Pengguna";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[1].HeaderText = "Nama pembeli";
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[2].HeaderText = "Nama Makanan";
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[3].HeaderText = "Harga";
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[4].HeaderText = "Jumlah";
                dataGridView1.Columns[5].Width = 120;
                dataGridView1.Columns[5].HeaderText = "Total Bayar";
                dataGridView1.Columns[6].Width = 120;
                dataGridView1.Columns[6].HeaderText = "Bayar";
                dataGridView1.Columns[7].Width = 120;
                dataGridView1.Columns[7].HeaderText = "Kembalian";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Metode metode = new Metode();   
            metode.Show();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            //connection 

            try
            {
                // Connection string
                string myConnection = "datasource=localhost;port=3306;username=root;password=";

                // Query with parameters
                string Query = "INSERT INTO db_unklabkantin.tblpembayaran (namapembeli, namamakanan, harga, jumlah, totalbayar, bayar, kembalian) VALUES (@namapembeli, @namamakanan, @harga, @jumlah, @totalbayar, @bayar, @kembalian)";

                // MySqlConnection and MySqlCommand with parameters
                using (MySqlConnection myConn = new MySqlConnection(myConnection))
                using (MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn))
                {
                    // Add parameters
                    cmdDatabase.Parameters.AddWithValue("@namapembeli", namapembeli.Text);
                    cmdDatabase.Parameters.AddWithValue("@namamakanan", comboItem.Text);
                    cmdDatabase.Parameters.AddWithValue("@harga", textHarga.Text);
                    cmdDatabase.Parameters.AddWithValue("@jumlah", textJumlah.Text);
                    cmdDatabase.Parameters.AddWithValue("@totalbayar", textPrice.Text);
                    cmdDatabase.Parameters.AddWithValue("@bayar", textPay.Text);
                    cmdDatabase.Parameters.AddWithValue("@kembalian", textKembalian.Text);

                    // Open connection and execute the query
                    myConn.Open();
                    cmdDatabase.ExecuteNonQuery();
                    myConn.Close();

                    MessageBox.Show("Your Data Insert Transaksi Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            /*string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = "INSERT INTO db_unklabkantin.tblpembayaran (namapembeli, namamakanan, harga, jumlah, totalbayar, bayar, kembalian) VALUES ('" + this.namapembeli.Text + "','" + comboJenis.Text + "','" + comboItem.Text + "','" + textHarga.Text + "','" + this.textJumlah.Text + "','" + textPrice.Text + "','" + textPay.Text + "','" + textKembalian + "')";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("Your Data Insert Transaksi Successfuly");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //si
        }

        private void namapembeli_TextChanged(object sender, EventArgs e)
        {
            //si
        }

       /* string metodepembayaran;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            metodepembayaran = "Cash";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            metodepembayaran = "Qris";
        }
       */
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //isi
        }

        private void label8_Click(object sender, EventArgs e)
        {
            //isi
        }

        private void comboJenis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboJenis.Text == "Foods")
            {
                comboItem.Items.Clear();
                comboItem.Items.Add("Menu");
                comboItem.Items.Add("Ayam Geprek + Nasi");
                comboItem.Items.Add("Indomie Goreng");
                comboItem.Items.Add("Indomie Kuah");
                comboItem.Items.Add("Nasi Tempe Penyet");
                comboItem.Items.Add("Nasi Campur Cakalang");
                comboItem.Items.Add("Nasi Campur Ayam");
                comboItem.Items.Add("Nasi Goreng Cakalang");
                comboItem.Items.Add("Nasi Goreng Ayam");
                comboItem.Items.Add("Midal");
                comboItem.Items.Add("Tinutuan");
                comboItem.Items.Add("Mie Cakalang");
                comboItem.SelectedIndex = 0;
            }
            if (comboJenis.Text == "Drinks")
            {
                comboItem.Items.Clear();
                comboItem.Items.Add("Menu");
                comboItem.Items.Add("Nutrisari");
                comboItem.Items.Add("Chocolatos");
                comboItem.Items.Add("Bengbeng");
                comboItem.Items.Add("Milo");
                comboItem.Items.Add("Aqua");
                comboItem.SelectedIndex = 0;
            }
            if (comboJenis.Text == "Desserts")
            {
                comboItem.Items.Clear();
                comboItem.Items.Add("Menu");
                comboItem.Items.Add("Es Kepal Milo");
                comboItem.Items.Add("Es Palubutung");
                comboItem.Items.Add("Es Kacang Susu");
                comboItem.Items.Add("Pisang Coklat Keju");
                comboItem.Items.Add("Pisang Goreng Goroho");
                comboItem.Items.Add("Pisang Goreng Sepatu");
                comboItem.SelectedIndex = 0;
            }
        }

        private void comboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboJenis.Text == "Foods")
            {
                if (comboItem.Text == "Menu")
                {
                    textHarga.Text = "0";
                }
                else if (comboItem.Text == "Indomie Goreng")
                {
                    textHarga.Text = "10000";
                }
                else if (comboItem.Text == "Ayam Geprek + Nasi")
                {
                    textHarga.Text = "25000";
                }
                else if (comboItem.Text == "Indomie Kuah")
                {
                    textHarga.Text = "10000";
                }
                else if (comboItem.Text == "Nasi Tempe Penyet")
                {
                    textHarga.Text = "15000";
                }
                else if (comboItem.Text == "Nasi Campur Cakalang")
                {
                    textHarga.Text = "15000";
                }
                else if (comboItem.Text == "Nasi Campuer Ayam")
                {
                    textHarga.Text = "20000";
                }
                else if (comboItem.Text == "Nasi Goreng Cakalang")
                {
                    textHarga.Text = "20000";
                }
                else if (comboItem.Text == "Nasi Goreng Ayam")
                {
                    textHarga.Text = "20000";
                }
                else if (comboItem.Text == "Midal")
                {
                    textHarga.Text = "15000";
                }
                else if (comboItem.Text == "Tinutuan")
                {
                    textHarga.Text = "15000";
                }
                else if (comboItem.Text == "Mie Cakalang")
                {
                    textHarga.Text = "15000";
                }
                // Handle other food items if needed
            }
            else if (comboJenis.Text == "Drinks")
            {
                if (comboItem.Text == "Menu")
                {
                    textHarga.Text = "0";
                }
                else if (comboItem.Text == "Nutrisari")
                {
                    textHarga.Text = "5000";
                }
                else if (comboItem.Text == "Milo")
                {
                    textHarga.Text = "10000";
                }
                else if (comboItem.Text == "Bengbeng")
                {
                    textHarga.Text = "10000";
                }
                else if (comboItem.Text == "Chocolatos")
                {
                    textHarga.Text = "10000";
                }
                else if (comboItem.Text == "Aqua")
                {
                    textHarga.Text = "5000";
                }

                // Handle other drink items if needed
            }
            else if (comboJenis.Text == "Desserts")
            {
                if (comboItem.Text == "Menu")
                {
                    textHarga.Text = "0";
                }
                else if (comboItem.Text == "Es Kepal Milo")
                {
                    textHarga.Text = "15000";
                }
                else if (comboItem.Text == "Es Palubutung")
                {
                    textHarga.Text = "15000";
                }
                else if (comboItem.Text == "Es Kacang Susu")
                {
                    textHarga.Text = "15000";
                }
                else if (comboItem.Text == "Pisang Coklat Keju")
                {
                    textHarga.Text = "15000";
                }
                else if (comboItem.Text == "Pisang Goreng Goroho")
                {
                    textHarga.Text = "10000";
                }
                else if (comboItem.Text == "Pisang Goreng Sepatu")
                {
                    textHarga.Text = "10000";
                }
                // Handle other drink items if needed
            }
        }

        private void textJumlah_TextChanged(object sender, EventArgs e)
        {
            // Check if the quantity is a valid integer
            if (int.TryParse(textJumlah.Text, out int quantity))
            {
                // Parse the price from the TextBox (assuming you have a TextBox named textHarga)
                if (int.TryParse(textHarga.Text, out int price))
                {
                    // Calculate the total price based on the selected item, quantity, and price
                    int totalPrice = price * quantity;

                    // Display the total price in a TextBox or label (assuming you have a TextBox named textPrice)
                    textPrice.Text = totalPrice.ToString();
                }
                else
                {
                    MessageBox.Show("Invalid price format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textPay_TextChanged(object sender, EventArgs e)
        {
            // Check if the payment amount is a valid integer
            if (int.TryParse(textPay.Text, out int paymentAmount))
            {
                // Parse the total price from the TextBox (assuming you have a TextBox named textPrice)
                if (int.TryParse(textPrice.Text, out int totalPrice))
                {
                    // Calculate the change amount
                    int changeAmount = paymentAmount - totalPrice;

                    // Display the change amount in a TextBox or label (assuming you have a TextBox named textKembalian)
                    textKembalian.Text = changeAmount.ToString();
                }
                else
                {
                    MessageBox.Show("Invalid total price format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid payment amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textKembalian_TextChanged(object sender, EventArgs e)
        {
            // Check if the payment amount and total price are valid integers
            if (int.TryParse(textPay.Text, out int paymentAmount) && int.TryParse(textPrice.Text, out int totalPrice))
            {
                // Calculate the change amount
                int changeAmount = paymentAmount - totalPrice;

                // Display the change amount in the textKembalian TextBox
                textKembalian.Text = changeAmount.ToString();
            }
            else
            {
                // Display an error message if the input is not valid
                textKembalian.Text = "Invalid input";
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                // Assuming you have a DataGridView named dataGridView1
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int rowIndex = dataGridView1.SelectedRows[0].Index;
                    int id_pengguna = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id_pengguna"].Value);

                    query = string.Format("UPDATE `tblpembayaran` SET `namapembeli`= '{0}', `namamakanan`= '{1}', `harga`= '{2}', `jumlah`= '{3}', `totalbayar`= '{4}', `bayar`= '{5}', `kembalian`= '{6}' WHERE `id_pengguna`= {7}",
                        this.namapembeli.Text, comboItem.Text, textHarga.Text, this.textJumlah.Text, textPrice.Text, textPay.Text, textKembalian.Text, id_pengguna);

                    ds.Clear();
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    perintah.ExecuteNonQuery();
                    koneksi.Close();

                    Form1_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Please select a row to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                // Assuming you have a DataGridView named dataGridView1
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int rowIndex = dataGridView1.SelectedRows[0].Index;
                    int id_pengguna = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id_pengguna"].Value);

                    string deleteQuery = $"DELETE FROM `tblpembayaran` WHERE `id_pengguna` = {id_pengguna}";

                    ds.Clear();
                    koneksi.Open();
                    perintah = new MySqlCommand(deleteQuery, koneksi);
                    perintah.ExecuteNonQuery();
                    koneksi.Close();

                    Form1_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // Clear input fields for a new entry
            namapembeli.Text = string.Empty;
            comboJenis.SelectedIndex = -1;  // Reset combo box selection
            comboItem.Items.Clear();        // Clear item options
            textHarga.Text = string.Empty;
            textJumlah.Text = string.Empty;
            textPrice.Text = string.Empty;
            textPay.Text = string.Empty;
            textKembalian.Text = string.Empty;

            // Optionally, you can clear the selection in the DataGridView
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //isi
        }
    }
}
