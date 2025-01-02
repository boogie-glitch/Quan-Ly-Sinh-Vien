using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using KTCK_DAL.EntitiesDB;
using KTCK_BUS;

namespace KTCK_UI.Reporting
{
    public partial class frmReportStudent : Form
    {
        CourseBUS courseBUS = new CourseBUS();
        StudentBUS studentBUS = new StudentBUS();
        public frmReportStudent()
        {
            InitializeComponent();
        }

        private void frmReportStudent_Load(object sender, EventArgs e)
        {
            cmbCourse.DataSource = courseBUS.GetList();
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseID";
            cmbCourse.SelectedIndex = 0;
            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;

            this.reportViewer1.RefreshReport();
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string courseID = cmbCourse.SelectedValue.ToString();
            List<Student> students = studentBUS.GetListByCourse(courseID);
            var studentList = from student in students
                              select new
                              {
                                  StudentID = student.StudentID,
                                  StudentName = student.StudentName,
                                  DateOfBirth = student.DateOfBirth,
                                  CourseName = courseBUS.GetCours(student.CourseID).CourseName
                              };
            ReportParameter[] rP = new ReportParameter[1];
            rP[0] = new ReportParameter("Ngay", DateTime.Now.ToString("dd/MM/yyyy"));

            this.reportViewer1.LocalReport.SetParameters(rP);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dataStudent", studentList));
            this.reportViewer1.RefreshReport();
        }
    }
}
