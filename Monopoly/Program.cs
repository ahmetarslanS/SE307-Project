using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("kerem");
            p1.ReceiveMoney(250);
            p1.PayMoney(100);
        }
    }
}
