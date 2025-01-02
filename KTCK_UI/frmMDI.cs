using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KTCK_UI.Reporting;

namespace KTCK_UI
{
    public partial class frmMDI : Form
    {
        public frmMDI()
        {
            InitializeComponent();
        }

        private void manageStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudent frmStudent = new frmStudent();
            frmStudent.MdiParent = this;
            frmStudent.Show();
        }

        private void manageCourseHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCourse frmCourse = new frmCourse();
            frmCourse.MdiParent = this;
            frmCourse.Show();
            frmCourse.UpdateCourse = new Action<bool>(OnUpdateCourse);
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            frmRegister.MdiParent = this;
            frmRegister.Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.MdiParent = this;
            frmLogin.Show();
            frmLogin.LoginResult = new Action<bool>(OnLoginResult);
        }
        private void OnLoginResult(bool result)
        {
            try
            {
                if (result)
                {
                    funcToolStripMenuItem.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmMDI_Load(object sender, EventArgs e)
        {
            funcToolStripMenuItem.Enabled = false;
        }

        private void reportStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportStudent frmReportStudent = new frmReportStudent();
            frmReportStudent.MdiParent = this;
            frmReportStudent.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void OnUpdateCourse(bool result)
        {
            try
            {
                if (result)
                {
                    foreach (Form frm in this.MdiChildren)
                    {
                        if (frm is frmStudent)
                        {
                            frmStudent frmStudent = (frmStudent)frm;
                            frmStudent.LoadCourse();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
