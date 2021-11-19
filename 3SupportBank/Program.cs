using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3SupportBank
{
    class Program
    {
        private const string listAll = "all";

        static void Main(string[] args)
        {
            while (true)
            {
                string menuOption = askForMenuOption();
                string path = @"C:\Users\Rebecca.Mason\Documents\Corndel\SupportDocs\transactions.txt";
                Dictionary<string, Accounts> accounts = GetDictionary(path);

                if (menuOption == listAll)
                {
                    ListAll(accounts);
                }
                else
                {
                    ListTransactions(menuOption, accounts);
                }
            }
        }

        private static string askForMenuOption()
        {
            Console.Clear();
            Console.WriteLine("What do you want to list?");
            Console.WriteLine("All");
            Console.WriteLine("Account Name");
            string action = (Console.ReadLine()).ToLower();
            return action;
        }

        public static Dictionary<string, Accounts> GetDictionary(string path)
        {
            Dictionary<string, Accounts> accounts = Accounts.CreateAccounts(Transactions.ReadFile(path));
            return accounts;
        }
        public static void ListTransactions(string name, Dictionary<string, Accounts> accounts)
        {
            if (accounts.ContainsKey(name))
            {
                Console.WriteLine(accounts[name].Name);
                foreach (Transactions transaction in accounts[name].TransactionList)
                {
                    Console.WriteLine(transaction.GetTransaction());
                }
            }
            Console.ReadLine();
        }
        public static void ListAll(Dictionary<string, Accounts> allAccounts)
        {
            
            foreach (var pair in allAccounts)
            {
                Console.WriteLine("{0} has a balance of {1}", pair.Key, pair.Value.GetBalance());
            }
            Console.ReadLine();
        }
    }

  
}
