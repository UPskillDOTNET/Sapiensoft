﻿using SuperMammoth.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMammoth.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime DateCreated { get; set; }
        public double Value { get; set; }
        public int SlotId { get; set; }
        public string Locator { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string QrCode { get; set; }
        public bool AvailableToRent { get; set; }
        [Range(1, 10000)]
        public double RentValue { get; set; }

        public string UserId { get; set; }
        public int ParkId { get; set; }
        [ForeignKey("ParkId")]
        public Park Park { get; set; }
    }
}
