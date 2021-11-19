using System;
using System.Collections.Generic;

namespace SecondHandMarketApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public List<Item> Items { get; set; } = new();
    }
}