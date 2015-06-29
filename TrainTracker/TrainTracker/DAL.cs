using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TrainTracker
{
    class DAL
    {
        //private static string newEntryResponse;
        public static string[] gBallString;
        public static char[] gBallChar;
        public static SqlConnection myConnection1;
        
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


        //make connection with the sqlDbase in order to create new table(s)
        public static SqlConnection SqlCon()
        {
            using (SqlConnection myConnection = new SqlConnection())
            {
                myConnection.ConnectionString = "Server=THISLAPTOP\\SQLSERVERIDPD_01;" + "Database=TrainTracka;" +
                                                "User Id=thislaptop\\Phillip;" +
                                                "Trusted_Connection = true";
                try
                {
                    myConnection.Open();
                    
                    NewTable(gBallString, gBallChar);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                return myConnection1 =myConnection;
            }

        }

        
        public static void NewTable(string[] tableNames, char[] tableEntries)
        {
            Console.WriteLine("you wid me fark?");
            int i;
            for (i = 0; i < tableNames.Length; i ++)
            {
                StringBuilder query = new StringBuilder();
                Console.WriteLine(query + "1");
                query.Append("CREATE TABLE ");
                Console.WriteLine(query + "2");
                query.Append(tableNames[i]);
                Console.WriteLine(query + "3");
                query.Append(" ( ");
                Console.WriteLine(query + "4");
                for (int j = 0; j < tableEntries.Length; j++)
                {
                    Console.WriteLine(query + "5");
                    if (j%4 == 1 || j%4 == 2 || j%4 == 3)
                    {
                        query.Append(tableEntries[j]);
                        Console.WriteLine(query + "6");
                        query.Append(" ");
                        Console.WriteLine(query + "7");
                        query.Append(tableEntries[j + 1]);
                        Console.WriteLine(query + "8");
                        query.Append(" ");
                        Console.WriteLine(query + "9");
                        query.Append(tableEntries[j + 2]);
                        Console.WriteLine(query+"10");
                        query.Append(", ");
                    }
                }
                if (tableEntries.Length > 1)
                {
                    query.Length -= 2;
                } //Remove trailing ", "
                query.Append(")");
                SqlCommand sqlQuery = new SqlCommand(query.ToString(), myConnection1);
                SqlDataReader reader = sqlQuery.ExecuteReader();
            }
        }
    }
}
