using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Rebecca.Mason\Documents\Corndel\SupportDocs\transactions.txt";
            string[] transactions = File.ReadAllLines(path);

            Dictionary<string, decimal> accounts = new Dictionary<string, decimal>();

            foreach (string transaction in transactions.Skip(1))
            {
                string[] accountData = transaction.Split(",");
                string fromAccount = accountData[1];
                string toAccount = accountData[2];
                decimal value = Convert.ToDecimal(accountData[4]);
                accounts[fromAccount] = accounts.ContainsKey(fromAccount) ? accounts[fromAccount] - value : 0 - value;
                accounts[toAccount] = accounts.ContainsKey(toAccount) ? accounts[toAccount] + value : 0 + value;
            }
            decimal count = 0;
            foreach (var pair in accounts)
            {
                Console.WriteLine(pair.Key + ", " + pair.Value);
                count += pair.Value;
            }
            Console.WriteLine(count);

        }
    }
}
