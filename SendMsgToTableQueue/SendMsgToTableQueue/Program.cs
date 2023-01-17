using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using System.Reflection;

Console.WriteLine("*** Azure Queue Sender ***");


var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                       .AddUserSecrets(Assembly.GetExecutingAssembly())
                                       .Build();

var conString = config.GetSection("ConString").Value;
var queueName = config.GetSection("QueueName").Value;

var client = new QueueClient(conString, queueName);

for (int i = 0; i < 1000; i++)
{
    var msg = $"Hallo {DateTime.Now:G}";
    client.SendMessage(msg);
    Console.WriteLine($"MSG gesendet {msg}");
    Thread.Sleep(200);
}
