using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using System.Reflection;

Console.WriteLine("*** Azure Queue Receiver ***");


var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                       .AddUserSecrets(Assembly.GetExecutingAssembly())
                                       .Build();

var conString = config.GetSection("ConString").Value;
var queueName = config.GetSection("QueueName").Value;

var client = new QueueClient(conString, queueName);

while (true)
{
    var msg = client.ReceiveMessage();

    if (msg.Value == null)
    {
        Console.WriteLine("Keine neue Message");
        Thread.Sleep(1000);
    }
    else
    {
        client.DeleteMessage(msg.Value.MessageId, msg.Value.PopReceipt);
        Console.WriteLine($"{msg.Value.MessageId} {msg.Value.InsertedOn.Value:g} {msg.Value.Body}");
    }
}


