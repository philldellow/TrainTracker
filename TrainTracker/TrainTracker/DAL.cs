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
        
        //public static SqlConnection myConnection;
        
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
                myConnection.ConnectionString = "Data Source=THISLAPTOP\\SQLSERVERIDPD_01;Initial Catalog=TrainTracka;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
                try
                {
                    myConnection.Open();
                    
                    NewTable(gBallString, gBallChar, myConnection);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                return myConnection;
            }

        }

        
        public static void NewTable(string[] tableNames, char[] tableEntries, SqlConnection myConnection)
        {
            int i;
            for (i = 0; i < tableNames.Length; i ++)
            {
                StringBuilder query = new StringBuilder();
                Console.WriteLine(query + "-");
                query.Append("CREATE TABLE ");
                
                query.Append(tableNames[i]);
                
                query.Append(" ( ORIGIN nChar(255), DESTINATION nChar(255), DISTANCE int);");
                
                //for (int j = 0; j < tableEntries.Length-1; j++)
                //{
                //    Console.WriteLine(query + "-1-");
                //    if (j%4 == 0)
                //    {
                //        query.Append(tableEntries[j]);
                       
                //        query.Append(" ");
                       
                //        query.Append(tableEntries[j + 1]);
                        
                //        query.Append(" ");
                       
                //        //query.Append(tableEntries[j + 2]);
                       
                //        query.Append(", ");
                //        Console.WriteLine(query + "-10-");
                //    }
                //}
                //if (tableEntries.Length > 1)
                //{
                //    query.Length -= 2;
                //} //Remove trailing ", "
                //query.Append(")");
                Console.WriteLine(query);
                SqlCommand sqlQuery = new SqlCommand(query.ToString(), myConnection);
                
                sqlQuery.ExecuteNonQuery();//this line took a lot longer than reasonable.
                
                //Console.WriteLine(query);
                
                //SqlDataReader reader = sqlQuery.ExecuteReader();
            }
        }
    }
}
