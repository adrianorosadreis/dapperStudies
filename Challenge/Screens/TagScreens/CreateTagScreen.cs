using BlogBalta.Models;
using BlogBalta.Repositories;

namespace BlogBalta.Screens.TagScreens
{
    public static class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("New tag");
            Console.WriteLine("---------------");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            
            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            
            Create(new Tag
            {
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void Create(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Create(tag);
                Console.WriteLine("Tag successfully created");
            }   
            catch(Exception ex)
            {
                Console.WriteLine("Unable to create tag");
            }         
        }
    }
}