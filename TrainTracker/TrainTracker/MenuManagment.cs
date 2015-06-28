using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        internal static void New()
        {
            throw new NotImplementedException();
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
