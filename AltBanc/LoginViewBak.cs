//using System;
//using System.ComponentModel;

//namespace AltBanc
//{
//    public class LoginView
//    {
//        public static Account currentUser;
//        public static Account newAccount;
//        public static int regField = 0;
//        public static int loginAttempts = 0;
//        public static int maxLoginAttempts = 3;

//        public static Account LoginOrRegister(Account ifUser = null)
//        {
//            //Console.Write("{0} {1}", currentUser.CustomerPersonalInformation.FirstName, currentUser.CustomerPersonalInformation.LastName);
//            Console.WriteLine("\tWhat would you like to do?\n\n\t\t(L) - Login\n\t\t(R) - Register ");
//            Console.Write("\n\tSelection: ");
//            ConsoleKey loginOrRegisterResponse = Console.ReadKey().Key;
//            //Console.WriteLine(loginOrRegisterResponse);

//            if (loginOrRegisterResponse == ConsoleKey.L)
//            {
//                UIHelpers.Clear();
//                currentUser = LoginEmail(loginAttempts);

//                return currentUser;
//            }
//            else if (loginOrRegisterResponse == ConsoleKey.R)
//            {
//                UIHelpers.Clear();
//                UIHelpers.WarningColor();
//                Console.WriteLine("\tLet's get an account setup for you!");
//                UIHelpers.ResetColor();
//                currentUser = Register(0);
//                return currentUser;
//            }
//            else
//            {
//                UIHelpers.DangerColor();
//                Console.WriteLine("\n\tThat is an invalid entry. Please select 'L' to Login or 'R' to Register.\n");
//                UIHelpers.ResetColor();
//                return LoginOrRegister();
//            }

//        }

//        public static Account LoginEmail(int loginAttempts)
//        {
//            //Testing purposes below... Ensure loginAttempts is being tracked.
//            //Console.WriteLine(loginAttempts);

//            //Limit login attempts to 3
//            if (loginAttempts <= maxLoginAttempts)
//            {
//                Console.Write("\tPlease enter your email address: ");
//                string username = Console.ReadLine();

//                if (TheBanc.UserAccounts.Exists(i => i.AccountEmailAddressAndUsername == username))
//                {
//                    //Set currentUser to the List index of userAccounts for the given emailAddress
//                    Account userLoggingIn = TheBanc.UserAccounts[TheBanc.UserAccounts.FindIndex(i => i.AccountEmailAddressAndUsername == username)];

//                    //Testing purposes below...
//                    //Console.WriteLine("The current user's email address is {0}", currentUser.AccountEmailAddressAndUsername);

//                    //Send to password method
//                    //bool success;
//                    //do
//                    //{
//                    Account userThatLoggedIn = LoginPassword(loginAttempts, userLoggingIn);
//                    //}
//                    //while (currentUser != null);
//                    return userThatLoggedIn;
//                }
//                else
//                {
//                    Console.WriteLine("\n");
//                    UIHelpers.DangerColor();
//                    Console.WriteLine("\tWe can't find an account associated with that email address.\n\tYou have " + (maxLoginAttempts - loginAttempts) + " attempt(s) remaining.");
//                    UIHelpers.ResetColor();
//                    loginAttempts++;
//                    return LoginEmail(loginAttempts);
//                }
//            }
//            else
//            {
//                FailedLogin();
//                currentUser = null;
//                //return currentUser;
//                return LoginOrRegister();
//            }

//        }

//        public static Account LoginPassword(int loginAttempts, Account userLoggingIn)
//        {
//            if (loginAttempts <= maxLoginAttempts)
//            {
//                //Console.WriteLine("\n");
//                Console.Write("\tPlease enter your password: ");

//                //Password Masking, Salting, and Hashing
//                var password = Encryption.PasswordMask();
//                var hashedPass = Encryption.HashString(password);
//                var getSalt = userLoggingIn.AccountSalt;
//                var hashedAndSalted = Encryption.HashString(hashedPass + getSalt);

//                //Testing, Ensure we are getting the right password fields.
//                //Console.WriteLine("\n");
//                //Console.WriteLine("Account's stored Salt is {0}", getSalt);
//                //Console.WriteLine("Generated (hoping to match) HashAndSalt / Password field is {0}", hashedAndSalted);
//                //Console.WriteLine("Account's stored Password (HashAndSalt) is " + currentUser.AccountPassword);


//                if (hashedAndSalted == userLoggingIn.AccountPassword)
//                {

//                    //Testing Log
//                    //Console.WriteLine("The current user's email address is {0}", currentUser.AccountEmailAddressAndUsername)
//                    return userLoggingIn;

