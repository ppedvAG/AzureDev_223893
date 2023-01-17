// See https://aka.ms/new-console-template for more information
using Azure.Storage;
using Azure.Storage.Queues;

Console.WriteLine("*** Azure Queue Receiver ***");

var conString = "DefaultEndpointsProtocol=https;AccountName=mystoragefun;AccountKey=HvsTakf4kCu47HQjIbjUDIbrKV82LCHgPDXEejA2SP0TyVDkTej49fqK80c/lvVFCr/mTDzw/ZeD+AStMsoCWw==;EndpointSuffix=core.windows.net";
var queueName = "zeug";

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


