using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SecondHandMarketApp.Models;

namespace SecondHandMarketApp.ViewModels.Item
{
    public class CreateItemViewModel
    {
        [DisplayName("Название")]
        [Required(ErrorMessage = "Название не заполнено")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        [Required(ErrorMessage = "Описание не заполнено")]
        [MinLength(50, ErrorMessage = "Описание должно составлять не менее 50 символов")]
        public string Description { get; set; }
        public int NumberViewsCount { get; set; }

        [DisplayName("Цена")]
        [Required(ErrorMessage = "Цена не заполнена")]
        public int Price { get; set; }


        [DisplayName("Категория")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        
       
        [DisplayName("Состояние")]
        public Guid ConditionId { get; set; }
        public Condition Condition { get; set; }

        [DisplayName("Изображение")]
        public IFormFile ImageFile { get; set; }
    }
}
