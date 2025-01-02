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

namespace KTCK_UI
{
    public delegate void Action<T>(T obj);
    public partial class frmCourse : Form
    {
        CourseBUS courseBUS = new CourseBUS();
        public Action<bool> UpdateCourse;
        public frmCourse()
        {
            InitializeComponent();
        }

        private void frmCourse_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void DisplayData()
        {
            dgvCourses.Rows.Clear();
            foreach (Cours course in courseBUS.GetList())
            {
                dgvCourses.Rows.Add(course.CourseID, course.CourseName);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!CheckValidated())
            {
                UpdateCourse?.Invoke(false);
                return;
            }
            Cours course = courseBUS.GetCours(txtCourseID.Text) ?? new Cours();
            course.CourseID = txtCourseID.Text;
            course.CourseName = txtCourseName.Text;
            if (courseBUS.GetCours(txtCourseID.Text) == null)
            {
                courseBUS.AddCours(course);
                MessageBox.Show("Add course successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                courseBUS.UpdateCours(course);
                MessageBox.Show("Update course successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateCourse?.Invoke(true);
            refresh();
            DisplayData();
        }
        private bool CheckValidated()
        {
            if (string.IsNullOrEmpty(txtCourseID.Text) || string.IsNullOrEmpty(txtCourseName.Text))
            {
                MessageBox.Show("Please fill in all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtCourseName.Text.Length < 3)
            {
                MessageBox.Show("Course name must be at least 3 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void refresh()
        {
            txtCourseID.Clear();
            txtCourseName.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCourseID.Text))
            {
                MessageBox.Show("Please fill in Course ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateCourse?.Invoke(false);
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you want to delete this course?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                UpdateCourse?.Invoke(false);
                return;
            }
            courseBUS.DeleteCours(txtCourseID.Text);
            MessageBox.Show("Delete course successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateCourse?.Invoke(true);
            refresh();
            DisplayData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) {
                return;
            }
            this.Close();
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgvCourses.Rows[e.RowIndex];
            txtCourseID.Text = row.Cells[0].Value.ToString();
            txtCourseName.Text = row.Cells[1].Value.ToString();
        }
    }
}
