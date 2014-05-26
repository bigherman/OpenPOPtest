using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenPop.Pop3;

namespace OpenPOPtest
{
    class Program
    {
        public int test
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        static void Main(string[] args)
        {
            Pop3Client client = new Pop3Client();

            client.Connect("mail1.stofanet.dk", 110, false);
            client.Authenticate("2241859m001", "");
            for (int messageNo = 1; messageNo < client.GetMessageCount() + 1; messageNo++)
            {
                Console.WriteLine();
                Console.WriteLine(client.GetMessageHeaders(messageNo).MessageId);
                Console.WriteLine("Subject:");
                Console.WriteLine(client.GetMessageHeaders(messageNo).Subject);
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Body:");
                    Console.WriteLine(client.GetMessage(messageNo).FindFirstPlainTextVersion().GetBodyAsText());
                }
                catch
                {
                }
                Console.WriteLine("|---------------------------------------------------------------------------------------------------------------------|");
            }
        }
    }
}
