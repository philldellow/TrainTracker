﻿using System;
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
                int countTicker = (4*i); 
                StringBuilder tableCreator = new StringBuilder();
                //Console.WriteLine(tableCreator + "-");
                tableCreator.Append("CREATE TABLE ");
                
                tableCreator.Append(tableNames[i]);
                
                tableCreator.Append(" ( ORIGIN nChar(255), DESTINATION nChar(255), DISTANCE int);");
                SqlCommand sqlQuery = new SqlCommand(tableCreator.ToString(), myConnection);
                sqlQuery.ExecuteNonQuery();//this line took a lot longer than reasonable.
                StringBuilder dataInsert = new StringBuilder();

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
                Console.WriteLine(dataInsert);
                SqlCommand dataIncoming = new SqlCommand(dataInsert.ToString(), myConnection);
                dataIncoming.ExecuteNonQuery();
            }

        }

        public static SqlConnection DropATable()
        {
            using (SqlConnection myConnection = new SqlConnection())
            {
                myConnection.ConnectionString = "Data Source=THISLAPTOP\\SQLSERVERIDPD_01;Initial Catalog=TrainTracka;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
                try
                {
                    myConnection.Open();                  
                    droppingTable(gBallString, myConnection);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                return myConnection;
            }

        }

        private static void droppingTable(string[] tableNames,SqlConnection myConnection)
        {
            int i;
            for (i = 0; i < tableNames.Length; i++)
            {
                StringBuilder tableDropper = new StringBuilder();
                tableDropper.Append("DROP TABLE ");
                tableDropper.Append(tableNames[i]);
                Console.WriteLine(tableNames[i]+ "has been DELETED and flushed from the memory of humankind");
            }
        }
    }
}
