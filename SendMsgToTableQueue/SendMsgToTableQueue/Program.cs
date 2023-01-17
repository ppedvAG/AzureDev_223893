using Azure.Storage.Queues;

Console.WriteLine("*** Azure Queue Sender ***");

var conString = "DefaultEndpointsProtocol=https;AccountName=mystoragefun;AccountKey=HvsTakf4kCu47HQjIbjUDIbrKV82LCHgPDXEejA2SP0TyVDkTej49fqK80c/lvVFCr/mTDzw/ZeD+AStMsoCWw==;EndpointSuffix=core.windows.net";
var queueName = "zeug";

var client = new QueueClient(conString, queueName);

for (int i = 0; i < 1000; i++)
{
    var msg = $"Hallo {DateTime.Now:G}";
    client.SendMessage(msg);
    Console.WriteLine($"MSG gesendet {msg}");
    Thread.Sleep(200);
}