//                }
//                else
//                {
//                    Console.WriteLine("\n");
//                    UIHelpers.DangerColor();
//                    Console.WriteLine("\tThat password is incorrect. You have " + (maxLoginAttempts - loginAttempts) + " attempt(s) remaining.");
//                    UIHelpers.ResetColor();
//                    loginAttempts++;
//                    return LoginPassword(loginAttempts, userLoggingIn);
//                    //return null;
//                }
//            }
//            else
//            {
//                FailedLogin();
//                currentUser = null;
//                //return currentUser;
//                return LoginOrRegister();
//            }

//        }

//        public static void FailedLogin()
//        {
//            //Console.WriteLine("\n");
//            UIHelpers.DangerColor();
//            Console.Write("\n\tWe are sorry. You have failed logging in 3 times.\n\tPlease try again later or contact customer support.\n\n\tPress any key to exit.");
//            UIHelpers.ResetColor();
//            Console.ReadKey();
//            UIHelpers.Clear();
//            //Environment.Exit(1);

//        }

//        //public static void TestSwitch(int caseToCheck)
//        //{
//        //    Console.WriteLine("Switch start...");

//        //    switch (caseToCheck)
//        //    {
//        //        case 0:
//        //            Console.WriteLine("0");
//        //            break;
//        //        default:
//        //            Console.WriteLine("Default");
//        //            break;
//        //    }

//        //    Console.WriteLine("Switch done...");
//        //}

//        public static Account Register(int regField)
//        {
//            switch (regField)
//            {
//                case 0:

//                    string label = "Email Address";
//                    Console.Write("\n\tWhat is your " + label + "? ");

//                    var regEmail = Console.ReadLine().Trim();

//                    //Check to see if email already exists
//                    if (TheBanc.UserAccounts.Exists(i => i.AccountEmailAddressAndUsername == regEmail))
//                    {
//                        UIHelpers.WarningColor();
//                        Console.Write("\n\tThe email address '" + regEmail + "' already exists.\n\tDo you want to login instead? (Y\\N) ");

//                        if (Console.ReadKey().Key != ConsoleKey.Y)
//                        {
//                            UIHelpers.ResetColor();
//                            return Register(regField);
//                        }
//                        else
//                        {
//                            UIHelpers.ResetColor();
//                            Console.WriteLine("\n");
//                            return LoginEmail(loginAttempts);
//                        }
//                    }
//                    else
//                    {
//                        newAccount = new Account();

//                        //Testing, Account Creation Date, is it being logged
//                        //Console.WriteLine(newAccount.AccountCreationDate);

//                        newAccount.AccountEmailAddressAndUsername = regEmail;
//                        if (VerifyInput(regEmail, label, regField))
//                        {
//                            return Register(1);
//                        }
//                        else
//                        {
//                            return Register(0);
//                        }
//                    }
//                    break;

//                case 1:

//                    label = "First Name";
//                    Console.Write("\n\tWhat is your " + label + "? ");

//                    newAccount.CustomerPersonalInformation.FirstName = UppercaseFirst(Console.ReadLine());
//                    if (VerifyInput(newAccount.CustomerPersonalInformation.FirstName, label, regField))
//                    {
//                        return Register(2);
//                    }
//                    else
//                    {
//                        return Register(1);
//                    }
//                    break;

//                case 2:

//                    label = "Last Name";
//                    Console.Write("\n\tWhat is your " + label + "? ");

//                    newAccount.CustomerPersonalInformation.LastName = UppercaseFirst(Console.ReadLine());
//                    if (VerifyInput(newAccount.CustomerPersonalInformation.LastName, label, regField))
//                    {
//                        return Register(3);
//                    }
//                    else
//                    {
//                        return Register(2);
//                    }
//                    break;

//                case 3:

//                    label = "Address";
//                    Console.Write("\n\tWhat is your " + label + "? ");

//                    newAccount.CustomerPersonalInformation.Address = Console.ReadLine();
//                    if (VerifyInput(newAccount.CustomerPersonalInformation.Address, label, regField))
//                    {
//                        return Register(4);
//                    }
//                    else
//                    {
//                        return Register(3);
//                    }
//                    break;

//                case 4:
//                    label = "City";
//                    Console.Write("\n\tWhat is your " + label + "? ");

//                    newAccount.CustomerPersonalInformation.City = UppercaseFirst(Console.ReadLine());
//                    if (VerifyInput(newAccount.CustomerPersonalInformation.City, label, regField))
//                    {
//                        return Register(5);
//                    }
//                    else
//                    {
//                        return Register(4);
//                    }
//                    break;

