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
                ReadSQL(questionOneEasySolve(routeDistCharArray));
            }
            else Console.WriteLine("ahh, I see");
        }

        private static void ReadSQL(StringBuilder sqlQueryReadVar)
        {
            List<string> resultsOfRead = new List<string>();
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
                        }
                    }
                    reader.Close();
                    Console.WriteLine("The result of your query is a distance of");
                    Console.WriteLine("****************************************");
                    Console.WriteLine("*****              " + resultsOfRead[0] + "               *****");
                    Console.WriteLine("****************************************");
                    Console.ReadKey();
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("****************************************");
                    Console.WriteLine("!!!!!!!!!!No such route exists!!!!!!!!!!");
                    Console.WriteLine("****************************************");
                    Console.ReadKey();
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
                masterTableCreator.Append("INSERT INTO MasterRoutesTable");               
                masterTableCreator.Append(" VALUES ( '");
                masterTableCreator.Append(tableEntries[countTicker]);
                masterTableCreator.Append("', ");
                masterTableCreator.Append(" '");
                masterTableCreator.Append(tableEntries[countTicker + 2]);
                masterTableCreator.Append("', ");
                masterTableCreator.Append(tableEntries[countTicker + 1]);
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
            Console.WriteLine(question1Builder);
            return question1Builder;
        }

    }
}
