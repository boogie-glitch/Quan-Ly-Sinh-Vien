using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KTCK_BUS;
using KTCK_DAL.EntitiesDB;
using BCrypt.Net;

namespace KTCK_UI
{
    public partial class frmRegister : Form
    {
        UserBUS userBUS = new UserBUS();
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!CheckValidated())
            {
                return;
            }
            User user = new User();
            user.Username = txtUsername.Text;
            user.HashedPassword = PasswordHash.HashPassword(txtPassword.Text);
            userBUS.AddUser(user);
            MessageBox.Show("Register successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refresh();
        }

        private bool CheckValidated()
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Please enter username!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return false;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;
            }
            if (txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Please enter confirm password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPassword.Focus();
                return false;
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password and confirm password do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPassword.Focus();
                return false;
            }
            return true;
        }
        private void refresh()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