//                case 5:
//                    label = "State";
//                    Console.Write("\n\tWhat is your " + label + "? (Example: OR) ");

//                    newAccount.CustomerPersonalInformation.State = Console.ReadLine().ToUpper();
//                    if (VerifyInput(newAccount.CustomerPersonalInformation.State, label, regField))
//                    {
//                        return Register(6);
//                    }
//                    else
//                    {
//                        return Register(5);
//                    }
//                    break;

//                case 6:
//                    label = "Zipcode";
//                    Console.Write("\n\tWhat is your " + label + "? ");

//                    newAccount.CustomerPersonalInformation.Zipcode = Console.ReadLine();
//                    if (VerifyInput(newAccount.CustomerPersonalInformation.Zipcode, label, regField))
//                    {
//                        return Register(7);
//                    }
//                    else
//                    {
//                        return Register(6);
//                    }
//                    break;

//                case 7:
//                    label = "Phone Number";
//                    Console.Write("\n\tWhat is your " + label + "? ");

//                    string regPhoneTemp = Console.ReadLine();
//                    newAccount.CustomerPersonalInformation.PhoneNumber = string.Concat(regPhoneTemp.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
//                    if (VerifyInput(newAccount.CustomerPersonalInformation.PhoneNumber, label, regField))
//                    {
//                        return Register(8);
//                    }
//                    else
//                    {
//                        return Register(7);
//                    }
//                    break;

//                default:

//                    UIHelpers.Clear();

//                    Console.WriteLine("\n\tGreat. Let's verify the information...\n");
//                    UIHelpers.WarningColor();
//                    Console.WriteLine("\tFirst Name: " + newAccount.CustomerPersonalInformation.FirstName);
//                    Console.WriteLine("\tLast Name:  " + newAccount.CustomerPersonalInformation.LastName);
//                    Console.WriteLine("\tAddress:    " + newAccount.CustomerPersonalInformation.Address);
//                    Console.WriteLine("\tCity:       " + newAccount.CustomerPersonalInformation.City);
//                    Console.WriteLine("\tState:      " + newAccount.CustomerPersonalInformation.State);
//                    Console.WriteLine("\tZipcode:    " + newAccount.CustomerPersonalInformation.Zipcode);
//                    Console.WriteLine("\tPhone:      " + newAccount.CustomerPersonalInformation.PhoneNumber);

//                    Console.WriteLine("\n\tEmail:      " + newAccount.AccountEmailAddressAndUsername);

//                    UIHelpers.ResetColor();
//                    Console.WriteLine("\n\t(Y) - Yes, let's continue");
//                    //UIHelpers.DangerColor();
//                    Console.WriteLine("\t(N) - No, let's start over\n");
//                    //UIHelpers.ResetColor();

//                    Console.Write("\n\tSelection: ");

//                    ConsoleKey verifyCustomerInformationResponse = Console.ReadKey().Key;
//                    Console.Write("\b \b {0}", verifyCustomerInformationResponse.ToString().ToUpper());

//                    if (verifyCustomerInformationResponse == ConsoleKey.Y)
//                    {
//                        //Console.Write("\b \b");
//                        Account newRegisterdUser = CreatePassword(newAccount);
//                        FinancialAccountSetup(newRegisterdUser);
//                        return newRegisterdUser;


//                    }
//                    else if (verifyCustomerInformationResponse == ConsoleKey.N)
//                    {
//                        Console.Write("\b \b");
//                        UIHelpers.Clear();
//                        return Register(0);
//                    }
//                    else
//                    {
//                        return Register(8);
//                    }

//                    break;
//            }
//        }

//        public static string UppercaseFirst(string stringToUpperFirst)
//        {
//            if (string.IsNullOrEmpty(stringToUpperFirst))
//            {
//                return string.Empty;
//            }
//            char[] a = stringToUpperFirst.ToCharArray();
//            a[0] = char.ToUpper(a[0]);
//            return new string(a);
//        }


//        public static bool VerifyInput(string fieldData, string fieldLabel, int fieldCase)
//        {
//            //int currentCase = fieldCase;

//            Console.Write("\n\tPlease verify your " + fieldLabel + " (");
//            UIHelpers.WarningColor();
//            Console.Write(fieldData);
//            UIHelpers.ResetColor();
//            Console.Write(") is correct? (Y\\N) ");
//            ConsoleKey response = Console.ReadKey().Key;
//            Console.Write("\b \b");

