using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
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
                // ������������ ���� ������
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                /*
                // �������� � ���������� �������
                Company microsoft = new Company { Name = "Microsoft" };
                Company google = new Company { Name = "Google" };
                db.Companies.AddRange(microsoft, google);

                User tom = new User { Name = "Tom", Company = microsoft };
                User bob = new User { Name = "Bob", Company = microsoft };
                User alice = new User { Name = "Alice", Company = google };
                db.Users.AddRange(tom, bob, alice);
                db.SaveChanges();
                */

                Product p1 = new Product { Name = "������ �� ��������� �� �������� �� ���������", Company = microsoft };


            }



        }


    }
}