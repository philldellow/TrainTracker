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
        public static void Main()
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
            if (mainmenuresponse =="DELETE")
                {
                  MenuManagment.DeleteRoute();
                }
            if (mainmenuresponse == "DIST")
            {
                MenuManagment.Dist();
            }

            if (mainmenuresponse == "STOPS")
            {
                MenuManagment.Stops();
            }

            if (mainmenuresponse =="EXIT")
                {
                    MenuManagment.Exit();
                }
            else
            {
                Console.Write("Please read the menu again and select one of the proposed options");
                Main();
            }

            Console.ReadKey();
        }

    }
}
