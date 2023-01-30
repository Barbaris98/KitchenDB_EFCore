using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenDB_EFCore
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Сookingtime { get; set; }

        public string TypeRecipeTimesOfDay { get; set; } = null!; //первое втрое или десерт или другое

        public int? TotalEnergyValue { get; set; } // на 100 грамм type of delicious food
        public int? ProteinsEnergyValue { get; set; }
        public int? СarbohydratesEnergyValue { get; set; }
        public int? FatsEnergyValue { get; set; }
        //public string? TextRecipe { get; set; }
        
        public List<Product> Products { get; set; } = new();

    }
    

}
