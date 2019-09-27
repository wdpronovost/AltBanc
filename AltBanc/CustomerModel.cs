using System;
using System.Text.RegularExpressions;

namespace AltBanc
{
    //Customer details model with RegEx for validation
    public class CustomerModel
    {
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _city;
        private string _state;
        private string _zipcode;
        private string _phoneNumber;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                var r = new Regex(@"^[a-zA-Z\.\-_]+");
                if (string.IsNullOrEmpty(value) || !r.IsMatch(value))
                {
                    UIHelpers.DangerColor();
                    Console.WriteLine("\tThat is not a valid First Name. Please try again.");
                    UIHelpers.ResetColor();
                    RegisterController.Register(RegistrationEnum.RegisterFirstName);
                }
                else
                {
                    _firstName = value.Trim();
                }
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                var r = new Regex(@"^[a-zA-Z\.\-_]+");

                if (string.IsNullOrEmpty(value) || !r.IsMatch(value))
                {
                    UIHelpers.DangerColor();
                    Console.WriteLine("\tThat is not a valid Last Name. Please try again.");
                    UIHelpers.ResetColor();
                    RegisterController.Register(RegistrationEnum.RegisterLastName);
                }
                else
                {
                    _lastName = value.Trim();
                }

            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    UIHelpers.DangerColor();
                    Console.WriteLine("\tThat is not a valid Address. Please try again.");
                    UIHelpers.ResetColor();
                    RegisterController.Register(RegistrationEnum.RegisterAddress);
                }
                else
                {
                    _address = value.Trim();
                }

            }
        }

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                var r = new Regex(@"^[a-zA-Z\.\-_]+");

                if (string.IsNullOrEmpty(value) || !r.IsMatch(value))
                {
                    UIHelpers.DangerColor();
                    Console.WriteLine("\tThat is not a valid City. Please try again.");
                    UIHelpers.ResetColor();
                    RegisterController.Register(RegistrationEnum.RegisterCity);
                }
                else
                {
                    _city = value.Trim();
                }
            }
        }

        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                //RegEx of states. Ensure no bogus entries. Not international
                var r = new Regex(@"/AL|AK|AZ|AR|CA|CO|CT|DC|DE|FL|GA|HI|ID|IL|IN|IA|KS|KY|LA|ME|MD|MA|MI|MN|MS|MO|MT|NE|NV|NH|NJ|NM|NY|NC|ND|OH|OK|OR|PA|PR|RI|SC|SD|TN|TX|UT|VT|VA|WA|WV|WI|WY/");

                if (string.IsNullOrEmpty(value) || !r.IsMatch(value))
                {
                    UIHelpers.DangerColor();
                    Console.WriteLine("\tThat is not a valid State. Please try again.");
                    UIHelpers.ResetColor();
                    RegisterController.Register(RegistrationEnum.RegisterState);
                }
                else
                {
                    _state = value;
                }
            }
        }

        public string Zipcode
        {
            get
            {
                return _zipcode;
            }
            set
            {
                var r = new Regex(@"^\d{5}$");

                if (string.IsNullOrEmpty(value) || !r.IsMatch(value))
                {
                    UIHelpers.DangerColor();
                    Console.WriteLine("\tThat is not a valid Zipcode. Please try again.");
                    UIHelpers.ResetColor();
                    RegisterController.Register(RegistrationEnum.RegisterZipcode);
                }
                else
                {
                    _zipcode = value;
                }
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                var r = new Regex(@"^[1]?[\s\-\.]?(\([2-9][0-9][0-9]\)|[2-9][0-9][0-9])[\s\-\.]?\d{3}[\s\-\.]?\d{4}$");

                if (string.IsNullOrEmpty(value) || !r.IsMatch(value))
                {
                    UIHelpers.DangerColor();
                    Console.WriteLine("\tThat is not a valid Phone Number. Please try again.");
                    UIHelpers.ResetColor();
                    RegisterController.Register(RegistrationEnum.RegisterPhoneNumber);
                }
                else
                {
                    _phoneNumber = value;
                }
            }
        }

        public CustomerModel()
        {
        }
    }
}
