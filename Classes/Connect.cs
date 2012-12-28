using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite.Designer.Design;
using System.Data;
using System.Data.SQLite;

namespace sqlite.cs.Classes
{
    class Connect
    {
        protected SQLiteConnection conn;

        public Connect(String db, String passwd = null)
        {
            String connStr = string.Format("Data Source={0};Version=3;UTF8Encoding=True;", db);
            if(passwd != null && passwd.Trim() != String.Empty)
            {
                connStr += string.Format("PWD={0};",passwd);
            }
            Console.WriteLine(connStr);
            this.conn = new SQLiteConnection(connStr);
        }

        public SQLiteConnection Refresh()
        {
            if (this.conn.State == ConnectionState.Open)
            {
                this.conn.Close();
            }
            this.conn.Open();
            return this.conn;
        }

        public DataTable GetTable(String TableName)
        {
            return this.Query("select * from " + TableName, TableName);
        }

        public DataTable Query(String SQL,String TableName = "table")
        {
            using (SQLiteDataAdapter adp = new SQLiteDataAdapter(SQL, this.conn))
            {
                DataSet dst = new DataSet();
                adp.Fill(dst, TableName);
                return dst.Tables[TableName];
            }
        }

    }
}
