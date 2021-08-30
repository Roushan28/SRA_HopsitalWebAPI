using System;
using System.Collections.Generic;

using SRA_HopsitalWebAPI.Models;

namespace SRA_HopsitalWebAPI.Dtos.Register
{
    public class GetRegisterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Roushan";
        public string IdentityNo { get; set; } = "BODPR56";
        public int NoofDependent { get; set; } = 2;
        public DateTime AvailableDate { get; set; } = DateTime.Now;
     

    }
}