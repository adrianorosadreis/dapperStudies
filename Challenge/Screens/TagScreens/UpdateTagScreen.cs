using BlogBalta.Models;
using BlogBalta.Repositories;

namespace BlogBalta.Screens.TagScreens
{
    public static class UpdateTagScreen
    {
        public static void Load()
        {        
            Console.Clear();
            Console.WriteLine("Update tag");
            Console.WriteLine("---------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();

            Console.Write("Name: ");
            var name = Console.ReadLine();
            
            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            
            Update(new Tag
            {
                Id = Convert.ToInt32(id),
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void Update(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Update(tag);
                Console.WriteLine("Tag updated");
            }   
            catch(Exception ex)
            {
                Console.WriteLine("Unable to update tag");
            }         
        }
    }
}