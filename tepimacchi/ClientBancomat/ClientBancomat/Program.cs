using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientBancomat
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente c = new Cliente();
            Thread thC = new Thread(new ThreadStart(c.Attività));
            thC.Name = "Cliente";
            thC.Start();
        }
    }

}
