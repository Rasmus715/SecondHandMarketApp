using System.Collections.Generic;
using SecondHandMarketApp.Models;

namespace SecondHandMarketApp.ViewModels.Item
{
    public class DetailsItemViewModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Description { get; set; }
        public string Category { get; set; }
        public string Condition { get; set; }
        public string SellerPhoneNumber { get; set; }
        public List<Image> Images { get; set; } = new();
    }
}
