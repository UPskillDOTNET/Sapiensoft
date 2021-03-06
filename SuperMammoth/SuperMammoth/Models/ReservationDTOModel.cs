﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SuperMammoth.Models
{
    public class ReservationDTOModel
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime DateCreated { get; set; }
        public double Value { get; set; }
        public int SlotId { get; set; }
        public string Locator { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ParkName { get; set; }
        public string UserId { get; set; }
        public int ExternalId { get; set; }

    }
}
