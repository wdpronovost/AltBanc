using System;

namespace AltBanc
{
    public class AccountMenuView
    {
        //Main method for account
        //Allows all user actions
        //Returns currentUser to LoginOrRegister
        public static Account AccountMainMenu(Account currentLoggedInUser)
        {
            var currentUser = currentLoggedInUser;

            UIHelpers.Clear();
            Console.Write("\n\tWelcome ");
            UIHelpers.WarningColor();
            Console.Write("{0} {1}", currentUser.CustomerPersonalInformation.FirstName, currentUser.CustomerPersonalInformation.LastName);
            UIHelpers.ResetColor();
            Console.Write(" To The Main Menu.\n\tWhat would you like to do?\n");
            Console.WriteLine("\n\t(D) - Make a Deposit");
            Console.WriteLine("\n\t(W) - Make a Withdrawal");
            Console.WriteLine("\n\t(B) - Check your Available Balance");
            Console.WriteLine("\n\t(T) - View Recent Transaction History");
            Console.WriteLine("\n\t(X) - Logout\n");
            Console.Write("\n\n\tSelection: ");

            ConsoleKey accountMenuActionResponse = Console.ReadKey().Key;
            Console.Write("\x1B[1D" + "\x1B[1P" + accountMenuActionResponse.ToString().ToUpper());

            if (accountMenuActionResponse == ConsoleKey.X)
            {
                //Reset Current User to Null and Send Back To LoginView
                currentUser = null;
                UIHelpers.Clear();
                Program.LoginOrRegister(currentUser);
            }
            else if (accountMenuActionResponse == ConsoleKey.D)
            {
                MakingATransaction(currentUser, "Deposit", false);
            }
            else if (accountMenuActionResponse == ConsoleKey.W)
            {
                MakingATransaction(currentUser, "Withdrawal", false);
            }
            else if (accountMenuActionResponse == ConsoleKey.B)
            {
                CheckAccountBalance(currentUser);
            }
            else if (accountMenuActionResponse == ConsoleKey.T)
            {
                TransactionHistoryLog(currentUser);
            }
            else
            {
                return AccountMainMenu(currentUser);
            }

            return currentUser;
        }

        //Method for displaying account balance
        public static Account CheckAccountBalance(Account userMakingTransaction)
        {
            //Layout for balance display
            UIHelpers.Clear();
            Console.WriteLine("\t==================================================");
            Console.WriteLine("\tAccount Balance");
            Console.WriteLine("\t==================================================");
            Console.WriteLine("\tAccount Owner:    \t{0} {1}", userMakingTransaction.CustomerPersonalInformation.FirstName, userMakingTransaction.CustomerPersonalInformation.LastName);
            Console.WriteLine("\tAccount Number:   \t{0}", userMakingTransaction.CustomerFinancialInformation.AccountNumber);
            Console.WriteLine("\tAccount Type:     \t{0}\n", userMakingTransaction.CustomerFinancialInformation.AccountType);
            Console.WriteLine("\tDate:             \t{0}", DateTime.Now);
            Console.WriteLine("\t==================================================");
            Console.WriteLine("\n");

            //Actual get of balance
            Console.WriteLine("\tAvailable Balance:\t{0:C}", userMakingTransaction.CustomerFinancialInformation.AccountBalance);

            //Return to main menu
            Console.WriteLine("\n");
            Console.Write("\tPress 'Spacebar' to return to the account menu.");
            if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                AccountMainMenu(userMakingTransaction);
            return userMakingTransaction;
        }


        //Method for displaying account balance
        public static Account TransactionReceipt(Account userMakingTransaction)
        {
            var transaction = userMakingTransaction.CustomerFinancialInformation.AccountTransactions[0];
            //Layout for balance display
            UIHelpers.Clear();
            Console.WriteLine("\t==================================================");
            Console.WriteLine("\tTransaction Receipt");
            Console.WriteLine("\t==================================================");
            Console.WriteLine("\tAccount Owner:    \t{0} {1}", userMakingTransaction.CustomerPersonalInformation.FirstName, userMakingTransaction.CustomerPersonalInformation.LastName);
            Console.WriteLine("\tAccount Number:   \t{0}", userMakingTransaction.CustomerFinancialInformation.AccountNumber);
            Console.WriteLine("\tAccount Type:     \t{0}\n", userMakingTransaction.CustomerFinancialInformation.AccountType);
            Console.WriteLine("\tDate:             \t{0}", DateTime.Now);
            Console.WriteLine("\t==================================================");
            Console.WriteLine("\tAvailable Balance:\t{0:C}", userMakingTransaction.CustomerFinancialInformation.AccountBalance);
            Console.WriteLine("\t==================================================");
            Console.WriteLine("\n");
            Console.WriteLine("\tDetails of your recent transaction:\n");
            Console.WriteLine("\tTransaction Date:   \t{0}", transaction.TransactionDate);
            Console.WriteLine("\tTransaction ID:     \t{0}\n", transaction.TransactionID);
            Console.WriteLine("\tTransaction Type:   \t{0}", transaction.TransactionType);
            Console.WriteLine("\tTransaction Amount: \t{0:C}", transaction.TransactionAmount);

            //Return to main menu
            Console.WriteLine("\n");
            Console.Write("\tPress 'Spacebar' to return to the account menu.");
            if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                AccountMainMenu(userMakingTransaction);
            return userMakingTransaction;
        }



