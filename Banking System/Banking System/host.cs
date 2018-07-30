using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    class host
    {
        public static void Main()
        {
            buisnessLogic Customer = new buisnessLogic();
            int haveAccount;
            int frame;
            Console.WriteLine("Enter 1 To Use ADO .Net Framework or 2 To Use Entity Framework");
            frame = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 1 To Add New Account Or 2 If Your Account Exist");
            haveAccount = Convert.ToInt32(Console.ReadLine());
            if (haveAccount == 1)
            {
                int acc_no = Customer.addAccount(frame);
                int wantToContinue = 1;
                while (wantToContinue == 1)
                {
                    int choice;
                    Console.WriteLine("Enter Your Choice");
                    Console.WriteLine("1 to Display Account Details");
                    Console.WriteLine("2 to Deposit Money");
                    Console.WriteLine("3 to Withdraw");
                    Console.WriteLine("4 to Calculate Interest");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {

                        case 1: Customer.displayAccountDetails(acc_no, frame);
                            break;

                        case 2: Customer.deposit(acc_no, frame);
                            break;

                        case 3: Customer.withdraw(acc_no, frame);
                            break;

                        case 4: Customer.calculateInterest(acc_no, frame);
                            break;
                    }
                    Console.WriteLine("If You Want To Continue Type 1 Else Type 0 To Exit");
                    wantToContinue = Convert.ToInt32(Console.ReadLine());
                }
            }
            else
            {
                Console.WriteLine("Enter Your Account Number");
                int acc_no;
                acc_no = Convert.ToInt32(Console.ReadLine());
                int wantToContinue = 1;
                while (wantToContinue == 1)
                {
                    int choice;
                    Console.WriteLine("Enter Your Choice");
                    Console.WriteLine("1 to Display Account Details");
                    Console.WriteLine("2 to Deposit Money");
                    Console.WriteLine("3 to Withdraw");
                    Console.WriteLine("4 to Calculate Interest");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {

                        case 1: Customer.displayAccountDetails(acc_no, frame);
                            break;

                        case 2: Customer.deposit(acc_no, frame);
                            break;

                        case 3: Customer.withdraw(acc_no, frame);
                            break;

                        case 4: Customer.calculateInterest(acc_no, frame);
                            break;
                    }
                    Console.WriteLine("If You Want To Continue Type 1 Else Type 0 To Exit");
                    wantToContinue = Convert.ToInt32(Console.ReadLine());
                }
            }   
        }
    }
}
