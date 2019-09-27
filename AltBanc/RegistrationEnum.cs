using System.ComponentModel;


namespace AltBanc
{
    //Enum used for switch in Registration
    //Description used to fill registration labels
    public enum RegistrationEnum
    {
        [Description("Email Address")]
        RegisterEmail = 0,

        [Description("First Name")]
        RegisterFirstName = 1,

        [Description("Last Name")]
        RegisterLastName = 2,

        [Description("Address")]
        RegisterAddress = 3,

        [Description("City")]
        RegisterCity = 4,

        [Description("State")]
        RegisterState = 5,

        [Description("Zipcode")]
        RegisterZipcode = 6,

        [Description("Phone Number")]
        RegisterPhoneNumber = 7,

        [Description("Final Verification")]
        RegistrationFinalVerification = 8,

        //Not currently being used
        //Password is completed seperately now
        [Description("Password")]
        RegistrationPassword = 9
    }
}
