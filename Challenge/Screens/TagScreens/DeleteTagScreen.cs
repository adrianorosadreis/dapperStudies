using BlogBalta.Models;
using BlogBalta.Repositories;

namespace BlogBalta.Screens.TagScreens
{
    public static class DeleteTagScreen
    {
                public static void Load()
        {        
            Console.Clear();
            Console.WriteLine("Delete tag");
            Console.WriteLine("---------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();
            
            Delete(new Tag
            {
                Id = Convert.ToInt32(id)
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void Delete(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(tag);
                Console.WriteLine("Tag deleted");
            }   
            catch(Exception ex)
            {
                Console.WriteLine("Unable to delete tag");
            }         
        }
    }
}