namespace KTCK_DAL.EntitiesDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        [StringLength(10)]
        public string StudentID { get; set; }

        [StringLength(50)]
        public string StudentName { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(10)]
        public string CourseID { get; set; }

        public virtual Cours Cours { get; set; }
    }
}
