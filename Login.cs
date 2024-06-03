using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transaksi
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            {
                string enteredUsername = txUser.Text;
                string enteredPassword = txPass.Text;

                // Check if the entered username and password are correct
                if (enteredUsername == "admin" && enteredPassword == "12345")
                {
                    //MessageBox.Show("Anda berhasil Login");
                    
                    // If correct, show the main form or perform any other action
                    Form1 form1 = new Form1();
                    form1.ShowDialog();

                    // Optionally, close the current login form
                    this.Close();
                }
                else
                {
                    // If incorrect, show an error message
                    MessageBox.Show("Username atau password salah");
                }
            }
            /*Form1 form1 = new Form1();
            form1.ShowDialog();*/
        }

        private bool isFirstTime = true;
        private void chBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (isFirstTime)
            {
                isFirstTime = false;
            }
            else
            {
                if (chBoxShowPass.Checked)
                {
                    txPass.UseSystemPasswordChar = false;
                }
                else
                {
                    txPass.UseSystemPasswordChar = true;
                }
            }
            /*if(chBoxShowPass.Checked)
            {
                txPass.Text = txPass.Text;
                txPass.Visible = true;
                txPass.Visible = false;
            
            }else
            {
                txPass.Visible=false;
                txPass.Visible=true;
            }*/
        }

        private void txUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}