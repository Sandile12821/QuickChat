using System.Text.Json;
using System.IO;

namespace QuickChat
{
    public class Message
    {
        public string MessageID { get; set; } = "";
        public int MessageNumber { get; set; }
        public string Recipient { get; set; } = "";
        public string MessageText { get; set; } = "";
        public string MessageHash { get; set; } = "";

        public string CheckRecipientCell()
        {
            if (Recipient.StartsWith("+27") &&
                Recipient.Length == 12)
            {
                return "Cell phone number successfully captured.";
            }

            return "Cell phone number is incorrectly formatted or does not contain an international code. Please correct the number and try again.";
        }

        public string GenerateMessageID()
        {
         Random random = new Random();

         MessageID = random.Next(100000000, 999999999).ToString();

         return MessageID;
        }

        public bool CheckMessageID()
        {
          return MessageID.Length <= 10;
        }


        public string ValidateMessageLength()
        {
          if (MessageText.Length <= 250)
            {
              return "Message ready to send.";
            }

            int excess = MessageText.Length - 250;

            return $"Message exceeds 250 characters by {excess}, please reduce the size.";
        }

        public string CreateMessageHash()
        {
         string[] words = MessageText.Split(' ');

         string firstWord = words[0].ToUpper();

         string lastWord = words[words.Length - 1].ToUpper();

         MessageHash =
         MessageID.Substring(0, 2)
         + ":"
         + MessageNumber
         + ":"
         + firstWord
         + lastWord;

         return MessageHash;
        }

        public string SentMessage(string option)
     {
     if (option == "1")
      {
        return "Message successfully sent.";
      }
      else if (option == "2")
      {
        return "Message successfully stored.";
      }
      else if (option == "3")
      {
        return "Press 0 to delete the message.";
      }

      return "Invalid option.";
     }

      public void StoreMessage()
     {
       string json = JsonSerializer.Serialize(this);

       File.WriteAllText("messages.json", json);
     }

     public int ReturnTotalMessages(int total)
     {
       return total;
     }


    }
}