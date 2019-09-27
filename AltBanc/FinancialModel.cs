using System;
using System.Collections.Generic;

namespace AltBanc
{
    public class FinancialModel
    {

        private static string _nextAccountNumber = "87780000";

        private string _accountNumber;
        private string _accountType;
        private decimal _accountBalance;
        private readonly List<TransactionModel> _accountTransactions = new List<TransactionModel>();

        public static string NextAccountNumber
        {
            get
            {
                return _nextAccountNumber;
            }
            set
            {
                _nextAccountNumber = value;
            }
        }

        public string AccountNumber
        {
            get
            {
                return _accountNumber;
            }
            set
            {

                _accountNumber = value;

            }
        }

        public string AccountType
        {
            get
            {
                return _accountType;
            }
            set
            {
                _accountType = value;
            }
        }

        public decimal AccountBalance
        {
            get
            {
                return _accountBalance;
            }
            set
            {
                _accountBalance = value;
            }
        }

        public List<TransactionModel> AccountTransactions
        {
            get
            {
                return _accountTransactions;
            }
            //set
            //{
            //    //_accountTransactions.Add(value);
            //}
        }



        public static void UpdateNextAccountNumber()
        {
            //_accountNumber = _nextAccountNumber;

            int number;
            bool success = int.TryParse(NextAccountNumber, out number);

            if (success)
            {
                
                number++;
                var nextNumber = number.ToString();
                NextAccountNumber = nextNumber;

                //Testing, ensure next number is updated.
                //Console.WriteLine("\nIn Next Number Update Success");
                //Console.WriteLine(nextNumber);
               
            }
            else
            {
                Console.WriteLine("Exception");
            }
        }

        public FinancialModel()
        {
        }

        
    }
}
