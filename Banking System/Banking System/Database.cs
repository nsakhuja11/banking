using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Banking_System
{
    class Database
    {
        SqlConnection con = new SqlConnection(@"Data Source=NIHIT-PC;Initial Catalog=Record;Integrated Security=True");
        public void Insert(string type,string name,int accountNo,int balance)
        {
            con.Open();
            string query="insert into BankRecord(id,name,balance,type) values (@id,@name,@bal,@type)";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@id", accountNo);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@bal", balance);
            cmd.Parameters.AddWithValue("@type", type);
            
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void Display(int acc_no)
        {
            con.Open();
            string query = "select * from BankRecord where id = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", acc_no);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Account Number : {0}", reader[0]);
                    Console.WriteLine("Account Holder Name : {0}", reader[1]);
                    Console.WriteLine("Account Balance : {0}", reader[2]);
                    Console.WriteLine("Account Type : {0}", reader[3]);
                }
            }
            con.Close();
            reader.Close();
        }

        public int RetreiveBalance(int acc_no)
        {
            con.Open();
            int bal = 0;
            string query = "select * from BankRecord where id = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", acc_no);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    bal = (Convert.ToInt32(reader[2]));
                    break;
                }
            }
            con.Close();
            reader.Close();
            return bal;
        }


        public string RetreiveType(int acc_no)
        {
            con.Open();
            string type="abc";
            string query = "select * from BankRecord where id = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", acc_no);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    type = (string)reader[3];
                }
            }
            con.Close();
            reader.Close();
            return type;
        }

        public void Update(int acc_no, int balance)
        {
            con.Open();
            string query = "update BankRecord set balance = @balance where id = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@balance", balance);
            cmd.Parameters.AddWithValue("@id", acc_no);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
