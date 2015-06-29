﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TrainTracker
{
    class MenuManagment
    {
        
        public static void MainMenu()
        {
            String blankLine = "**|                                           |**";
            String starryLine = "*************************************************";
            int i;
            Console.WriteLine(starryLine);
            Console.WriteLine("************* Hello and Welcome *****************");
            Console.WriteLine("*************  to TrainTracker  *****************");
            Console.WriteLine("*************      (V 1.0)      *****************");
            Console.WriteLine(starryLine);
            Console.WriteLine(blankLine);
            Console.WriteLine("**|To view this menu at any time, enter 'Help'|**");
            Console.WriteLine(blankLine);
            Console.WriteLine("**|       To view all routes, enter 'View'    |**");
            Console.WriteLine(blankLine);
            Console.WriteLine("**|      To input a new route enter 'New'     |**");
            Console.WriteLine(blankLine);
            Console.WriteLine("**|  To edit an existing route, enter 'Edit'  |**");
            Console.WriteLine(blankLine);
            Console.WriteLine("**|      To calculate a route, enter 'Calc'   |**");
            Console.WriteLine(blankLine);
            Console.WriteLine("**|      To clear the screen, enter 'Clear'   |**");
            Console.WriteLine(blankLine);
            Console.WriteLine("**|To exit this menu at any time, enter 'Exit'|**");
            Console.WriteLine(blankLine);
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine(starryLine);
            }
        }

        internal static void View()
        {
            throw new NotImplementedException();
        }

        public static void NewEntryMenu()
        {
            Console.WriteLine("     Please Enter a three character code that represents the;");
            Console.WriteLine("              First letter of the Origin Name,");
            Console.WriteLine("      The Second letter being the Destinations first letter,");
            Console.WriteLine("         And the Third character a number representing");
            Console.WriteLine("           the Distance between the two points");
            Console.WriteLine("      i.e. Wellington to Auckland withs 9 distance would be");
            Console.WriteLine("                            WA9");
            Console.WriteLine("For multiple entries please separate the codes with only a comma");
            Console.WriteLine("                 i.e. WA9,AW11,CE3,DW8,ZA7");
            string creatingNewEntries = Console.ReadLine();
            DAL.ArrayedEntriesString(creatingNewEntries);
            DAL.ArrayedEntriesChar(creatingNewEntries);
            DAL.SqlCon();
            Console.ReadKey();
        }

        internal static void Edit()
        {
            throw new NotImplementedException();
        }

        internal static void Calc()
        {
            throw new NotImplementedException();
        }

        internal static void Exit()
        {
            throw new NotImplementedException();
        }
    }
}