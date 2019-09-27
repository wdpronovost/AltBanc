using System;
using System.Collections;
using System.Collections.Generic;

namespace AltBanc
{
    public class TheBanc
    {
        public static List<Account> UserAccounts { get; } = new List<Account>();

        public static void AddDefaultUser()
        {
            // Setup a default user for testing
            //UserAccounts.Add(new Account("test@test.com"));
            UserAccounts.Add(new Account());
            var defaultUser = UserAccounts[0];
            defaultUser.AccountEmailAddressAndUsername = "test@test.com";
            //Password, "test"
            defaultUser.AccountSalt = "ohhV2gjLEC0dIXxT3Fgko6eVwcGkTpcb8Bq52joqy78=";
            defaultUser.AccountPassword = "UfmUu8LzJazDrhuMDWpHnHbAtEB9xvfDAAVEteJDTpo=";
            defaultUser.CustomerPersonalInformation.FirstName = "Test";
            defaultUser.CustomerPersonalInformation.LastName = "Tester";
            defaultUser.CustomerPersonalInformation.Address = "1600 Penn Ave";
            defaultUser.CustomerPersonalInformation.City = "DC";
            defaultUser.CustomerPersonalInformation.State = "DC";
            defaultUser.CustomerPersonalInformation.Zipcode = "00000";
            defaultUser.CustomerPersonalInformation.PhoneNumber = "2342342345";
            defaultUser.CustomerFinancialInformation.AccountBalance = 500m;
            defaultUser.CustomerFinancialInformation.AccountNumber = "87779999";
            defaultUser.CustomerFinancialInformation.AccountType = "Checking";
        }
    }
}
