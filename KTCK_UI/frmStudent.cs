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
    public partial class frmStudent : Form
    {
        StudentBUS studentBUS = new StudentBUS();
        CourseBUS courseBUS = new CourseBUS();
        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            LoadCourse();

            DisplayData();
        }

        public void LoadCourse()
        {
            cmbCourse.DataSource = courseBUS.GetList();
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseID";
            cmbCourse.SelectedIndex = 0;
            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void DisplayData()
        {
            dgvStudents.Rows.Clear();
            foreach (Student student in studentBUS.GetList())
            {
                dgvStudents.Rows.Add(student.StudentID, student.StudentName, student.DateOfBirth, courseBUS.GetCours(student.CourseID).CourseName);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!CheckValidated())
            {
                return;
            }
            Student student = studentBUS.GetStudent(txtStudentID.Text) ?? new Student();
            student.StudentID = txtStudentID.Text;
            student.StudentName = txtFullName.Text;
            student.DateOfBirth = DateTime.Parse(txtDateOfBirth.Text);
            student.CourseID = cmbCourse.SelectedValue.ToString();

            if (studentBUS.GetStudent(txtStudentID.Text) == null)
            {
                studentBUS.AddStudent(student);
                MessageBox.Show("Add student successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                studentBUS.UpdateStudent(student);
                MessageBox.Show("Update student successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            refresh();
            DisplayData();
        }

        private bool CheckValidated()
        {
            if (txtStudentID.Text == "" || txtFullName.Text == "" || txtDateOfBirth.Text == "")
            {
                MessageBox.Show("Please fill in all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtFullName.Text.Length < 5)
            {
                MessageBox.Show("Full name must be at least 5 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            foreach (char c in txtFullName.Text)
            {
                if (char.IsDigit(c) || char.IsSymbol(c))
                {
                    MessageBox.Show("Full name must not contain numbers or special characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            // Kiểm tra xem ngày sinh có đúng định dạng không. Nếu chỉ nhập ngày tháng năm thì vẫn đúng định dạng

            if (!DateTime.TryParse(txtDateOfBirth.Text, out DateTime date))
            {
                MessageBox.Show("Date of birth is not in the correct format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (DateTime.Now.Year - date.Year < 18)
            {
                MessageBox.Show("The student must be at least 18 years old!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void refresh()
        {
            txtStudentID.Clear();
            txtFullName.Clear();
            txtDateOfBirth.Clear();
            cmbCourse.SelectedIndex = 0;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text == "")
            {
                MessageBox.Show("Please select a student to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Student student = studentBUS.GetStudent(txtStudentID.Text);
            if (student == null)
            {
                MessageBox.Show("Student not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this student?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            studentBUS.DeleteStudent(txtStudentID.Text);
            MessageBox.Show("Delete student successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refresh();
            DisplayData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
            txtStudentID.Text = row.Cells[0].Value.ToString();
            txtFullName.Text = row.Cells[1].Value.ToString();
            txtDateOfBirth.Text = row.Cells[2].Value.ToString();
            cmbCourse.Text = row.Cells[3].Value.ToString();
        }
    }
}
