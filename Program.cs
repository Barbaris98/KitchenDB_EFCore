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
                    Name = "������",
                    AmountInGramm = 2000,
                    Note = "������ ���������",
                    //Recipes = { r1, r2 }
                };
                Product svinina = new Product
                {
                    Name = "�������",
                    AmountInGramm = 4000,
                    Note = "���������� ��������� ������������"
                };
                Product luk = new Product
                {
                    Name = "���",
                    AmountInPieces = 20
                };
                Product morkov = new Product
                {
                    Name = "�������",
                    AmountInPieces = 20
                };
                Product tomatPasta = new Product
                {
                    Name = "����� ��������",
                    AmountInPieces = 2,
                    Note = "100 �� � �����"
                };
                Product sosiski = new Product
                {
                    Name = "�������",
                    AmountInPieces = 10
                };


                db.Products.AddRange(grechka, svinina, luk, morkov, tomatPasta, sosiski);

                Recipe r1 = new Recipe
                {
                    Name = "������ �� ��������� �� �������� �� ���������",
                    �ookingtime = "40 �����",
                    TypeRecipeTimesOfDay = "������",
                    TotalEnergyValue = 156,
                    ProteinsEnergyValue = 8,
                    �arbohydratesEnergyValue = 9,
                    FatsEnergyValue = 12,
                    Products = { grechka, svinina, luk, morkov, tomatPasta }
                };
                Recipe r2 = new Recipe
                {
                    Name = "������ � ���������",
                    �ookingtime = "30 �����",
                    TypeRecipeTimesOfDay = "������",
                    TotalEnergyValue = 175,
                    ProteinsEnergyValue = 6,
                    �arbohydratesEnergyValue = 11,
                    FatsEnergyValue = 15,
                    Products = { grechka, sosiski }
                };

                db.Recipes.AddRange(r1, r2);

                db.SaveChanges();
            }



        }


    }
}