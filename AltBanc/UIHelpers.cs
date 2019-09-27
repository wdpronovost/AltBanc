using System;

namespace AltBanc
{
    public class UIHelpers
    {

        public static void SetWindow()
        {
            int width = 115;
            int height = 50;

            try
            {
                Console.WindowWidth = width;
                Console.WindowHeight = height;
            }
            catch (Exception)
            {
                Console.WriteLine("\n\n\tUnable to set window size. For best results, please size window to 115 x 50. Thank you.");
                Console.WriteLine("\n\tMake all the '.' appear on one line!\n");
                Console.WriteLine("...................................................................................................................");
            }
            Console.WriteLine("\n\n\tWelcome to the AltBanc Demo App");
            Console.WriteLine("\n\tThis was a C# Console App coding challenge.");
            Console.WriteLine("\n\tCreator: William Pronovost");
            Console.WriteLine("\n\tDate: Friday, September 27, 2019");
            Console.WriteLine("\n\tPress 'Spacebar' when ready to start.");
            ConsoleKey response = Console.ReadKey().Key;
            if (response == ConsoleKey.Spacebar)
            {
                System.Threading.Thread.Sleep(500);
            }
        }


        public static void ConsoleSetup()
        {
            Console.Title = "AltBanc";
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void IntroBanner()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t\t                   Welcome To                   ");
            SuccessColor();
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t\t  AAA   lll tt    BBBBB                         ");
            Console.WriteLine("\t\t\t\t AAAAA  lll tt    BB   B    aa aa nn nnn   cccc ");
            Console.WriteLine("\t\t\t\tAA   AA lll tttt  BBBBBB   aa aaa nnn  nn cc    ");
            Console.WriteLine("\t\t\t\tAAAAAAA lll tt    BB   BB aa  aaa nn   nn cc    ");
            Console.WriteLine("\t\t\t\tAA   AA lll  tttt BBBBBB   aaa aa nn   nn  ccccc\n");
            ResetColor();
            Console.WriteLine("\t\t\t\t      We are here to serve all your needs!    \n");
        }

        public static void Clear()
        {
            Console.Clear();
            IntroBanner();
        }

        public static void SuccessColor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void DangerColor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public static void WarningColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static void ResetColor()
        {
            Console.ResetColor();
        }
    }
}
