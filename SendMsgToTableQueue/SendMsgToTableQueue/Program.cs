using Azure.Storage.Queues;

Console.WriteLine("*** Azure Queue Sender ***");

var conString = "DefaultEndpointsProtocol=https;AccountName=mystoragefun;AccountKey=HvsTakf4kCu47HQjIbjUDIbrKV82LCHgPDXEejA2SP0TyVDkTej49fqK80c/lvVFCr/mTDzw/ZeD+AStMsoCWw==;EndpointSuffix=core.windows.net";
var queueName = "zeug";

var client = new QueueClient(conString, queueName);


for (int i = 0; i < 10; i++)
{
    client.SendMessage($"Hallo {DateTime.Now:G}");
}
