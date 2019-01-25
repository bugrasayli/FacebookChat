using System;
using System.Data.SqlClient;

namespace Facebook
{
    public class Database
    {
        private string connectionString = @"Data Source=BUGRA\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True";
        private SqlConnection conn;
        private string insertCmd(string ID, string Name)
        {
            return "insert into Person(ID,Name) values('" + ID + "','" + Name + "')";
        }
        public Database()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }
        public int Insert(string ID, string Name)
        {
            string insert2 = "If Not Exists(select * from Person where ID='" + ID + "')" +
                "Begin " +
                "insert into Person(ID,Name) Values ('" + ID + "','" + Name + "')" +
                "End";
            SqlCommand cmd = new SqlCommand(insert2, conn);
            int count = cmd.ExecuteNonQuery();

            return count;
        }

        public int insertTime(person person)
        {
            Insert(person.ID, person.Name);
            string insertTime = "insert into time(ID,time) values('" + person.ID + "','" + DateTime.Now + "')";
            if(person.Situation == null)
            {

            }
            else if (person.Situation.Equals("Active now"))
            {
                SqlCommand cmd = new SqlCommand(insertTime, conn);
                cmd.ExecuteNonQuery();
            }


            return 0;
        }
    }
}
