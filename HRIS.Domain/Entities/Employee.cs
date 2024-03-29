﻿using HRIS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Domain.Entities
{
    [Table("t_Employees", Schema = "dbo")]

    public class Employee : SoftDeletableEntity
    {
        [Column("BatchNo")]
        public int BatchNo { get; set; }

        [Column("SerialID")]
        public int SerialID { get; set; }

        [Key]
        [Column("EmpID", TypeName = "nvarchar(12)")]
        public string EmpID { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("MiddleName")]
        public string MiddleName { get; set; }

        public virtual Department Department { get; set; }

        [Column("DepartmentSectionCode", TypeName = "nvarchar(5)")]
        public string DepartmentSectionCode { get; set; }

        public virtual CivilStatus CivilStatus { get; set; }

    }
}
