using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using static System.Console;

namespace EntityFrameworkIntro
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var factory = new FoodContextFactory();
            using (var context =  factory.CreateDbContext(args))
            {
                var porridgeOats = await context.Dishes.FirstOrDefaultAsync(d => d.Title == "Porridge");
                if(porridgeOats is null)
                {
                    WriteLine("No porridge in the DB");
                }
                porridgeOats = new Dish { Title = "Porridge", Notes = "Breakfast", RatingStar = 4 };
                context.Dishes.Add(porridgeOats);
                await context.SaveChangesAsync();
                WriteLine($"\tAdded ({JsonSerializer.Serialize(porridgeOats)})");

                if(porridgeOats.RatingStar == 4)
                {
                    //Update rating 
                    porridgeOats.RatingStar = 5;
                    //porridgeOats is in memory we do not want to call it from the DB again
                    await context.SaveChangesAsync();
                }

                //check if we have ingredients in the DB for porridgeOats
                if (!await context.DishIngredients.AnyAsync(i => i.Dish == porridgeOats))
                {
                    WriteLine("Adding Ingerdients");

                    //add a single dishingredient
                    await context.AddAsync(new DishIngredient 
                    { 
                        Dish = porridgeOats,
                        Description = "Oat",
                        Amount = 50m,
                        UnitOfMeasure = "gr"                    
                    });
                    //add multiple dishingredients
                    var ingredients = new DishIngredient[]
                    {
                            new() { Dish = porridgeOats, Description = "Oat Milk", Amount = 250m, UnitOfMeasure = "gr" },
                            new() { Dish = porridgeOats, Description = "Cashew Nuts", Amount = 1m, UnitOfMeasure = "hand" },
                            new() { Dish = porridgeOats, Description = "Poppyseed", Amount = 1m, UnitOfMeasure = "spoon" },
                            new() { Dish = porridgeOats, Description = "Pumpkin Seed Protein Powder", Amount = 1m, UnitOfMeasure = "spoon" },
                            new() { Dish = porridgeOats, Description = "Seasonal Fruits", Amount = 2m, UnitOfMeasure = "small apples" }
                    };

                    await context.AddRangeAsync(ingredients);
                    await context.SaveChangesAsync();

                }

                //delete dish with its ingredients
                foreach (var ingredient in await context.DishIngredients
                    .Where(x => x.DishId == porridgeOats.Id)
                    .ToArrayAsync())
                {
                    context.Remove(ingredient);
                }
                context.Remove(porridgeOats);
                await context.SaveChangesAsync();
            }
        }
    }

}
