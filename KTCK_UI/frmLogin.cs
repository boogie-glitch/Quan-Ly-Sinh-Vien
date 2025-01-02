using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KTCK_DAL.EntitiesDB;
using KTCK_BUS;

namespace KTCK_UI
{
    public partial class frmLogin : Form
    {
        UserBUS userBUS = new UserBUS();
        public Action<bool> LoginResult;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!CheckValidated())
            {
                return;
            }
            string hashedPassword = userBUS.GetPassword(txtUsername.Text);
            if (PasswordHash.ValidatePassword(txtPassword.Text, hashedPassword))
            {
                MessageBox.Show("Login successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoginResult?.Invoke(true);
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginResult?.Invoke(false);
            }
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
            if (userBUS.GetUser(txtUsername.Text) == null)
            {
                MessageBox.Show("Username does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return false;
            }
            return true;
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
