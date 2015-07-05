using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Net.NetworkInformation;
using System.Threading;


namespace TrainTracker
{
    class DAL
    {
        public static string[] gBallString;
        public static char[] gBallChar;
        public static char[] routeDistCharArray;
        public static List<string> resultsOfRead = new List<string>();
        public static int readerCount;
        public static void sqlQueryVar(char menuResponse)
        {
            if (menuResponse == 'a')
            {
                GoSQL(MasterRoutesTable(gBallString,gBallChar));
                GoSQL(NewRoutesTables(gBallString));
                GoSQL(TableDataInsert(gBallString, gBallChar));
            }
            if (menuResponse == 'b')
            {
                GoSQL(droppingTable(gBallString));
            }
            if (menuResponse == 'c')
            {
                //TO COMPLETE: if statement that is a reg query as to if the entry is valid. Bail out being the rote not exit on the final ELSE.
                //TO COMPLETE change the legnth of the stary box if the output from reader is greater than one char so outside lines match up in ACSII beauty.
                if (routeDistCharArray.Length <= 2)
                {
                    question1MasterTableQuerySolve(routeDistCharArray);
                    ReadSQL(question1MasterTableQuerySolve(routeDistCharArray));
                    Console.WriteLine("The result of your query is a distance of");
                    Console.WriteLine("****************************************");
                    Console.WriteLine("*****              " + resultsOfRead[readerCount-1] + "               *****");
                    Console.WriteLine("****************************************");
                    resultsOfRead = new List<string>();
                    Console.ReadKey();
                    Program.Main();   
                }
                if (routeDistCharArray.Length > 2)
                {
                    ReadSQL(questionOneEasySolve(routeDistCharArray));
                    ReadSQL(longQuestion5Solve(routeDistCharArray));
                    if (doesRouteExist(routeDistCharArray, resultsOfRead))
                    {
                        Console.WriteLine("The result of your query is a distance of");
                        Console.WriteLine("****************************************");
                        Console.WriteLine("*****              " + resultsOfRead[readerCount-2] + "               *****");
                        Console.WriteLine("****************************************");
                        resultsOfRead = new List<string>();
                        Console.ReadKey();
                        Program.Main();
                    }
                    else
                    {
                        Console.WriteLine("****************************************");
                        Console.WriteLine("!!!!!!!!!!No such route exists!!!!!!!!!!");
                        Console.WriteLine("****************************************");
                        readerCount = 0;
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("****************************************");
                    Console.WriteLine("!!!!!!!!!!No such route exists!!!!!!!!!!");
                    Console.WriteLine("****************************************");
                    readerCount = 0;
                    Console.ReadKey();
                }
            }
            else Console.WriteLine("bailing out to main menu");
        }

        public static bool doesRouteExist(char[] routeCountMenu, List<string> resultsOfRead1)
        {
            string transfMark = resultsOfRead[readerCount-1];
            string transfRouteCountMenu = (routeCountMenu.Length-1).ToString();
            if (transfMark == transfRouteCountMenu) return true ;
            return false;
        }

        private static void ReadSQL(StringBuilder sqlQueryReadVar)
        {
            
            using (SqlConnection myConnection = new SqlConnection())
            {
                myConnection.ConnectionString =
                    "Data Source=THISLAPTOP\\SQLSERVERIDPD_01;Initial Catalog=TrainTracka;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
                try
                {
                    myConnection.Open();
                    SqlCommand sqlQueryCommandVar = new SqlCommand(sqlQueryReadVar.ToString(), myConnection);
                    SqlDataReader reader = sqlQueryCommandVar.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            resultsOfRead.Add(reader[0].ToString());
                            readerCount++;
                        }
                    }
                    reader.Close();
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("****************************************");
                    Console.WriteLine("!!!!!!!!!!No such route exists!!!!!!!!!!");
                    Console.WriteLine("****************************************");
                }
            }
        }

