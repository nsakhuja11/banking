using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    class EntityDatabase
    {
        RecordEntities record = new RecordEntities();
        BankRecord tableRecords = new BankRecord();

        public void Insert(string type, string name, int account_no, int balance)
        {
            tableRecords.id = account_no;
            tableRecords.name = name;
            tableRecords.balance = balance;
            tableRecords.type = type;
            record.BankRecords.Add(tableRecords);
            record.SaveChanges();
        }

        public void Display(int acc_no)
        {
            Console.WriteLine("Account Number : {0}", record.BankRecords.Find(acc_no).id);
            Console.WriteLine("Account Holder Name : {0}", record.BankRecords.Find(acc_no).name);
            Console.WriteLine("Account Balance : {0}", record.BankRecords.Find(acc_no).balance);
            Console.WriteLine("Account Type : {0}", record.BankRecords.Find(acc_no).type);
        }

        public int RetreiveBalance(int acc_no)
        {
            return Convert.ToInt32(record.BankRecords.Find(acc_no).balance);
        }

        public string RetreiveType(int acc_no)
        {
            return (string)record.BankRecords.Find(acc_no).type;
        }

        public void Update(int acc_no, int balance)
        {
            record.BankRecords.Find(acc_no).balance = balance;
            record.SaveChanges();
        }
    }
}
