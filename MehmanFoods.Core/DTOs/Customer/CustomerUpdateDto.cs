﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.DTOs.Customer
{
    public class CustomerUpdateDto
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime RegisteredAt { get; set; }
        public bool IsActive { get; set; }
        public string PreferredContactMethod { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public string Notes { get; set; }
    }
}
