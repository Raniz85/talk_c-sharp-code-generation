using Example.Json;
using Example.Json.User;

namespace Example;

public class Program
{
    [JsonExample("User")]
    private static string UserJson = @"
    {
        ""id"": 1,
        ""name"": ""Jane Doe"",
        ""email"": ""jane.doe@acme.com"",
        ""isVerified"": true,
        ""createdAt"": ""2024-09-05T12:34:56Z""
    }";

    public static void Main(string[] args)
    {
        var user = new User
        {
            Id = 2,
            Name = "John Doe",
            Email = "john.doe@acme.com",
            IsVerified = false,
            CreatedAt = DateTime.Now,
        };

        Console.WriteLine(user.ToString());
    }
}