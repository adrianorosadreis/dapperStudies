using BlogBalta.Screens.TagScreens;
using Microsoft.Data.SqlClient;

namespace BlogBalta;
class Program
{
    private const string CONNECTION_STRING = @"Server=localhost;Database=Blog;Integrated Security=True;TrustServerCertificate=True;";
    static void Main(string[] args)
    {
        Database.Connection = new SqlConnection(CONNECTION_STRING);
        
        Database.Connection.Open();        
        Load();
        Console.ReadKey();
        Database.Connection.Close();
    }

    private static void Load()
        {
            Console.Clear();
            Console.WriteLine("Online journal");
            Console.WriteLine("-----------------");
            Console.WriteLine("What do you wanna do?");
            Console.WriteLine();
            Console.WriteLine("1 - Users");
            Console.WriteLine("2 - Profiles");
            Console.WriteLine("3 - Categories");
            Console.WriteLine("4 - Tags");
            Console.WriteLine("5 - Link profile/user");
            Console.WriteLine("6 - Link post/tag");
            Console.WriteLine("7 - Reports");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 4:
                    MenuTagScreen.Load();
                    break;
                default: Load(); break;
            }
        }
}
