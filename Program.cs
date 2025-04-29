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
            // Свързване с MongoDB
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("onlineDebatePlatform");

            // Вземаме колекциите
            var usersCollection = database.GetCollection<User>("users");
            var debatesCollection = database.GetCollection<Debate>("debates");
            var commentsCollection = database.GetCollection<Comment>("comments");
            var votesCollection = database.GetCollection<Vote>("votes");

            Console.WriteLine("=== Users ===");
            var users = await usersCollection.Find(_ => true).ToListAsync();
            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.Username}, Role: {user.Role}");
            }

            Console.WriteLine("\n=== Debates ===");
            var debates = await debatesCollection.Find(_ => true).ToListAsync();
            foreach (var debate in debates)
            {
                Console.WriteLine($"Topic: {debate.Topic}");
                Console.WriteLine($"Description: {debate.Description}");
                Console.WriteLine($"Created by: {debate.CreatedBy}");
                Console.WriteLine("Sides:");
                if (debate.Sides != null)
                {
                    foreach (var side in debate.Sides)
                    {
                        Console.WriteLine($"- {side.Name}: {string.Join(", ", side.Arguments)}");
                    }
                }
                Console.WriteLine("-----------------------");
            }

            Console.WriteLine("\n=== Comments ===");
            var comments = await commentsCollection.Find(_ => true).ToListAsync();
            foreach (var comment in comments)
            {
                Console.WriteLine($"Comment by user {comment.User} on debate {comment.Debate}: {comment.Text}");
            }

            Console.WriteLine("\n=== Votes ===");
            var votes = await votesCollection.Find(_ => true).ToListAsync();
            foreach (var vote in votes)
            {
                Console.WriteLine($"User {vote.User} voted for '{vote.Side}' in debate {vote.Debate}");
            }
        }
    }
}
