using MongoDB.Driver;
using OnlineDebateConsole.Models;
using System;
using System.Threading.Tasks;

namespace OnlineDebateConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 1. Връзка към MongoDB сървъра
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            // 2. Избираме базата данни
            var database = client.GetDatabase("onlineDebatePlatform");

            // 3. Избираме колекции
            var usersCollection = database.GetCollection<User>("users");
            var debatesCollection = database.GetCollection<Debate>("debates");
            var commentsCollection = database.GetCollection<Comment>("comments");
            var votesCollection = database.GetCollection<Vote>("votes");

            // 4. Показваме потребителите
            Console.WriteLine("=== Users ===");
            var users = await usersCollection.Find(_ => true).ToListAsync();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Username} - {user.Role}");
            }
        }
    }
}