        //Method for displaying transaction history
        public static Account TransactionHistoryLog(Account userMakingTransaction)
        {
            //Layout for transaction log
            UIHelpers.Clear();
            Console.WriteLine("\t======================================================================");
            Console.WriteLine("\tTransaction Log");
            Console.WriteLine("\t======================================================================");
            Console.WriteLine("\tAccount Owner:    \t{0} {1}", userMakingTransaction.CustomerPersonalInformation.FirstName, userMakingTransaction.CustomerPersonalInformation.LastName);
            Console.WriteLine("\tAccount Number:   \t{0}", userMakingTransaction.CustomerFinancialInformation.AccountNumber);
            Console.WriteLine("\tAccount Type:     \t{0}\n", userMakingTransaction.CustomerFinancialInformation.AccountType);
            Console.WriteLine("\tDate:             \t{0}", DateTime.Now);
            Console.WriteLine("\t======================================================================");
            Console.WriteLine("\tAvailable Balance:\t{0:C}", userMakingTransaction.CustomerFinancialInformation.AccountBalance);
            Console.WriteLine("\t======================================================================");
            Console.WriteLine("\n");
            Console.WriteLine("\tList of Account Transactions:");

            //Actual call to get transaction data
            userMakingTransaction.CustomerFinancialInformation.AccountTransactions.ForEach(Console.WriteLine);

            //Return to main menu
            Console.WriteLine("\n");
            Console.Write("\tPress 'Spacebar' to return to the account menu.");
            if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                AccountMainMenu(userMakingTransaction);

            return userMakingTransaction;
        }

