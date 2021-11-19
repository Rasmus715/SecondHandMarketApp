using System;
using System.Collections.Generic;

namespace SecondHandMarketApp.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberViewsCount { get; set; }
        public int Price { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Condition Condition { get; set; }
        public  Guid ConditionId { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }

        public List<Image> Images { get; set; } = new();
    }
}
