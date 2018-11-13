
//==================================Utility.cs==================================================
//    Needs Work: decoding method and UX
//==============================================================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptingDecryptingStrings
{

    class Utility

    {


        public static string Encrypt1(string input)

        {

            // this method is just in case the user doesnt follow the initial instructions

            input = input.ToUpper();
            StringBuilder result = new StringBuilder();

            foreach (char letter in input)
            {
                // converting each char into its unicode and adding 3 to it
                int temp = (int)letter;
                temp += 3;

                // The characters need to wrap and the last capitol letter 'Z' is unicode 90
                if (temp > 90)
                {
                    temp -= 26;
                }

                // converting the unicode back to char
                result.Insert(result.Length, (char)temp);
            }
            return result.ToString();
        }



        public static string Encrypt2(string input)
        {
            int index = input.Length;

            // using the unicode values for "CAT" instead of three
            string cipher = "CAT";
            input = input.ToUpper();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                int temp = (int)input[i];

                // modulating i by the cipher length to make sure it stays within the bounds of the cipher string
                temp += (int)cipher[i % cipher.Length] - 60;

                if (temp > 90)
                {
                    temp -= 26;
                }
                result.Insert(result.Length, (char)temp);
            }
            return result.ToString();
        }

        public static string Encrypt3(string input)
        {
            int index = input.Length;
            input = input.ToUpper();

            // concatinating the input with hardcoded "CAT". The only change from the second encryption method
            string cipher = "CAT" + input;

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                int temp = (int)input[i];
                temp += (int)cipher[i % cipher.Length] - 60;
                if (temp > 90)
                {
                    temp -= 26;
                }
                result.Insert(result.Length, (char)temp);
            }
            return result.ToString();
        }




    }

}