//            if (response == ConsoleKey.Y)
//            {
//                //currentCase++;
//                UIHelpers.Clear();
//                UIHelpers.WarningColor();
//                Console.WriteLine("\tAccount Setup");
//                UIHelpers.ResetColor();
//                //Register(currentCase);
//                return true;
//            }
//            else
//            {
//                //Register(currentCase);
//                return false;
//            }
//        }

//        public static Account CreatePassword(Account newlySignedUpUser)
//        {
//            //Testing, ensure details are correct so far
//            //CurrentUserDetails(newlySignedUpUser);

//            Console.Write("\n\tPlease create a Password: ");

//            //Password Masking, Salting, and Hashing
//            var regPass = Encryption.PasswordMask();
//            var hashedPass = Encryption.HashString(regPass);
//            var getSalt = Encryption.GenerateSalt();
//            var hashedAndSalted = Encryption.HashString(hashedPass + getSalt);

//            //Set Account Salt and Password (Hashed and Salted)
//            newlySignedUpUser.AccountSalt = getSalt;
//            newlySignedUpUser.AccountPassword = hashedAndSalted;

//            ////Testing, Salt and Hashed
//            //Console.WriteLine("\nPlain Text Pass is {0}", regPass);
//            //Console.WriteLine("Generated Salt is {0}", getSalt);
//            //Console.WriteLine("Generated HashAndSalt / Password field is {0}", hashedAndSalted);

//            //New Account has now been created. Set currentUser to newAccount and add to Account List.
//            //currentUser = newAccount;
//            TheBanc.UserAccounts.Add(newlySignedUpUser);

//            return newlySignedUpUser;
//        }


//        //    //Testing, ensure new account is added to list. 
//        //    //Console.WriteLine("\nWe now have " + TheBanc.UserAccounts.Count + " items in the list");

//        //    //Testing, print details of current user to ensure currentUser is set correctly.
//        //    //CurrentUserDetails(currentUser);

//        //    //Setup Financial Account
//        //    //FinancialAccountSetup();

//        //    //Send To Initial Deposit to Fund Account
//        //    //InitialDeposit();


//        public static void FinancialAccountSetup(Account user)
//        {
//            UIHelpers.Clear();
//            UIHelpers.WarningColor();
//            Console.WriteLine("\n\tAlmost finished...");
//            UIHelpers.ResetColor();
//            Console.WriteLine("\n\tIn order to finish openning an account, you must make an initial deposit of at least $5.00.");
//            Console.Write("\n\tWhat type of account do you want to open? (S) - Savings or (C) - Checking? ");
//            ConsoleKey responseToAccountType = Console.ReadKey().Key;
//            if (responseToAccountType == ConsoleKey.S)
//            {
//                Console.Write("\b \b");
//                user.CustomerFinancialInformation.AccountType = "Savings";
//                user.CustomerFinancialInformation.AccountNumber = FinancialModel.NextAccountNumber;
//                FinancialModel.UpdateNextAccountNumber();
//                AccountMenuView.MakingATransaction(user, "Deposit", true);
//            }
//            else if (responseToAccountType == ConsoleKey.C)
//            {
//                Console.Write("\b \b");
//                user.CustomerFinancialInformation.AccountType = "Checking";
//                user.CustomerFinancialInformation.AccountNumber = FinancialModel.NextAccountNumber;
//                FinancialModel.UpdateNextAccountNumber();
//                AccountMenuView.MakingATransaction(user, "Deposit", true);
//            }
//            else
//            {
//                FinancialAccountSetup(user);
//            }

//        }





//        //Method for testing to ensure we are setting user correctly. Not needed for production. 
//        public static void CurrentUserDetails(Object obj)
//        {
//            Console.WriteLine("In the CurrentUserDetails Method.... ");
//            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
//            {
//                string name = descriptor.Name;
//                object value = descriptor.GetValue(obj);
//                Console.WriteLine("{0}={1}", name, value);
//            }
//            //foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(currentUser.CustomerPersonalInformation))
//            //{
//            //    string name = descriptor.Name;
//            //    object value = descriptor.GetValue(currentUser.CustomerPersonalInformation);
//            //    Console.WriteLine("{0}={1}", name, value);
//            //}
//            //foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(currentUser.CustomerFinancialInformation))
//            //{
//            //    string name = descriptor.Name;
//            //    object value = descriptor.GetValue(currentUser.CustomerFinancialInformation);
//            //    Console.WriteLine("{0}={1}", name, value);
//            //}

//            //Console.WriteLine("{0:C}", currentUser.CustomerFinancialInformation.AccountBalance);
//        }


//    }
//}
