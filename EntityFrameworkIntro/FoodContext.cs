using Microsoft.EntityFrameworkCore;


namespace EntityFrameworkIntro
{
    class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options) { }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<DishIngredient> DishIngredients { get; set; }
    }

}
