using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KitchenDB_EFCore
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Amount { get; set; }
        public int? Price { get; set; }
        public string? Note { get; set; }

        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }

    }



}
