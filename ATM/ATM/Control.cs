using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Control
    {
        string PIN;
        string TransferPIN;
        Database db;
        int count = 0;
        string[] array;

       void BackDisplay()
       {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nExit(e)");
            Console.WriteLine("Back(b)");
            string text2;
            char temp2;

            while (true)
            {
                
                Console.Write("Enter:");
                text2 = Console.ReadLine();
                temp2 = Convert.ToChar(text2);
   
                if (temp2 == 'b')
                {
                    Console.Clear();
                    Display();
                    break;
                }
                else if (temp2 == 'e')
                {
                    System.Environment.Exit(1);
                }
                throw new FormatException("EXCEPTION! Dont use number");
            }
       }

       void Balance()
       {
            Console.SetCursorPosition(45, 7);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            db.ShowBalance(PIN);
           
            BackDisplay();   
       }
       void CashMoney()
       {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(45, 7);
            Console.WriteLine("1.10 AZN");
            Console.SetCursorPosition(45, 8);
            Console.WriteLine("2.20 AZN");
            Console.SetCursorPosition(45, 9);
            Console.WriteLine("3.50 AZN");
            Console.SetCursorPosition(45, 10);
            Console.WriteLine("4.100 AZN");
            Console.SetCursorPosition(45, 11);
            Console.WriteLine("5.Other(Enter the amount)");
            Console.Write("\nEnter:");
            string text = Console.ReadLine();
            var temp = Convert.ToInt32(text);
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            switch (temp)
            {
                case (1):
                    db.CashMoney(PIN, 10);                   
                    string cashmoney1 = $"Cash Money(10 AZN):{dt}";
                    ToDoLIst(cashmoney1);
                    break;
                case (2):
                    db.CashMoney(PIN, 20);                   
                    string cashmoney2 = $"Cash Money(20 AZN):{dt}";
                    ToDoLIst(cashmoney2);
                    break;
                case (3):
                    db.CashMoney(PIN, 50);                  
                    string cashmoney3 = $"Cash Money(50 AZN):{dt}";
                    ToDoLIst(cashmoney3);
                    break;
                case (4):
                    db.CashMoney(PIN, 100); 
                    string cashmoney4= $"Cash Money(100 AZN):{dt}";
                    ToDoLIst(cashmoney4);
                    break;
                case (5):
                    Console.Write("\nEnter the amount:");
                    string text1 = Console.ReadLine();
                    var temp1 = Convert.ToDecimal(text1);
                    string cashmoney5 = $"Cash Money({temp1} AZN):{dt}";
                    ToDoLIst(cashmoney5);
                    db.CashMoney(PIN, temp1);
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\nThe choice is incorrect.Try Again");
                    CashMoney();
                    break;
            }
            Console.WriteLine("Process is doing...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Get the money Please");
            BackDisplay();
       }
       void ToDoLIst(string text)
        {
            
            string[] newarray = new string[count + 1];
            for (int i = 0; i < count; i++)
            {
                newarray[i] = array[i];
            }
            newarray[count] = text;

            count++;
            array = newarray;

        }
       void TransferMoneyPart2()
       {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            foreach (var user in db.Users)
            {
                decimal temp = 0;
                if (user.CreditCard.PIN == TransferPIN)
                {
                    Console.SetCursorPosition(44, 7);
                    Console.WriteLine("Minimum transfer money 1 AZN");
                    Console.SetCursorPosition(44, 8);
                    Console.WriteLine("Maximum transfer money 10000 AZN");
                    Console.SetCursorPosition(42, 10);
                    Console.Write("The value of the money transferred:");
                    while (true)
                    {
                        string money = Console.ReadLine();
                        temp = Convert.ToDecimal(money);
                        if (temp > 10000 || temp < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("\t\t\t\t\tTransfer money is incorrect.Try Again");
                            TransferMoneyPart2();
                        }
                        else
                        {
                            foreach (var item in db.Users)
                            {
                                if (item.CreditCard.PIN == PIN)
                                {
                                    item.CreditCard.balance = item.CreditCard.balance - temp;
                                    break;
                                }
                            }

                            break;
                        }

                    }
                    user.CreditCard.balance = user.CreditCard.balance + temp;
                    DateTime dt = new DateTime();
                    dt = DateTime.Now;
                    string transfer = $"Transfer Money({temp} AZN):{dt}";
                    ToDoLIst(transfer);
                    Console.WriteLine("Process is doing...");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("Money is transfered successfully");
                    BackDisplay();
                    System.Environment.Exit(1);
                }

            }
        }
       void TransferMoney()
       {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\n\n\n\n\n\t\t\t\t\t Enter PIN card transferred:");
                TransferPIN = (Console.ReadLine());
                if (TransferPIN.Length > 4 || TransferPIN.Length < 4)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t\tPIN must be 4 digits");
                    continue;
                }
                else if (TransferPIN == PIN)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t\t Dont enter the PIN of your card!");
                    continue;
                }
                Console.Clear();
                TransferMoneyPart2();
                Console.Clear();
                Console.WriteLine("\t\t\t\t\tIncoorect PIN");
            }
        }

       void Display()
       {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(45,7);
            Console.WriteLine("1.Balance");
            Console.SetCursorPosition(45, 8);
            Console.WriteLine("2.Cash Money");
            Console.SetCursorPosition(45, 9);
            Console.WriteLine("3.Doing Process List");
            Console.SetCursorPosition(45, 10);
            Console.WriteLine("4.Card to card transfer money");
            Console.SetCursorPosition(45, 11);
            Console.WriteLine("\n");
            Console.SetCursorPosition(45, 12);
            Console.WriteLine("5.Back");

            Console.SetCursorPosition(45, 13);
            Console.Write("\nEnter:");
            string text = Console.ReadLine();
            var temp = Convert.ToInt32(text);
            
            DateTime dt = new DateTime();
            if (temp == 1)
            {
                Console.Clear();
                dt = DateTime.Now;
                string balance = $"Check Balance:{dt}";
                ToDoLIst(balance);
                Balance();
            }
            if (temp == 2)
            {
                Console.Clear();
                CashMoney();
            }
            if (temp == 3)
            {
                Console.Clear();
                foreach (var item in array)
                {
                    Console.WriteLine($"{item}");
                }
                
                BackDisplay();
            }
            if (temp == 4)
            {
                Console.Clear();
                TransferMoney();
            }
            if (temp == 5)
            {
                Console.Clear();
                EnterPIN();
            }
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\nThe choice is incorrect.Try Again");
            Display();
       }
       void EnterPIN()
       {
            
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\n\n\n\n\n\n\t\t\t\t\t\t  Enter PIN:");
                PIN = (Console.ReadLine());
                
                if (PIN.Length > 4 || PIN.Length < 4)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t\t\tPIN must be 4 digits!");
                    continue;
                }
                foreach (var user in db.Users)
                {
                    if (PIN == user.CreditCard.PIN)
                    {
                        Console.Clear();
                        Display();
                        System.Environment.Exit(1);
                    }
                }
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t Incoorect PIN");

            }
       }

        public void start()
        {
            DateTime dt1 = new DateTime(2021, 06, 01);
            Card card1 = new Card("454-576-325-382", "2021", "265", 3500m, dt1);
            User user1 = new User("Nebi", "Nebili", card1);

            DateTime dt2 = new DateTime(2021, 11, 01);
            Card card2 = new Card("454-896-345-234", "9900", "389", 2012.45m, dt2);
            User user2 = new User("Kenan", "Idayetov", card2);

            DateTime dt3 = new DateTime(2021, 12, 01);
            Card card3 = new Card("454-125-534-357", "0909", "478", 4657.45m, dt3);
            User user3 = new User("Emiraslan", "Aliyev", card3);

            User[] users = new User[3]
            {
                user1,user2,user3
            };

            db = new Database(users);

            EnterPIN();
  
        }
    }
}
