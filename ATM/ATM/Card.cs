using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Card
    {
        public Card(string pAN, string pIN, string cVC, decimal balance, DateTime dateTime)
        {
            PAN = pAN;
            PIN = pIN;
            CVC = cVC;
            this.balance = balance;
            this.dateTime = dateTime;
        }

        public string PAN { get; set; }
        public string PIN { get; set; }
        public string CVC { get; set; }
        public decimal balance { get; set; }
        public DateTime dateTime { get; set; }

        public void ShowCard()
        {
            Console.WriteLine($"PAN->{PAN}");
            Console.WriteLine($"PIN->{PIN}");
            Console.WriteLine($"CVC->{CVC}");
            Console.WriteLine($"Balance->{balance}");
            Console.WriteLine($"DateTime->{dateTime.ToString("MM/dd/yyyy")}");
        }
    }
}
