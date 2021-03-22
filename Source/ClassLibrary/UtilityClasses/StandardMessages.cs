using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClassLibrary
{
    public class StandardMessages
    {
        public static void StartMessage()
        {
            string ascii = @"             ____  ____   _    ____ _____   ____   _    ____  _  __
            / ___||  _ \ / \  / ___| ____| |  _ \ / \  |  _ \| |/ /
            \___ \| |_) / _ \| |   |  _|   | |_) / _ \ | |_) | ' / 
             ___) |  __/ ___ | |___| |___  |  __/ ___ \|  _ <| . \ 
            |____/|_| /_/   \_\____|_____| |_| /_/   \_|_| \_|_|\_\";
            bool done = false;        
            while (!done)
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(ascii);
                    Thread.Sleep(900);

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(ascii);
                    Thread.Sleep(900);

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(ascii);
                    Thread.Sleep(900);

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(ascii);
                    Thread.Sleep(900);

                    i = 4;
                    done = true;
                }
            }

            Console.ResetColor();
            Console.WriteLine("");
        }

        public static void NotAllowedMessage()
        {
            Console.Clear();
            Console.WriteLine("Not Allowed. Press any key.");
            Console.ReadKey();
        }
        public static void FullParkMessage()
        {
            Console.Clear();
            Console.WriteLine("Parking is full. Go away. Press any key.");
            Console.ReadKey();
        }

        public static void EmptyParkingLotMessage()
        {
            Console.Clear();
            Console.WriteLine("You cannot leave with nothing. Restart and try again. Press any key.");
            Console.ReadKey();
        }

        public static void LoadingMessage()
        {
            Console.Clear();
            Console.WriteLine("Loading...");
        }

        public static string NameReader()
        {
            Console.Clear();
            Console.WriteLine("Enter name: ");
            return Console.ReadLine();
        }
    }
}
