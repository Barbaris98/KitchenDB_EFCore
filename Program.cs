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
                
                Product grechka = new Product
                {
                    NameProduct = "Гречка",
                    AmountInGramm = 2000,
                    Note = "Гречка Минстраль",
                    //Recipes = { r1, r2 }
                };
                Product svinina = new Product
                {
                    NameProduct = "Свинина",
                    AmountInGramm = 4000,
                    Note = "Нарезанная кусочками замороженная"
                };
                Product luk = new Product
                {
                    NameProduct = "Лук",
                    AmountInPieces = 20
                };
                Product morkov = new Product
                {
                    NameProduct = "Морковь",
                    AmountInPieces = 20
                };
                Product tomatPasta = new Product
                {
                    NameProduct = "Паста томатная",
                    AmountInPieces = 2,
                    Note = "100 гр в банке"
                };
                Product sosiski = new Product
                {
                    NameProduct = "Сосиски",
                    AmountInPieces = 10
                };


                db.Products.AddRange(grechka, svinina, luk, morkov, tomatPasta, sosiski);

                Recipe r1 = new Recipe
                {
                    NameRecipe = "Гречка по купечески со свининой на сковороде",
                    Сookingtime = "40 минут",
                    TypeRecipeTimesOfDay = "Второе",
                    TotalEnergyValue = 156,
                    ProteinsEnergyValue = 8,
                    СarbohydratesEnergyValue = 9,
                    FatsEnergyValue = 12,
                    Products = { grechka, svinina, luk, morkov, tomatPasta }
                };
                Recipe r2 = new Recipe
                {
                    NameRecipe = "Гречка с сосисками",
                    Сookingtime = "30 минут",
                    TypeRecipeTimesOfDay = "Второе",
                    TotalEnergyValue = 175,
                    ProteinsEnergyValue = 6,
                    СarbohydratesEnergyValue = 11,
                    FatsEnergyValue = 15,
                    Products = { grechka, sosiski }
                };

                db.Recipes.AddRange(r1, r2);

                db.SaveChanges();
            }



        }


    }
}