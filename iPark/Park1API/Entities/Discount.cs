﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Park1API.Entities
{

    public class Discount
    {
        [Key]
        public DayOfWeek TimeDivision { get; set; }

        [Column(TypeName = "decimal(16,4)")]
        public decimal Rate { get; set; }

    }
}