        public static void GoSQL(StringBuilder sqlQueryVar)
        {
            using (SqlConnection myConnection = new SqlConnection())
            {
                myConnection.ConnectionString =
                    "Data Source=THISLAPTOP\\SQLSERVERIDPD_01;Initial Catalog=TrainTracka;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
                try
                {
                    myConnection.Open();
                    SqlCommand sqlQueryCommandVar = new SqlCommand(sqlQueryVar.ToString(), myConnection);
                    sqlQueryCommandVar.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public static string[] ArrayedEntriesString(string creatingNewEntries)
        {
            string[] entryStringArray = creatingNewEntries.Split(',');
            gBallString = entryStringArray;
            return entryStringArray;
        }

        public static char[] ArrayedEntriesChar(string creatingNewEntries)
        {
            char[] entryCharArray = creatingNewEntries.ToCharArray();
            gBallChar = entryCharArray;
            return entryCharArray;
        }

        public static char[] routeDistQuestArray(string routeDist)
        {
            int i = new int();
            char[] distQuest = routeDist.ToCharArray();
            char[] distQuest1 = new char[((distQuest.Length/2)+1)];
            while (i < distQuest.Length)
            {
                if (i == 0)
                {
                    distQuest1[0] = distQuest[0];
                    i++;
                }
                if (i > 0)
                {
                    if (i%2 == 0)
                    {
                        if (i == 2)
                        {
                            distQuest1[1] = distQuest[i];
                        }
                        if (i > 2)
                        {
                            int count = i/2;
                            char mark = distQuest[i];
                            distQuest1[count] = mark;
                        }
                    }
                    i++;
                }
            }
            routeDistCharArray = distQuest1;
            return routeDistCharArray;
        }

        public static StringBuilder MasterRoutesTable(string[] tableNames, char[] tableEntries)
        {
            StringBuilder masterTableCreator = new StringBuilder();
            masterTableCreator.Append("CREATE TABLE MasterRoutesTable ( ORIGIN nChar(255), DISTANCE int, DESTINATION nChar(255));");

            int i;
            for (i = 0; i < tableNames.Length; i++)
            {
                int countTicker = (4 * i);
                masterTableCreator.Append(" INSERT INTO MasterRoutesTable");               
                masterTableCreator.Append(" VALUES ( '");
                masterTableCreator.Append(tableEntries[countTicker]);
                masterTableCreator.Append("', ");
                
                masterTableCreator.Append(tableEntries[countTicker + 2]);
               
                masterTableCreator.Append(", '");
                masterTableCreator.Append(tableEntries[countTicker + 1]);
                masterTableCreator.Append("' ");
                masterTableCreator.Append(");");
            }
            return masterTableCreator;
        }

        public static StringBuilder NewRoutesTables(string[] tableNames)
        {
            StringBuilder tableCreator = new StringBuilder();
            int i;
            for (i = 0; i < tableNames.Length; i ++)
            {
                int countTicker = (4*i);
                tableCreator.Append("CREATE TABLE ");
                tableCreator.Append(tableNames[i]);
                tableCreator.Append(" ( ORIGIN nChar(255), DESTINATION nChar(255), DISTANCE int);");
            }
            return tableCreator;
        }

        public static StringBuilder TableDataInsert(string[] tableNames, char[] tableEntries)
        {
                StringBuilder dataInsert = new StringBuilder();
                int i;
                for (i = 0; i < tableNames.Length; i++)
                {
                    int countTicker = (4 * i);
                    dataInsert.Append("INSERT INTO ");
                    dataInsert.Append(tableNames[i]);
                    dataInsert.Append(" VALUES ( '");
                    dataInsert.Append(tableEntries[countTicker]);
                    dataInsert.Append("', ");
                    dataInsert.Append(" '");
                    dataInsert.Append(tableEntries[countTicker + 1]);
                    dataInsert.Append("', ");
                    dataInsert.Append(tableEntries[countTicker + 2]);
                    dataInsert.Append(");");
                }
            return dataInsert;
        }

        public static StringBuilder droppingTable(string[] tableNames)
        {
           int i;
            StringBuilder tableDropper = new StringBuilder();
            for (i = 0; i < tableNames.Length; i++)
            {
                tableDropper.Append("DROP TABLE ");
                tableDropper.Append(tableNames[i]);
                tableDropper.Append("; ");
                Console.WriteLine(tableNames[i]+ "has been DELETED and erased from the history of humankind");
            }
            return tableDropper;
        }

        public static StringBuilder question1MasterTableQuerySolve(char[] tableEntries)
        {
            StringBuilder twoStopsSolution = new StringBuilder();
            if (tableEntries.Length <= 2)
            {
                twoStopsSolution.Append("Select Distance from MasterRoutesTable where origin ='");
                twoStopsSolution.Append(tableEntries[0]);
                twoStopsSolution.Append("' and DESTINATION = '");
                twoStopsSolution.Append(tableEntries[1]);
                twoStopsSolution.Append("' ;");
                return twoStopsSolution;
            }
            return twoStopsSolution;
        }
        
        public static StringBuilder questionOneEasySolve(char[] tableEntries)
        {
            int i;
            StringBuilder question1Builder = new StringBuilder();
            question1Builder.Append("Select SUM(distance) from (");
            for (i = 0; i < tableEntries.Length - 1; i++)
            {
                question1Builder.Append("Select * from MasterRoutesTable where origin = '");
                var selectOrigin = tableEntries[i];
                var selectDestination = tableEntries[i + 1];
                question1Builder.Append(selectOrigin);
                question1Builder.Append("' and DESTINATION = '");
                question1Builder.Append(selectDestination);
                question1Builder.Append("'UNION ");
            }
            question1Builder.Remove(question1Builder.Length-6,6);
            question1Builder.Append(") as TotDist;");
            return question1Builder;
        }

        public static StringBuilder longQuestion5Solve(char[] tableEntries)
        {
            int i;
            StringBuilder question5Builder = new StringBuilder();
            question5Builder.Append("Select COUNT(*) from (");
            for (i = 0; i < tableEntries.Length-1; i++)
            {
                question5Builder.Append("Select * from MasterRoutesTable WHERE ORIGIN = '");
                question5Builder.Append(tableEntries[i]);
                question5Builder.Append("' and DESTINATION = '");
                question5Builder.Append(tableEntries[i+1]);
                question5Builder.Append("' UNION ");
            }
            question5Builder.Remove(question5Builder.Length-6,6);
            question5Builder.Append(") AS ColoumnCountingEh;");
            return question5Builder;
        }

        public static void numStops(string s)
        {
            int i;
            char[] startStopArray = s.ToCharArray();
            StringBuilder startStopQuerry = new StringBuilder();
            startStopQuerry.Append("Create Table StartStops (ORIGIN1 nChar(5), DISTANCE1 int, DESTINATION1 nChar(5));");
            startStopQuerry.Append("Insert INTO StartStops (ORIGIN1, DISTANCE1, DESTINATION1)");
            startStopQuerry.Append("SELECT * FROM dbo.MasterRoutesTable WHERE ORIGIN = '");
            startStopQuerry.Append(startStopArray[0]);
            startStopQuerry.Append("'; ");
            //need a loop, unsure of endpoint, maybe when the variable equals the second letter of the originalinput, the final destination)
            //will loop to 25 as a work around till better thought occurs
            for(i=2; i<27; i++)
            {
                startStopQuerry.Append("ALTER TABLE dbo.StartStops ADD ORIGIN");
                startStopQuerry.Append(i);
                startStopQuerry.Append(" nChar(5);");
                startStopQuerry.Append("ALTER TABLE dbo.StartStops ADD DISTANCE");
                startStopQuerry.Append(i);
                startStopQuerry.Append(" int;");
                startStopQuerry.Append("ALTER TABLE dbo.StartStops ADD DESTINATION");
                startStopQuerry.Append(i);
                startStopQuerry.Append(" nChar(5);");
                startStopQuerry.Append("Insert INTO StartStops (ORIGIN");
                startStopQuerry.Append(i);
                startStopQuerry.Append(", DISTANCE");
                startStopQuerry.Append(i);
                startStopQuerry.Append(", DESTINATION");
                startStopQuerry.Append(i);
                startStopQuerry.Append(
                    ") SELECT ORIGIN, DISTANCE, DESTINATION FROM MasterRoutesTable, StartStops where ORIGIN = DESTINATION");
                startStopQuerry.Append(i-1);
                startStopQuerry.Append("; ");
            }
            Console.WriteLine(startStopQuerry);
            GoSQL(startStopQuerry);
            //
        }
    }
}
