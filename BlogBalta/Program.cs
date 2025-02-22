using BlogBalta.Models;
using BlogBalta.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace BlogBalta;
class Program
{
    private const string CONNECTION_STRING = @"Server=localhost;Database=Blog;Integrated Security=True;TrustServerCertificate=True;";
    static void Main(string[] args)
    {
        var connection = new SqlConnection(CONNECTION_STRING);
        
        connection.Open();
        ReadUsers(connection);
        ReadRoles(connection);
        ReadTags(connection);
        ReadUsersWithRoles(connection);
        //CreateUser();
        //UpdateUser();
        //DeleteUser();
        connection.Close();
    }

    public static void ReadUsersWithRoles(SqlConnection connection)
    {
        var repository = new UserRepository(connection);
        var items = repository.GetWithRoles();
        
        foreach (var item in items)
        {
            Console.WriteLine(item.Name);
            foreach(var role in item.Roles)
            {
                Console.WriteLine($" - {role.Name}");
            }
        }
            
    }

    public static void ReadUsers(SqlConnection connection)
    {
        var repository = new Repository<User>(connection);
        var users = repository.Get();
        
        foreach (var user in users)
            Console.WriteLine(user.Name);
    }
    public static void ReadRoles(SqlConnection connection)
    {
        var repository = new Repository<Role>(connection);
        var items = repository.Get();
        
        foreach (var item in items)
            Console.WriteLine(item.Name);
    }

    public static void ReadTags(SqlConnection connection)
    {
        var repository = new Repository<Tag>(connection);
        var tags = repository.Get();
        
        foreach (var tag in tags)
            Console.WriteLine(tag.Name);
    }
    
    public static void CreateUser()
    {
        var user = new User()
        {
            Bio = "Equipe A",
            Email = "aaa@Gmail.com",
            Image = "tal",
            Name = "Equipe A",
            PasswordHash = "hash",
            Slug = "equipe_a"
        };

        using(var connection = new SqlConnection(CONNECTION_STRING))
        {
            connection.Insert<User>(user);
            Console.WriteLine("Criação realizada.");
        }        
    }

    public static void UpdateUser()
    {
        var user = new User()
        {
            Id = 2,
            Bio = "Equipe AA",
            Email = "aaAa@Gmail.com",
            Image = "tal",
            Name = "Equipe AA",
            PasswordHash = "hash",
            Slug = "equipe_aa"
        };

        using(var connection = new SqlConnection(CONNECTION_STRING))
        {
            connection.Update<User>(user);
            Console.WriteLine("Atualização realizada.");
        }        
    }

    public static void DeleteUser()
    {
        using(var connection = new SqlConnection(CONNECTION_STRING))
        {
            var user = connection.Get<User>(2);
            connection.Delete<User>(user);
            Console.WriteLine("Deleção realizada.");
        }        
    }
}
