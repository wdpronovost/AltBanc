using System;

namespace AltBanc
{
    public static class LoginController
    {
        public static Account currentUser = Program.currentUser;
        public static Account newAccountBeingCreated;
        public static int regField = 0;
        public static int loginAttempts = 0;
        public static int maxLoginAttempts = 3;

        //Email entry method for already registered user
        //Returns currentUser to LoginOrRegister
        public static Account LoginEmail(int loginAttempts)
        {
            //Limit login attempts to 3
            if (loginAttempts <= maxLoginAttempts)
            {
                Console.Write("\tPlease enter your email address: ");
                string username = Console.ReadLine();

                if (TheBanc.UserAccounts.Exists(i => i.AccountEmailAddressAndUsername == username))
                {
                    //Set currentUser to the List index of userAccounts for the given emailAddress
                    Account userLoggingIn = TheBanc.UserAccounts[TheBanc.UserAccounts.FindIndex(i => i.AccountEmailAddressAndUsername == username)];
                    currentUser = LoginPassword(loginAttempts, userLoggingIn);
                }
                else
                {
                    Console.WriteLine("\n");
                    UIHelpers.DangerColor();
                    Console.WriteLine("\tWe can't find an account associated with that email address.\n\tYou have " + (maxLoginAttempts - loginAttempts) + " attempt(s) remaining.");
                    UIHelpers.ResetColor();
                    loginAttempts++;
                    return LoginEmail(loginAttempts);
                }
            }
            else
            {
                FailedLogin();
                currentUser = null;
                return Program.LoginOrRegister(currentUser);
            }

            return currentUser;
        }

        //Login for already registed user, sends back to LoginEmail
        public static Account LoginPassword(int loginAttempts, Account userLoggingIn)
        {
            if (loginAttempts <= maxLoginAttempts)
            { 
                Console.Write("\tPlease enter your password: ");

                //Password Masking, Salting, and Hashing
                var password = Encryption.PasswordMask();
                var hashedPass = Encryption.HashString(password);
                var getSalt = userLoggingIn.AccountSalt;
                var hashedAndSalted = Encryption.HashString(hashedPass + getSalt);

                if (hashedAndSalted != userLoggingIn.AccountPassword)
                {
                    Console.WriteLine("\n");
                    UIHelpers.DangerColor();
                    Console.WriteLine("\tThat password is incorrect. You have " + (maxLoginAttempts - loginAttempts) + " attempt(s) remaining.");
                    UIHelpers.ResetColor();
                    loginAttempts++;
                    return LoginPassword(loginAttempts, userLoggingIn);
                }
            }
            else
            {
                FailedLogin();
                currentUser = null;
                return Program.LoginOrRegister(currentUser);
            }
            return AccountMenuView.AccountMainMenu(userLoggingIn);
        }

        //Helper Method for already registered user failing login
        public static void FailedLogin()
        {
            UIHelpers.DangerColor();
            Console.Write("\n\tWe are sorry. You have failed logging in 3 times.\n\tPlease try again later or contact customer support.\n\n\tPress any key to exit.");
            UIHelpers.ResetColor();
            Console.ReadKey();
            UIHelpers.Clear();
        }
    }
}