        //Seems like helper functions could simplify this
        public static Account MakingATransaction(Account userMakingTransaction, string typeOfTransaction = "Deposit", bool isInitialDeposit = false)
        {
            decimal initialDeposit;
            decimal depositAmount;
            decimal withdrawalAmount;
            string amountStr;
            bool success;

            decimal currentAccountBalance = userMakingTransaction.CustomerFinancialInformation.AccountBalance;

            if (typeOfTransaction == "Withdrawal")
            {
                if (currentAccountBalance > 5m)
                {
                    UIHelpers.Clear();
                    Console.Write("\t('X + Return' to Cancel)");
                    Console.WriteLine("\n\tYour current balance is: {0:C}", currentAccountBalance);
                    Console.Write("\n\tHow much would you like to ");
                    UIHelpers.DangerColor();
                    Console.Write("withdraw");
                    UIHelpers.ResetColor();
                    Console.Write("? ");
                    amountStr = Console.ReadLine();

                    if (amountStr.ToUpper() == "X")
                    {
                        CancelTransaction();
                        return AccountMainMenu(userMakingTransaction);
                    }

                    success = decimal.TryParse(amountStr, out withdrawalAmount);
                    withdrawalAmount = Math.Abs(withdrawalAmount) * -1;


                    if (success && (currentAccountBalance + withdrawalAmount >= 5m) && withdrawalAmount != 0m)
                    {
                        TransactionHelper(userMakingTransaction, typeOfTransaction, withdrawalAmount, false);
                    }
                    else
                    {
                        UIHelpers.DangerColor();
                        Console.WriteLine("\n\tOOPS! You don't have enough money to withdraw {0:C}.", withdrawalAmount);
                        Console.WriteLine("\n\tYou must keep an account balance of at least $5.00.");
                        Console.Write("\tPress 'Spacebar' to try again...");
                        UIHelpers.ResetColor();
                        ConsoleKey tryWithdrawalAgain = Console.ReadKey().Key;
                        if (tryWithdrawalAgain == ConsoleKey.Spacebar)
                        {
                            return MakingATransaction(userMakingTransaction, typeOfTransaction, isInitialDeposit);
                        }
                    }
                }
                else
                {
                    UIHelpers.DangerColor();
                    Console.WriteLine("\n\tOOPS! You don't have enough money to make a withdrawal.");
                    Console.WriteLine("\n\tYou must keep an account balance of at least $5.00.");
                    Console.Write("\tPress 'Spacebar' to return to Account Main Menu.");
                    UIHelpers.ResetColor();
                    ConsoleKey returnToMainMenu = Console.ReadKey().Key;
                    if (returnToMainMenu == ConsoleKey.Spacebar)
                    {
                        return AccountMainMenu(userMakingTransaction);
                    }
                }
            }

            //Coming from Registration
            else if (isInitialDeposit)
            {
                Console.Write("\n\t('X + Return' to Cancel)");
                Console.Write("\n\tHow much would you like to deposit? ");
                amountStr = Console.ReadLine();

                if (amountStr.ToUpper() == "X")
                {
                    CancelTransaction();
                    return RegisterController.FinancialAccountSetup(userMakingTransaction);
                }

                success = decimal.TryParse(amountStr, out initialDeposit);

                if (success && initialDeposit >= 5m)
                {
                    TransactionHelper(userMakingTransaction, typeOfTransaction, initialDeposit, true);
                }
                else
                {
                    UIHelpers.DangerColor();
                    Console.WriteLine("\n\tPlease open account with at least $5.00");
                    UIHelpers.ResetColor();
                    return MakingATransaction(userMakingTransaction, typeOfTransaction, isInitialDeposit);
                }
            } // end initial deposit

            //Coming from Account Menu
            else //general deposit
            {
                UIHelpers.Clear();
                Console.Write("\t('X + Return' to Cancel)");
                Console.WriteLine("\n\tYour current balance is: {0:C}", currentAccountBalance);
                Console.Write("\n\tHow much would you like to deposit? ");
                amountStr = Console.ReadLine();

                if (amountStr.ToUpper() == "X")
                {
                    CancelTransaction();
                    return AccountMainMenu(userMakingTransaction);
                }

                success = decimal.TryParse(amountStr, out depositAmount);

                if (success && depositAmount >= 0m)
                {
                    TransactionHelper(userMakingTransaction, typeOfTransaction, depositAmount, false);
                }
                else
                {
                    UIHelpers.DangerColor();
                    Console.WriteLine("\n\tPlease deposit more than $0.00");
                    UIHelpers.ResetColor();
                    return MakingATransaction(userMakingTransaction, typeOfTransaction, isInitialDeposit);
                }
            }// end general deposit

            return userMakingTransaction;

        }//End MakingTransaction Method


        //Method helper to allow a user to cancel out of a transaction
        public static void CancelTransaction()
        {
            UIHelpers.WarningColor();
            Console.WriteLine("\n\tCanceling the transaction.");
            System.Threading.Thread.Sleep(2500);
            //AccountMainMenu(userMakingTransaction);
        }

        //Method helper for common aspects of making a transaction
        public static Account TransactionHelper(Account userMakingTransaction, string typeOfTransaction, decimal transAmount, bool isInitialDeposit)
        {
            Console.Write("\n\tYou are ");

            if(typeOfTransaction == "Deposit")
            {
                Console.Write("depositing");
            }
            else
            {
                UIHelpers.DangerColor();
                Console.Write("withdrawing");
                UIHelpers.ResetColor();
            }
            Console.Write(" {0:C} is that correct? (Y\\N\\x) ", transAmount);
            ConsoleKey verifyTranactionAmount = Console.ReadKey().Key;
            Console.Write("\x1B[1D" + "\x1B[1P" + verifyTranactionAmount.ToString().ToUpper());

            if (verifyTranactionAmount == ConsoleKey.Y)
            {
                Console.Write("\n");
                var transaction = new TransactionModel(typeOfTransaction, transAmount);
                userMakingTransaction.CustomerFinancialInformation.AccountBalance += (decimal)transAmount;

                //Insert over add to list
                //This way, [0] is always the last item
                userMakingTransaction.CustomerFinancialInformation.AccountTransactions.Insert(0, transaction);
                TransactionReceipt(userMakingTransaction);
            }
            else if (verifyTranactionAmount == ConsoleKey.X)
            {
                if(isInitialDeposit)
                {
                    return RegisterController.FinancialAccountSetup(userMakingTransaction);
                }

                UIHelpers.WarningColor();
                Console.WriteLine("\n\tCanceling the transacation and returning to Account Main Menu.");
                System.Threading.Thread.Sleep(2500);
                return AccountMainMenu(userMakingTransaction);
            }
            else
            {
                return MakingATransaction(userMakingTransaction, typeOfTransaction, isInitialDeposit);
            }

            return userMakingTransaction;
        }

    }//End Class 
}//End NameSpace