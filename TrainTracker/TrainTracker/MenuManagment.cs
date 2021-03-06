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
            Console.WriteLine("**|To delete an existing route, enter 'Delete'|**");
            Console.WriteLine(blankLine);
            Console.WriteLine("**|For the distance of a route, enter 'Dist'  |**");
            Console.WriteLine(blankLine);
            //Console.WriteLine("**|    For the number of stops, enter 'Stops' |**");
            //Console.WriteLine(blankLine);
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
            string help = creatingNewEntries.ToUpper();
            if (help == "HELP")
            {
                Program.Main();
            }

            DAL.ArrayedEntriesString(creatingNewEntries);
            DAL.ArrayedEntriesChar(creatingNewEntries);
            char menuResponse = 'a';
            DAL.sqlQueryVar(menuResponse);            
        }

        internal static void DeleteRoute()
        {
            Console.WriteLine("     Please Enter the three letter character code for the");
            Console.WriteLine("     Route you would like to DELETE");
            Console.WriteLine("      i.e. Wellington to Auckland withs 9 distance would be");
            Console.WriteLine("                            WA9");
            Console.WriteLine("For multiple entries please separate the codes with only a comma");
            Console.WriteLine("                 i.e. WA9,AW11,CE3,DW8,ZA7");
            string deletingEntries = Console.ReadLine();
            string help = deletingEntries.ToUpper();
            if (help == "HELP")
            {
                Program.Main();
            }
            DAL.ArrayedEntriesString(deletingEntries);
            DAL.ArrayedEntriesChar(deletingEntries);
            char menuResponse = 'b';
            DAL.sqlQueryVar(menuResponse);
        }

        internal static void Dist()
        {
            Console.WriteLine("Please enter the route as single letters separated by a '-'");
            Console.WriteLine("                   i.e 'A-B-C'  or 'A-B-E-C-D'");
            string routeDist = Console.ReadLine();
            string help = routeDist.ToUpper();
            if (help == "HELP")
            {
                Program.Main();
            }
            DAL.routeDistQuestArray(routeDist);
            char menuResponse = 'c';
            DAL.sqlQueryVar(menuResponse);
        }

        //internal static void Stops()
        //{
        //    Console.WriteLine("Please enter the route you would like to know the number of stops for");
        //    Console.WriteLine("      Enter as an origin letter and destination letter");
        //    Console.WriteLine("       i.e. For the number of stops between C and C");
        //    Console.WriteLine("                            CC");
        //    string numStops = Console.ReadLine();
        //    string help = numStops.ToUpper();
        //    if (help == "HELP")
        //    {
        //        Program.Main();
        //    }
        //    DAL.numStops(numStops);
        //    char menuResponse = 'd';
        //    DAL.sqlQueryVar(menuResponse);
        //}

        internal static void Exit()
        {
            Console.WriteLine("No, I haven't finished playing trains yet");
            Program.Main();
        }
    }
}
