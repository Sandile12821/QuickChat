using QuickChat;

Console.WriteLine("Welcome to QuickChat");

Console.Write("Enter number of messages: ");
int totalMessages = Convert.ToInt32(Console.ReadLine());

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("1. Send Messages");
    Console.WriteLine("2. Show Recently Sent Messages");
    Console.WriteLine("3. Quit");

    Console.Write("Choice: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":

    for (int i = 0; i < totalMessages; i++)
    {
        Console.WriteLine();
        Console.WriteLine($"Message {i + 1}");

        Message message = new Message();
        message.MessageNumber = i;
        message.MessageID = message.GenerateMessageID();

        Console.WriteLine($"Message ID: {message.MessageID}");
        Console.WriteLine($"Message ID Valid: {message.CheckMessageID()}");

        Console.Write("Recipient: ");
        message.Recipient = Console.ReadLine();

        Console.WriteLine(message.CheckRecipientCell());

        Console.Write("Message: ");
        message.MessageText = Console.ReadLine();

        Console.WriteLine(message.ValidateMessageLength());

        Console.WriteLine($"Message Hash: {message.CreateMessageHash()}");

        Console.WriteLine();
        Console.WriteLine("1. Send Message");
        Console.WriteLine("2. Store Message");
        Console.WriteLine("3. Discard Message");

        Console.Write("Select Option: ");
        string option = Console.ReadLine();

        if (option == "2")
        {
          message.StoreMessage();

          Console.WriteLine("Message successfully stored.");
        }

        Console.WriteLine();
        Console.WriteLine($"Message ID: {message.MessageID}");
        Console.WriteLine($"Message Hash: {message.MessageHash}");
        Console.WriteLine($"Recipient: {message.Recipient}");
        Console.WriteLine($"Message: {message.MessageText}");

        Console.WriteLine("Message Captured");
    }
      Console.WriteLine();
      Console.WriteLine($"Total Messages Sent: {totalMessages}");

    break;

        case "2":
            Console.WriteLine("Coming Soon");
            break;

        case "3":
            Console.WriteLine("Goodbye!");
            running = false;
            break;

        default:
            Console.WriteLine("Invalid Option");
            break;
    }
}