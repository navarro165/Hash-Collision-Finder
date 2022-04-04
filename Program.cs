using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace P2
{
    class Program
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        static void Main(string[] args)
        {
            if (args.Length != 3) 
                throw new Exception("Please include salt byte, length of random strings, and length of hash");

            string saltBye = args[0];
            int lenRandom = int.Parse(args[1]);
            int lenTargetHash = int.Parse(args[2]);
            
            Hashtable ht = new Hashtable();
            Random random = new Random();

            while (true) {
                string randString = new string(Enumerable.Repeat(chars, lenRandom).Select(s => s[random.Next(s.Length)]).ToArray());
                byte [] hash = CreateMD5(randString, saltBye);
                string hashString = $"{BitConverter.ToString(hash[..lenTargetHash]).Replace("-", " ")}";
                
                if (!ht.Contains(hashString))
                    ht.Add(hashString, randString);
                else {
                    Console.WriteLine($"Hash: '{hashString}'");
                    Console.WriteLine($"Collision strings: '{randString}', '{ht[hashString]}'");
                    break;
                }     
            }
        }

        public static byte[] CreateMD5(string input, string salt) {
            var inputBytes = new List<byte>(Encoding.UTF8.GetBytes(input));
            inputBytes.Add(Convert.ToByte(salt, 16));
            byte[] saltedBytes = inputBytes.ToArray();

            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] hashBytes = md5.ComputeHash(saltedBytes);
            // Console.WriteLine($"{BitConverter.ToString(hashBytes).Replace("-", " ")}");
            return hashBytes;
        }
    }
}
