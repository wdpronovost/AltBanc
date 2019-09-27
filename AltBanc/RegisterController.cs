using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace AltBanc
{
    public static class RegisterController
    {
        public static Account currentUser = Program.currentUser;
        public static Account newAccountBeingCreated;
        public static int regField = 0;
        public static int loginAttempts = 0;
        public static int maxLoginAttempts = 3;

        
        //Method for registering a new user
        //Returns user coming back from main menu after success to LoginOrRegister
        public static Account Register(RegistrationEnum currentRegistrationField)
        {
            string label = currentRegistrationField.GetDescription();

            switch (currentRegistrationField)
            {
                case RegistrationEnum.RegisterEmail:

                    //string label = "Email Address";
                    Console.Write("\n\tWhat is your " + label + "? ");

                    var regEmail = Console.ReadLine().Trim();

                    //Check to see if email already exists
                    if (TheBanc.UserAccounts.Exists(i => i.AccountEmailAddressAndUsername == regEmail))
                    {
                        UIHelpers.WarningColor();
                        Console.Write("\n\tThe Email Address '" + regEmail + "' already exists.\n\tDo you want to login instead? (Y\\N) ");
                        ConsoleKey loginInstead = Console.ReadKey().Key;
                        Console.Write("\x1B[1D" + "\x1B[1P" + loginInstead.ToString().ToUpper());

                        if (loginInstead == ConsoleKey.Y)
                        {
                            UIHelpers.ResetColor();
                            Console.WriteLine("\n");
                            LoginController.LoginEmail(loginAttempts);

                        }
                        else
                        {
                            UIHelpers.ResetColor();
                            Register(currentRegistrationField);
                        }

                    }
                    else
                    {
                        newAccountBeingCreated = new Account();

                        newAccountBeingCreated.AccountEmailAddressAndUsername = regEmail;

                        if (VerifyInput(regEmail, label))
                        {
                            Register(++currentRegistrationField);
                        }
                        else
                        {
                            Register(currentRegistrationField);
                        }
                    }
                    break;

                case RegistrationEnum.RegisterFirstName:

                    Console.Write("\n\tWhat is your " + label + "? ");

                    newAccountBeingCreated.CustomerPersonalInformation.FirstName = UppercaseFirst(Console.ReadLine());

                    if (VerifyInput(newAccountBeingCreated.CustomerPersonalInformation.FirstName, label))
                    {
                        Register(++currentRegistrationField);
                    }
                    else
                    {
                        Register(currentRegistrationField);
                    }
                    break;

                case RegistrationEnum.RegisterLastName:

                    Console.Write("\n\tWhat is your " + label + "? ");

                    newAccountBeingCreated.CustomerPersonalInformation.LastName = UppercaseFirst(Console.ReadLine());

                    if (VerifyInput(newAccountBeingCreated.CustomerPersonalInformation.LastName, label))
                    {
                        Register(++currentRegistrationField);
                    }
                    else
                    {
                        Register(currentRegistrationField);
                    }
                    break;

                case RegistrationEnum.RegisterAddress:

                    Console.Write("\n\tWhat is your Street " + label + "? ");

                    newAccountBeingCreated.CustomerPersonalInformation.Address = Console.ReadLine();

                    if (VerifyInput(newAccountBeingCreated.CustomerPersonalInformation.Address, label))
                    {
                        Register(++currentRegistrationField);
                    }
                    else
                    {
                        Register(currentRegistrationField);
                    }
                    break;

                case RegistrationEnum.RegisterCity:

                    Console.Write("\n\tWhat is your " + label + "? ");

                    newAccountBeingCreated.CustomerPersonalInformation.City = UppercaseFirst(Console.ReadLine());

                    if (VerifyInput(newAccountBeingCreated.CustomerPersonalInformation.City, label))
                    {
                        Register(++currentRegistrationField);
                    }
                    else
                    {
                        Register(currentRegistrationField);
                    }
                    break;

                case RegistrationEnum.RegisterState:

                    Console.Write("\n\tWhat is your " + label + "? (Example: OR) ");

                    newAccountBeingCreated.CustomerPersonalInformation.State = Console.ReadLine().ToUpper();

                    if (VerifyInput(newAccountBeingCreated.CustomerPersonalInformation.State, label))
                    {
                        Register(++currentRegistrationField);
                    }
                    else
                    {
                        Register(currentRegistrationField);
                    }
                    break;

                case RegistrationEnum.RegisterZipcode:

                    Console.Write("\n\tWhat is your " + label + "? ");

                    newAccountBeingCreated.CustomerPersonalInformation.Zipcode = Console.ReadLine();

                    if (VerifyInput(newAccountBeingCreated.CustomerPersonalInformation.Zipcode, label))
                    {
                        Register(++currentRegistrationField);
                    }
                    else
                    {
                        Register(currentRegistrationField);
                    }
                    break;

                case RegistrationEnum.RegisterPhoneNumber:

                    Console.Write("\n\tWhat is your " + label + "? ");

                    string regPhoneTemp = Console.ReadLine();
                    newAccountBeingCreated.CustomerPersonalInformation.PhoneNumber = phoneNumberHelper(regPhoneTemp);

                    if (VerifyInput(newAccountBeingCreated.CustomerPersonalInformation.PhoneNumber, label))
                    {
                        Register(++currentRegistrationField);
                    }
                    else
                    {
                        Register(currentRegistrationField);
                    }
                    break;

                case RegistrationEnum.RegistrationFinalVerification:

                    UIHelpers.Clear();

                    Console.WriteLine("\n\tGreat. Let's verify the information...\n");
                    UIHelpers.WarningColor();
                    Console.WriteLine("\tFirst Name: " + newAccountBeingCreated.CustomerPersonalInformation.FirstName);
                    Console.WriteLine("\tLast Name:  " + newAccountBeingCreated.CustomerPersonalInformation.LastName);
                    Console.WriteLine("\tAddress:    " + newAccountBeingCreated.CustomerPersonalInformation.Address);
                    Console.WriteLine("\tCity:       " + newAccountBeingCreated.CustomerPersonalInformation.City);
                    Console.WriteLine("\tState:      " + newAccountBeingCreated.CustomerPersonalInformation.State);
                    Console.WriteLine("\tZipcode:    " + newAccountBeingCreated.CustomerPersonalInformation.Zipcode);
                    Console.WriteLine("\tPhone:      " + newAccountBeingCreated.CustomerPersonalInformation.PhoneNumber);

                    Console.WriteLine("\n\tEmail:      " + newAccountBeingCreated.AccountEmailAddressAndUsername);

                    UIHelpers.ResetColor();
                    Console.WriteLine("\n\t(Y) - Yes, let's continue");
                    Console.WriteLine("\t(N) - No, let's start over\n");


                    Console.Write("\n\tSelection: ");

                    ConsoleKey verifyCustomerInformationResponse = Console.ReadKey().Key;
                    Console.Write("\x1B[1D" + "\x1B[1P" + verifyCustomerInformationResponse.ToString().ToUpper());

                    if (verifyCustomerInformationResponse == ConsoleKey.Y)
                    {

                        currentUser = CreatePassword(newAccountBeingCreated);

                    }
                    else if (verifyCustomerInformationResponse == ConsoleKey.N)
                    {

                        UIHelpers.Clear();
                        currentUser = null;
                        return Register(RegistrationEnum.RegisterEmail);
                    }
                    else
                    {
                        return Register(RegistrationEnum.RegistrationFinalVerification);
                    }

                    break;

            }//End Switch

            return AccountMenuView.AccountMainMenu(currentUser);
        }


        //Method for capitalizing the first letter
        //Returns new string to RegisterMethod
        public static string UppercaseFirst(string stringToUpperFirst)
        {
            if (string.IsNullOrEmpty(stringToUpperFirst))
            {
                return string.Empty;
            }
            char[] arrayOfChars = stringToUpperFirst.ToCharArray();
            arrayOfChars[0] = char.ToUpper(arrayOfChars[0]);
            return new string(arrayOfChars);
        }

        //Method for stripping non digits from phone number
        //Returns new string to RegisterMethod
        public static string phoneNumberHelper(string phoneNumerToModify)
        {
            var r = new Regex(@"\D");
            string phoneNumberToReturn;

            phoneNumberToReturn = r.Replace(phoneNumerToModify, "");

            return phoneNumberToReturn;
        }


        //Method for verify inputs on registering
        //Returns bool to RegisterMethod for error handling
        public static bool VerifyInput(string fieldData, string fieldLabel)
        {
            Console.Write("\n\tPlease verify your " + fieldLabel + " (");
            UIHelpers.WarningColor();
            Console.Write(fieldData);
            UIHelpers.ResetColor();
            Console.Write(") is correct? (Y\\N) ");
            ConsoleKey responseToVerification = Console.ReadKey().Key;
            Console.Write("\x1B[1D" + "\x1B[1P" + responseToVerification.ToString().ToUpper());
            //

            if (responseToVerification == ConsoleKey.Y)
            {
                UIHelpers.Clear();
                UIHelpers.WarningColor();
                Console.WriteLine("\tAccount Setup");
                UIHelpers.ResetColor();
            }
            else
            {
                return false;
            }
            return true;
        }


        //Method for user to create a password
        //Returns user to RegisterMethod
        public static Account CreatePassword(Account userFromRegisterMethod)
        {
            Console.Write("\n\tPlease create a Password: ");

            //Password Masking, Salting, and Hashing
            var regPass = Encryption.PasswordMask();
            var hashedPass = Encryption.HashString(regPass);
            var getSalt = Encryption.GenerateSalt();
            var hashedAndSalted = Encryption.HashString(hashedPass + getSalt);

            //Set Account Salt and Password (Hashed and Salted)
            userFromRegisterMethod.AccountSalt = getSalt;
            userFromRegisterMethod.AccountPassword = hashedAndSalted;

            //New Account has now been created. Set currentUser to newAccount and add to Account List.
            TheBanc.UserAccounts.Add(userFromRegisterMethod);

            return FinancialAccountSetup(userFromRegisterMethod);
        }


        //Method for initial deposit to open account
        //Returns user to CreatePasswordMethod
        public static Account FinancialAccountSetup(Account userFromCreatePasswordMethod)
        {
            UIHelpers.Clear();
            UIHelpers.WarningColor();
            Console.WriteLine("\n\tAlmost finished...");
            UIHelpers.ResetColor();
            Console.WriteLine("\n\tIn order to finish openning an account, you must make an initial deposit of at least $5.00.");
            Console.Write("\n\tWhat type of account do you want to open? (S) - Savings or (C) - Checking? ");
            ConsoleKey responseToAccountType = Console.ReadKey().Key;
            Console.Write("\x1B[1D" + "\x1B[1P" + responseToAccountType.ToString().ToUpper());

            if (responseToAccountType == ConsoleKey.S)
            {
                //
                userFromCreatePasswordMethod.CustomerFinancialInformation.AccountType = "Savings";
                userFromCreatePasswordMethod.CustomerFinancialInformation.AccountNumber = FinancialModel.NextAccountNumber;
                FinancialModel.UpdateNextAccountNumber();
                AccountMenuView.MakingATransaction(userFromCreatePasswordMethod, "Deposit", true);
            }
            else if (responseToAccountType == ConsoleKey.C)
            {
                //
                userFromCreatePasswordMethod.CustomerFinancialInformation.AccountType = "Checking";
                userFromCreatePasswordMethod.CustomerFinancialInformation.AccountNumber = FinancialModel.NextAccountNumber;
                FinancialModel.UpdateNextAccountNumber();
                AccountMenuView.MakingATransaction(userFromCreatePasswordMethod, "Deposit", true);
            }
            else
            {
                return FinancialAccountSetup(userFromCreatePasswordMethod);
            }

            return userFromCreatePasswordMethod;
        }

        //Method gets the description from enum value
        //This is a snippet from Stackoverflow, but I do understand what is going on.
        public static string GetDescription(this RegistrationEnum enumerationValue)
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException($"{nameof(enumerationValue)} must be of Enum type", nameof(enumerationValue));
            }
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumerationValue.ToString();
        }
    }
}
