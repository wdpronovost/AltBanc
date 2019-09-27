using System;
using System.Text.RegularExpressions;

namespace AltBanc
{
    //Model for user accounts
    public class Account
    {
        //Object structure
        private string _accountEmailAddressAndUsername;
        private string _accountPassword;
        private string _accountSalt;
        private readonly DateTime _accountCreationDate;
        private readonly CustomerModel _customerPersonalInformation = new CustomerModel();
        private readonly FinancialModel _customerFinancialInformation = new FinancialModel();

        //Constructor for datestamp
        public Account()
        {
            _accountCreationDate = DateTime.Now;
        }

        public string AccountEmailAddressAndUsername
        {
            get
            {
                return _accountEmailAddressAndUsername;
            }
            set
            {
                var r = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
                if (string.IsNullOrEmpty(value) || !r.IsMatch(value))
                {
                    UIHelpers.DangerColor();
                    Console.WriteLine("\tThat is not a valid Email Address. Please try again.");
                    UIHelpers.ResetColor();
                    RegisterController.Register(0);
                }
                else
                {
                    _accountEmailAddressAndUsername = value;
                }
            }
        }

        public DateTime AccountCreationDate => _accountCreationDate;

        public CustomerModel CustomerPersonalInformation => _customerPersonalInformation;

        public FinancialModel CustomerFinancialInformation => _customerFinancialInformation;

        public string AccountPassword
        {
            get
            {
             return _accountPassword;
            }

            set
            {
                _accountPassword = value;
            }
        }

        public string AccountSalt
        {
            get
            {
                return _accountSalt;
            }
            set
            {
                _accountSalt = value;
            }
        }

    }
}
