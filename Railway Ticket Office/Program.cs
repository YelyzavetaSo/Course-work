using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL;

namespace Railway_Ticket_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandHandler handler = new CommandHandler();
            handler.CommandHandle();
            Console.ReadKey();
        }
    }
}
