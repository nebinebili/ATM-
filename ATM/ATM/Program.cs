using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Control start = new Control();
            
            try
            {
                start.start();
            }
            catch (BalanceException ex)
            {
                ex.Message();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();
        }
    }
}
