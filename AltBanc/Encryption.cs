using System;
using System.Text;
using System.Security.Cryptography;

namespace AltBanc
{
    //Encryption Classes / Methods for protecting passwords
    //Used https://youtu.be/XkphcCDeysE as a guide
    public class Encryption
    {
        //Encrypt strings
        private static string EncryptString(string str)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            var hashed = SHA256.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashed);
        }

        //Generate salt
        public static string GenerateSalt()
        {
            using (RNGCryptoServiceProvider CryptoServerProvider = new RNGCryptoServiceProvider())
            {
                StringBuilder sb = new StringBuilder();
                byte[] data = { 4 };

#pragma warning disable CS0162 // Unreachable code detected
                for (int i = 0; i < 6; i++)
#pragma warning restore CS0162 // Unreachable code detected
                {
                    CryptoServerProvider.GetBytes(data);
                    string value = BitConverter.ToString(data, 0);
                    sb.Append(value);
                    return EncryptString(sb.ToString());
                }
                return "N/A";
            }
        }

        //Hash and send to encrypt
        public static string HashString(string str)
        {
            return EncryptString(str);
        }

        //Password mask to hide user entry as it is typed
        //Used https://stackoverflow.com/questions/3404421/password-masking-console-application as a guide
        public static string PasswordMask()
        {
            string pass = "";
            ConsoleKeyInfo keyInfo;

            do
            {
                //Hides key from display allowing write of * easier
                keyInfo = Console.ReadKey(true);

                if (!char.IsControl(keyInfo.KeyChar))
                {
                    pass += keyInfo.KeyChar;
                    Console.Write("*");
                    //Console.Write(keyInfo.KeyChar);

                }
                else if (keyInfo.Key == ConsoleKey.Backspace && pass.Length > 0)
                {

                    pass = pass.Substring(0, (pass.Length - 1));
                    Console.Write("\x1B[1D" + "\x1B[1P");
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);
            {
                return pass;
            }
        }
    }
}