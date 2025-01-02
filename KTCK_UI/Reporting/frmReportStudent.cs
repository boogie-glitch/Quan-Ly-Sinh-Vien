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
using KTCK_DAL.DTO;
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
            List<StudentDTO> studentDTOs = studentBUS.GetListByCourse(courseID);
            ReportParameter[] rP = new ReportParameter[2];
            rP[0] = new ReportParameter("Ngay", DateTime.Now.ToString("dd/MM/yyyy"));
            var course = courseBUS.GetCours(courseID);
            string courseName = course != null ? course.CourseName : " ";
            rP[1] = new ReportParameter("TenKhoaHoc", courseName);
            this.reportViewer1.LocalReport.SetParameters(rP);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dataStudent", studentDTOs));
            this.reportViewer1.RefreshReport();
        }
    }
}
