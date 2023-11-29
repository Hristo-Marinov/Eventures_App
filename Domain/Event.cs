﻿using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Eventures.App_2._0.Domain
{
    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public string Id { get; set; }
        public string Name { get; set; }
        public string Place {get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int TotalTickets { get; set; }

        [Column(TypeName = "decimal(12,3)")]
        public decimal PricePreTicket { get; set; } 
        public EventuresUser Owner { get; set; }
        public string OwnerId { get; set; } 
    }
}
