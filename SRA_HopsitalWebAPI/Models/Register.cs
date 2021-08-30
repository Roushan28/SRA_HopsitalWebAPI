using System;
using System.Collections.Generic;

namespace SRA_HopsitalWebAPI.Models
{
    public class Register
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Roushan";
        public string IdentityNo { get; set; } = "BODPR56";
        public int NoofDependent { get; set; } = 2;
        public DateTime AvailableDate { get; set; } = DateTime.Now;
        public User User { get; set; }
        public int UserId { get; set; }
      
    }
}