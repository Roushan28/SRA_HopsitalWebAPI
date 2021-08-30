using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SRA_HopsitalWebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Register> Registers { get; set; }
        public string Role { get; set; }
    }
}