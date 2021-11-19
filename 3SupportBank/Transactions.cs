using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3SupportBank
{
    class Transactions
    {
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Notes { get; set; }
        public decimal Value { get; set; }

        public Transactions(DateTime date, string from, string to, string notes, decimal value)
        {
            Date = date;
            From = from;
            To = to;
            Notes = notes;
            Value = value;
        }

        public static string[] ReadFile(string path)
        {
            string[] transactions = File.ReadAllLines(path);
            return transactions;
        }

        public string GetTransaction()
        {
            return $"{Date}, {From}, {To}, {Notes}, {Value}";
        }
    }
}
