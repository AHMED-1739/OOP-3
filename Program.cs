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
        public UserAccount(UserAccount Account)
        {
            User_Name=Account.UserName;
            User_Email = Account.UserEmail;
            User_Password =Account.UserPassword;
        }
        public void Change_Password(string new_pass)
        {
            this.User_Password = new_pass;
        }
        static public UserAccount Check_Account(UserAccount account, string pass, string userName)
        {
            if (account.UserPassword == pass && account.UserName == userName)
                 return account;

                return null;
        }
        

    }
    internal class Program
    {
  
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
            Console.WriteLine("Enter information to verify");
            Console.Write("User Name: ");
            string userName = Console.ReadLine();
            Console.Write("Password: ");
            string pass= Console.ReadLine();

            UserAccount UserAccount=null;

            for (int i = 0; i < Account_List.Count; i++)
            {
                UserAccount Account = (UserAccount)Account_List[i];
                if (UserAccount.Check_Account(Account, pass, userName) != null)
                {
                    Console.WriteLine("Information verified.\n");
                    UserAccount = new UserAccount(UserAccount.Check_Account(Account,pass,userName));
                    break;
                } 
                if(i==Account_List.Count - 1)
                    Console.WriteLine("The information is invalid");
            }
            if (UserAccount != null)
            {
                Console.WriteLine("Do you want to change your password ? yes or no");
              input: string input = Console.ReadLine();
                input = input.ToLower();
                if (input == "yes")
                {
                    Console.Write("Enter the new password: ");
                    string new_pass = Console.ReadLine();
                    UserAccount.Change_Password(new_pass);
                }
                else if (input == "no")
                    Console.WriteLine("OK");
                else 
                { 
                    Console.WriteLine("choss yes or no!");
                    goto input;
                }
            }
            Console.WriteLine("Information after change:");
            Console.WriteLine("Name: {0}\nPassword:{1}",UserAccount.UserName,UserAccount.UserPassword);
        }
    }
}
