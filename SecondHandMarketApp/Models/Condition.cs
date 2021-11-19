using System;
using System.Collections.Generic;

namespace SecondHandMarketApp.Models
{
    public class Condition
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Item> Items { get; set; } = new();
    }
}
