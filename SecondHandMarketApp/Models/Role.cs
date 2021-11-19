using System;
using System.Collections.Generic;

namespace SecondHandMarketApp.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; } = new();
    }
}