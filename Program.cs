using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace KitchenDB_EFCore
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());


            using (ApplicationContext db = new ApplicationContext())
            {
                // пересоздадим базу данных
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                /*
                // создание и добавление моделей
                Company microsoft = new Company { Name = "Microsoft" };
                Company google = new Company { Name = "Google" };
                db.Companies.AddRange(microsoft, google);

                User tom = new User { Name = "Tom", Company = microsoft };
                User bob = new User { Name = "Bob", Company = microsoft };
                User alice = new User { Name = "Alice", Company = google };
                db.Users.AddRange(tom, bob, alice);
                db.SaveChanges();
                */

                Product grechka = new Product
                {
                    Name = "Гречка",
                    AmountInGramm = 2000,
                    Note = "Гречка Минстраль",
                    //Recipes = { r1, r2 }
                };
                Product svinina = new Product
                {
                    Name = "Свинина",
                    AmountInGramm = 4000,
                    Note = "Нарезанная кусочками замороженная"
                };
                Product luk = new Product
                {
                    Name = "Лук",
                    AmountInPieces = 20
                };
                Product morkov = new Product
                {
                    Name = "Морковь",
                    AmountInPieces = 20
                };
                Product tomatPasta = new Product
                {
                    Name = "Паста томатная",
                    AmountInPieces = 20,
                    Note = "100 гр в банке"
                };







                db.Products.AddRange(grechka);


                Recipe r1 = new Recipe
                {
                    Name = "Гречка по купечески со свининой на сковороде",
                    Сookingtime = "40 минут",
                    TypeRecipeTimesOfDay = "Второе",
                    TotalEnergyValue = 156,
                    ProteinsEnergyValue = 8,
                    СarbohydratesEnergyValue = 9,
                    FatsEnergyValue = 12,
                    Products = {grechka,  }
                };
                Recipe r2 = new Recipe
                {
                    Name = "Гречка с сосисками",
                    Сookingtime = "30 минут",
                    TypeRecipeTimesOfDay = "Второе",
                    TotalEnergyValue = 175,
                    ProteinsEnergyValue = 6,
                    СarbohydratesEnergyValue = 11,
                    FatsEnergyValue = 15
                };









                db.SaveChanges();
            }



        }


    }
}