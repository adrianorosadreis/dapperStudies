namespace BlogBalta.Screens.TagScreens
{
    public static class MenuTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Tags");
            Console.WriteLine("--------------");
            Console.WriteLine();
            Console.WriteLine("1 - List tags");
            Console.WriteLine("2 - Register tags");
            Console.WriteLine("3 - Update tag");
            Console.WriteLine("4 - Delete tag");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListTagScreen.Load();
                    break;
                case 2:
                    CreateTagScreen.Load();
                    break;
                case 3:
                    UpdateTagScreen.Load();
                    break;
                case 4:
                    DeleteTagScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}