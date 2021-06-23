using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Database
    {
       
        public User[] Users { get; set; }

        public Database(User[] users)
        {
            Users = users;
        }

        public Database()
        {

        }
        public void ShowBalance(string text)
        {
            foreach (var user in Users)
            {
                if (user.CreditCard.PIN == text)
                {
                    Console.WriteLine($"Balance->{user.CreditCard.balance}");
                }
            }
        }
      
        public void CashMoney(string text, decimal money)
        {
            foreach (var user in Users)
            {
                if (user.CreditCard.PIN == text)
                {
                    if (money > user.CreditCard.balance || user.CreditCard.balance==0)
                    {
                        throw new BalanceException("Balansda yeteri qeder mebleg yoxdur");
                    }
                    user.CreditCard.balance = user.CreditCard.balance - money;
                }
            }
        }
    }
}
