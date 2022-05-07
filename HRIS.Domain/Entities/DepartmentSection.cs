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
    [Table("t_DepartmentalSection", Schema = "dbo")]

    public class DepartmentSection : SoftDeletableEntity
    {
        [Key]
        [Column("DepartmentCode", TypeName = "nvarchar(5)")]
        public string DepartmentCode { get; set; }

        [Key]
        [Column("Code", TypeName = "nvarchar(5)")]
        public string Code { get; set; }

        [Column("Description")]
        public string Description { get; set; }
    }
}
