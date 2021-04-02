using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Essentials;

namespace RunningApp
{
    public class DB
    {
        private static string DBName = "runLog.db";
        public static SQLiteConnection conn;
        public static void OpenConnection()
        {
            string libFolder = FileSystem.AppDataDirectory;
            string fname = System.IO.Path.Combine(libFolder, DBName);
            conn = new SQLiteConnection(fname);
            conn.CreateTable<RunEntry>();
        }
    }
}
