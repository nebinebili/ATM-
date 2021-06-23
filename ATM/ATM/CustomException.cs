using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class PINException:ApplicationException 
    {
       public PINException(string text)
       {
           this.text = text;
       }

       public string text { get; set; }

       public new void Message()
       {
           Console.WriteLine($"EXCEPION! {text}");
       }       
    }
    public class BalanceException:ApplicationException
    {
        
        public string text { get; set; }

        public BalanceException(string text)
        {
            this.text = text;
        }

        public new void Message()
        {
            Console.WriteLine($"EXCEPION! {text}");
        }
    }
    
}
