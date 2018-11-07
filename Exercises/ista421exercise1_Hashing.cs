# Hashing Exercise
## Michael Eller
#### 10/14/2018

//--------------Program.cs-----------------------

using System;

namespace Hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            //UI Instructions
            Console.WriteLine("___________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("                        User Authentication                        ");
            Console.WriteLine("___________________________________________________________________");

            var utility = new Utility();
            utility.UserMenu();

        }



   }
}

//---------------Utility.cs--------------------------

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Hashing
{
    class Utility
    {
        private Dictionary<string, string> Account { get; set; } = new Dictionary<string, string>();

        public void AddUser()
        {
            Console.Write("New UserName: ");

            var username = Console.ReadLine();

            if(Account.ContainsKey(username) == true)
            {
                Console.WriteLine("Username Already Exists");
                PrintUsers();
                AddUser();
            }

            Console.Write("Password: ");

            var password = Console.ReadLine();
            var epassword = password;

            Account.Add(username, epassword);
            UserMenu();

        }

        public void UserMenu()
        {
            Console.WriteLine("___________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("    1|New User   2|Authenticate User   3|Exit   4|Print Users      ");
            Console.WriteLine("___________________________________________________________________");

            var response = "";
            response = Console.ReadLine();


              try
              {
                  switch (response)
                  {
                      case "1":
                          AddUser();
                          break;

                      case "2":
                          AuthenticateUser();
                          break;

                      case "3":
                          Console.WriteLine("Good Bye!");
                          Environment.Exit(0);
                          break;

                      case "4":
                          PrintUsers();
                          break;

                      default:
                          Console.WriteLine("Sorry, invalid selection.");
                          UserMenu();
                          break;

                  }

              }
              catch (Exception e)
              {
                Console.WriteLine(e);
                throw;

              }


        }

        public void AuthenticateUser()
        {
            Console.Write("User Name: ");
            var username = Console.ReadLine();

            if (Account.ContainsKey(username) == true)
            {
                Console.Write("Enter Password: ");
                var password = Console.ReadLine();
                var source = password;

                //Start Hash Sequence
                using (var md5Hash = MD5.Create())
                {
                    var hash = GetMd5Hash(md5Hash, source);
                    Console.WriteLine("Verifying the hash...");
                    Console.WriteLine("The MD5 hash of " + source + " is: " + hash);

                    if (VerifyMd5Hash(md5Hash, source, hash))
                    {
                        Console.WriteLine("The hashes are the same");
                        UserMenu();
                    }

                    else
                    {
                        Console.WriteLine("The hashes are not same");
                        AuthenticateUser();
                    }


                    var Epassword = password;

                    foreach (var element in Account)
                    {
                        var key = element.Key;
                        var value = element.Value;

                        if (value == username)
                        {
                            Console.WriteLine("Account Authenticated:");
                            Console.WriteLine($"Your User Name: {key}");
                            Console.WriteLine($"Your Password: {value}");
                            UserMenu();
                        }

                    }

                }
            }

            Console.WriteLine("User does not exist");
            Console.WriteLine("Enter 1 to Add New User");
            UserMenu();
        }

        public void PrintUsers()
        {
            Console.WriteLine("Current Users are:");

            foreach (var kvp in Account) Console.WriteLine("User: {0}", kvp.Key);
        }

        public string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (var i = 0; i < data.Length; i++) sBuilder.Append(data[i].ToString("x2"));

           // Return the hexadecimal string.
              return sBuilder.ToString();
        }

        public bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
           // Hash the input.
           var hashOfInput = GetMd5Hash(md5Hash, input);

           // Create a StringComparer an compare the hashes.
           var comparer = StringComparer.OrdinalIgnoreCase;

           if (0 == comparer.Compare(hashOfInput, hash))

               return true;
           else
               return false;
        }
    }
}
