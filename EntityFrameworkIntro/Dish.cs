using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EntityFrameworkIntro
{
    class Dish
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Notes { get; set; }

        public int? RatingStar { get; set; }

        public int MyProperty { get; set; }

        public List<DishIngredient> DishIngredients { get; set; } = new();
    }

}
