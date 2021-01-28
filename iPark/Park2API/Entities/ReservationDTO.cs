﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Park2API.Entities
{
    public class ReservationDTO
    {
        public int SlotId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Value { get; set; }
    }
}
