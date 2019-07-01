﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWM.Data.Domain.Admin
{
    public abstract class AuditableEntity
    {
        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }

    }
}
