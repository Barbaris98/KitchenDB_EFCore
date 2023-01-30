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
        public int? AmountInGramm { get; set; }// gramm
        public int? AmountInPieces { get; set; }// в штуках
        public string? Note { get; set; }

        public List<Recipe> Recipes { get; set; } = new();

    }



}
