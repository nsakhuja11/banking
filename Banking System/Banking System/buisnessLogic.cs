using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    class buisnessLogic
    {
        public string type;
        public string name;
        public int accountNo;
        public int balance;
        Database ado = new Database();
        EntityDatabase entity = new EntityDatabase();
        public int addAccount(int frame)
        {
            Console.WriteLine("Enter Account Type : Saving | Current | DMAT");
            type = Console.ReadLine();
            Console.WriteLine("Enter Customer Name");
            name = Console.ReadLine();
            Console.WriteLine("Enter Account Number");
            accountNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Initial Account Balance");
            balance = Convert.ToInt32(Console.ReadLine());
            if (frame == 1)
            {
                ado.Insert(type, name, accountNo, balance);
            }
            else
            {
                entity.Insert(type, name, accountNo, balance);
            }
            return accountNo;
        }
        
        public void deposit(int acc_no, int frame)
        {
            if (frame == 1)
            {
                balance = ado.RetreiveBalance(acc_no);
            }
            else
            {
                balance = entity.RetreiveBalance(acc_no);
            }
            int amount;
            Console.WriteLine("Enter Amount to Deposit");
            amount = Convert.ToInt32(Console.ReadLine());
            balance=balance+amount;
            Console.WriteLine("Updated Balance = {0}", balance);
            if (frame == 1)
            {
                ado.Update(acc_no, balance);
            }
            else
            {
                entity.Update(acc_no, balance);
            }
        }
        public void displayAccountDetails(int acc_no, int frame)
        {
            if (frame == 1)
            {
                ado.Display(acc_no);
            }
            else
            {
                entity.Display(acc_no);
            }
        }

        public void withdraw(int acc_no,int frame)
        {
            int amount;
            Console.WriteLine("Enter Amount to Withdraw");
            amount = Convert.ToInt32(Console.ReadLine());
            if (frame == 1)
            {
                balance = ado.RetreiveBalance(acc_no);
                type = ado.RetreiveType(acc_no);
                type = type.Trim();
            }
            else
            {
                balance = entity.RetreiveBalance(acc_no);
                type = entity.RetreiveType(acc_no);
                type = type.Trim();
            }
            if (type == "Saving")
            {
                if ((balance - amount) < 1000)
                {
                    Console.WriteLine("You can not Withdraw");
                }
                else
                {
                    balance = balance - amount;
                }
            }
            else if (type == "Current")
            {
                if ((balance - amount) < 0)
                {
                    Console.WriteLine("You can not Withdraw");
                }
                else
                {
                    balance = balance - amount;
                }
            }
            else if (type == "DMAT")
            {
                if ((balance - amount) < -10000)
                {
                    Console.WriteLine("You can not Withdraw");
                }
                else
                {
                    balance = balance - amount;
                }
            }
            Console.WriteLine("Updated Balance = {0}", balance);
            if (frame == 1)
            {
                ado.Update(acc_no, balance);
            }
            else
            {
                entity.Update(acc_no, balance);
            }
        }

        public void calculateInterest(int acc_no, int frame)
        {
            if (frame == 1)
            {
                balance = ado.RetreiveBalance(acc_no);
                type = ado.RetreiveType(acc_no);
                type = type.Trim();
            }
            else
            {
                balance = entity.RetreiveBalance(acc_no);
                type = entity.RetreiveType(acc_no);
                type = type.Trim();
            }
            if (type == "Saving")
            {
                balance = (balance / 100) * 4;
            }
            else if (type == "Current")
            {
                balance = balance / 100;
            }
            else if (type == "DMAT")
            {
                balance = 0;
            }
            Console.WriteLine("Interest = {0}", balance);
        }
    }

}
