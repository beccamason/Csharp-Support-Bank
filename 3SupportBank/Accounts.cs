using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3SupportBank
{
    class Accounts
    {
        public string Name { get; set; }
        public List<Transactions> TransactionList { get; set; }
        private decimal Balance { get; set; }

        public Accounts(string name)
        {
            this.Name = name;
            TransactionList = new List<Transactions>();
            Balance = 0;
        }

        public decimal GetBalance()
        {
            return this.Balance;
        }
            
        public static Dictionary<string, Accounts> CreateAccounts(string[] data)
        {
            Dictionary<string, Accounts> accounts = new Dictionary<string, Accounts>();
            foreach(string transaction in data.Skip(1))
            {
                List<string> transactionBreakdown = transaction.Split(",").ToList();
                string fromAccount = transactionBreakdown[1].ToLower();
                string toAccount = transactionBreakdown[2].ToLower();
                if (!accounts.ContainsKey(fromAccount))
                {
                    accounts[fromAccount] = new Accounts(fromAccount);
                }
                if (!accounts.ContainsKey(toAccount))
                {
                    accounts[toAccount] = new Accounts(toAccount);
                }
                WriteTransactions(fromAccount, toAccount, transactionBreakdown, accounts);
            }
            return accounts;
        }

        private static void WriteTransactions(string fromAccount, string toAccount, List<string> transactionBreakdown, Dictionary<string, Accounts> accounts)
        {
            Transactions newFromTransaction = accounts[fromAccount].CreateTransactions(transactionBreakdown, accounts);
            accounts[fromAccount].TransactionList.Add(newFromTransaction);
            Transactions newToTransaction = accounts[toAccount].CreateTransactions(transactionBreakdown, accounts);
            accounts[toAccount].TransactionList.Add(newToTransaction);
            accounts[toAccount].UpdateBalance(newToTransaction);
            accounts[fromAccount].UpdateBalance(newFromTransaction);
        }

        public Transactions CreateTransactions(List<string> transactionData, Dictionary<string, Accounts> accounts)
        {
            DateTime dateTime = DateTime.ParseExact(transactionData[0], "dd/mm/yyyy", null);
            string fromAccount = transactionData[1].ToLower();
            string toAccount = transactionData[2].ToLower();
            string notes = transactionData[3];
            decimal value = Convert.ToDecimal(transactionData[4]);
            Transactions singleTransaction = new Transactions(dateTime, fromAccount, toAccount, notes, value);
            return singleTransaction;
        }

        public void UpdateBalance(Transactions transaction)
        {
            if (transaction.From == Name)
            {
                Balance -= transaction.Value;
            }    
            else if (transaction.To == Name)
            {
                Balance += transaction.Value;
            }
        }
    }
}
