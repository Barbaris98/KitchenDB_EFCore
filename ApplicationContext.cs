using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenDB_EFCore
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Products> Products { get; set; } = null!;
        public DbSet<Recipes> Recipes { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureDeleted();   // удаляем бд со старой схемой
            Database.EnsureCreated();   // создаем бд с новой схемой

            // воспользуемся подобной реализацией Миграции
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Products.db");
        }
    }



}
