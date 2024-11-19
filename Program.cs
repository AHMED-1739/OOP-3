using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3_Q2
{
    class UserAccount
    {
        private string User_Name, User_Password, User_Email;
        public string UserName => User_Name;
        public string UserPassword => User_Password;
        public string UserEmail => User_Email;
        //this constructor to create new Account
        public UserAccount(string User_Name, string User_Password, string User_Email)
        {
            this.User_Name = User_Name;
            this.User_Password = User_Password;
            this.User_Email = User_Email;
        }
        //copy constructor
        public UserAccount(UserAccount Account)
        {
            User_Name=Account.UserName;
            User_Email = Account.UserEmail;
            User_Password =Account.UserPassword;
        }
        // to change the password 
        public void Change_Password(string new_pass) => this.User_Password = new_pass;
        //Check if the account existing
        static public UserAccount Check_Account(UserAccount account, string pass, string userName)
        {
            if (account.UserPassword == pass && account.UserName == userName)
                 return account;
                 return null;
        }
    }
    internal class Program
    {
        //I avoid putting conditions like checking the length of
        //the username and password and other things
        //because the current code is sufficient for the question.
        //and it will be a long code.
        static void Main(string[] args)
        {
            ArrayList Account_List = new ArrayList();
            // create some account
            char c = '1';
            for (int i = 0; i < 5; i++)
            {
                Account_List.Add(new UserAccount("Test_Name" + c, "Test_Pass" + c, $" Test_Email{c}@email.com"));
                 c++;
            }
            string userName, pass;
            while (true)
            {
                Console.WriteLine("Enter information to verify");
                Console.Write("User Name: ");
                 userName = Console.ReadLine();
                Console.Write("Password: ");
                 pass = Console.ReadLine();
                if (userName == "" || pass == "")
                {
                    Console.WriteLine("Username or password cannot be empty.");
                }
                else break;
            }
            //this object will hold thee user account to handle its data
            //(if both the password and the username match the information of one of the accounts.)
            UserAccount Correct_Account=null;

            for (int i = 0; i < Account_List.Count; i++)
            {
                UserAccount Account = (UserAccount)Account_List[i];
                   UserAccount temp=UserAccount.Check_Account(Account, pass, userName);
                if (temp != null)
                {
                    Console.WriteLine("Information verified.\n");
                    Correct_Account = new UserAccount(temp);
                    break;
                }
                if (i == Account_List.Count - 1)
                { Console.WriteLine("The information is invalid"); break; }
            }
            if (Correct_Account != null)
            {
                while (true)
                {
                    Console.WriteLine("Do you want to change your password ? yes or no");
                    string input = Console.ReadLine();
                    input = input.ToLower();
                    if (input == "yes")
                    {
                        Console.Write("Enter the new password: ");
                        string new_pass = Console.ReadLine();
                        Correct_Account.Change_Password(new_pass);
                    }
                    else if (input == "no")
                        Console.WriteLine("OK");
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("choss yes or no!");
                  
                        continue;
                    }

                    Console.WriteLine("Information after change:");
                    Console.WriteLine("Name: {0}\nPassword:{1}", Correct_Account.UserName, Correct_Account.UserPassword);
                    break;
                }
            }
        }
    }
}
