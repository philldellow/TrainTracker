using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TrainTracker
{
    class Program
    {
        static void Main()
        {
            MenuManagment.MainMenu();
            string mainmenuresponse = Console.ReadLine();
            mainmenuresponse = mainmenuresponse.ToUpper();
            if (mainmenuresponse =="HELP")
                {
                  Program.Main();
                }
            if (mainmenuresponse =="VIEW")
                {
                  MenuManagment.View();
                }
            if (mainmenuresponse =="NEW")
                {
                 MenuManagment.NewEntryMenu();
                    Console.ReadKey();
                }
            if (mainmenuresponse =="EDIT")
                {
                  MenuManagment.Edit();
                }
            if (mainmenuresponse=="CALC")
                {
                    MenuManagment.Calc();
                }

            if (mainmenuresponse =="EXIT")
                {
                    MenuManagment.Exit();
                }
            else
            {
                Console.Write("You are attempting something that I am uncomfortable with, please read the menu again and select one of the proposed options");
                Console.ReadKey();
                Main();
            }

            Console.ReadKey();
        }

    }
}
