/*
 *
 * Purpose of this file is to keep a record of the different ToString overrides needed during testing.
 *
 * It was surprising to me that I needed to override this method in order to print and view details of the objects.
 * While developing and testing, I rely heavily on Console statements. This file is just to keep the different
 * methods used as future reference (if needed) and allows me to clean up the code from the actual working files.
 *
 *
 * From Customer Model:
 *
 *  public override string ToString()
        {
            return string.Format("{{ First Name: {0}, Last Name: {1}, Address: {2}, City: {3}, State: {4}, Zipcode: {5}, Phone Number: {6} }}", FirstName, LastName, Address, City, State, Zipcode, PhoneNumber);
        }
 *
 * From Financial Model:
 *
 * //public override string ToString()
        //{
        //    return string.Format("{{ Account Number: {0}, Account Type: {1}, Account Balance: {2:C}, Transactions: {3}", AccountNumber, AccountType, AccountBalance, AccountTransactions);
        //}

        //public override string ToString()
        //{
        //    return string.Format("\tAccount Balance: {0:C}", AccountBalance);
        //}

        //public override string ToString()
        //{
        //    return string.Format("\t______________________________________________________________________\n" +
        //                         "\t| {0}               | {1}                          |                  |\n" +
        //                         "\t|-------------------|------------------------------| {2:C}            |\n" +
        //                         "\t|{3}                                               |                  |\n" +
        //                         "\t|__________________________________________________|__________________|", TransactionDate, TransactionType, TransactionAmount, TransactionID);
        //}


 * From TheBanc:
 *
 * None
 *
 * From Account Model:
 *
 * 
        //public override string ToString()
        //{
        //    return string.Format("{{ Account Details {{\n " +
        //        "\tUsername: {0},\n" +
        //        "\tCreated: {1}\n" +
        //        "}}\n" +
        //        "Customer Details {{\n" +
        //        "\tFirst Name: {2},\n" +
        //        "\tLast Name: {3},\n" +
        //        "\tAddress: {4},\n" +
        //        "\tCity: {5},\n" +
        //        "\tState: {6},\n" +
        //        "\tZipcode: {7},\n" +
        //        "\tPhone Number: {8}\n" +
        //        "}}\n" +
        //        "Financial Details {{\n" +
        //        "\tAccount Number: {9},\n" +
        //        "\tAccount Type: {10},\n" +
        //        "\tAccount Balance: {11:C}\n" +
        //        "}}\n" +
        //        "Account Transactions: {{\n" +
        //        "\t{12},\n" +
        //        "}}\n" +
        //        "}}",
        //                         AccountEmailAddressAndUsername,
        //                         AccountCreationDate,
        //                         CustomerPersonalInformation.FirstName,
        //                         CustomerPersonalInformation.LastName,
        //                         CustomerPersonalInformation.Address,
        //                         CustomerPersonalInformation.City,
        //                         CustomerPersonalInformation.State,
        //                         CustomerPersonalInformation.Zipcode,
        //                         CustomerPersonalInformation.PhoneNumber,
        //                         CustomerFinancialInformation.AccountNumber,
        //                         CustomerFinancialInformation.AccountType,
        //                         CustomerFinancialInformation.AccountBalance,
        //                         String.Join(" Billy ", CustomerFinancialInformation.AccountTransactions));
        //}

        //public override string ToString()
        //{
        //    return string.Format("\t______________________________________________________________________\n" +
        //                         "\t| {0}               | {1}                          |                  |\n" +
        //                         "\t|-------------------|------------------------------| {2:C}            |\n" +
        //                         "\t|{3}                                               |                  |\n" +
        //                         "\t|__________________________________________________|__________________|", CustomerFinancialInformation.TransactionDate,CustomerFinancialInformation TransactionType, TransactionAmount, TransactionID);
        //}

        //public override string ToString()
        //{
        //    return string.Format("\tAccount Balance: {0:C}", CustomerFinancialInformation.AccountBalance);
        //}
 *
 *
 *
 * 




        //Method for testing to ensure we are setting user correctly. Not needed for production. 
        public static void CurrentUserDetails(Object obj)
        {
            Console.WriteLine("In the CurrentUserDetails Method.... ");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(obj);
                Console.WriteLine("{0}={1}", name, value);
            }
            //foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(currentUser.CustomerPersonalInformation))
            //{
            //    string name = descriptor.Name;
            //    object value = descriptor.GetValue(currentUser.CustomerPersonalInformation);
            //    Console.WriteLine("{0}={1}", name, value);
            //}
            //foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(currentUser.CustomerFinancialInformation))
            //{
            //    string name = descriptor.Name;
            //    object value = descriptor.GetValue(currentUser.CustomerFinancialInformation);
            //    Console.WriteLine("{0}={1}", name, value);
            //}

            //Console.WriteLine("{0:C}", currentUser.CustomerFinancialInformation.AccountBalance);
        }
 * 
 *
 *
 */