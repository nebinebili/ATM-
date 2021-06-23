using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class User
    {
        public User(string name, string surName, Card creditCard)
        {
            Name = name;
            SurName = surName;
            CreditCard = creditCard;
        }

        public string Name { get; set; }
        public string SurName { get; set; }
        public Card CreditCard { get; set; }
    }
}
