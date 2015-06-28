using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuManagment.MainMenu();
            string mainmenuresponse = Console.ReadLine();
            Console.WriteLine(mainmenuresponse);
            Console.ReadKey();

        }
    }
}
