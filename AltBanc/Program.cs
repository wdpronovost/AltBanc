using System;


namespace AltBanc
{
    class Program
    {
        public static Account currentUser = null;
        public static int loginAttempts = 0;

        static void Main(string[] args)
        {
            //Add Default User
            TheBanc.AddDefaultUser();

            //Set Window and Console
            UIHelpers.SetWindow();
            UIHelpers.ConsoleSetup();
            UIHelpers.Clear();

            ////Get a user or stay at login screen
            do
            {
                currentUser = LoginOrRegister(currentUser);
            }
            while (currentUser == null);


            //Keeps Console Open - Unsure if really needed
            //Testing indicates not needed, but leaving it just in case
            //Console.ReadLine();


        }

        public static Account LoginOrRegister(Account currentUser)
        {
            UIHelpers.Clear();
            Console.WriteLine("\tWhat would you like to do?\n\n\t\t(L) - Login\n\t\t(R) - Register ");
            Console.Write("\n\tSelection: ");
            ConsoleKey loginOrRegisterResponse = Console.ReadKey().Key;
            Console.Write("\x1B[1D" + "\x1B[1P" + loginOrRegisterResponse.ToString().ToUpper());

            if (loginOrRegisterResponse == ConsoleKey.L)
            {
                UIHelpers.Clear();
                currentUser = LoginController.LoginEmail(loginAttempts);
            }
            else if (loginOrRegisterResponse == ConsoleKey.R)
            {
                UIHelpers.Clear();
                UIHelpers.WarningColor();
                Console.WriteLine("\tLet's get an account setup for you!");
                UIHelpers.ResetColor();
                currentUser = RegisterController.Register(RegistrationEnum.RegisterEmail);
            }
            else
            {
                UIHelpers.DangerColor();
                Console.WriteLine("\n\tThat is an invalid entry. Please select 'L' to Login or 'R' to Register.\n");
                System.Threading.Thread.Sleep(1000);
                UIHelpers.ResetColor();
                currentUser = null;
                LoginOrRegister(currentUser);
            }

            return currentUser;
        }
    }
}




