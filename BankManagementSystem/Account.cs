using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;

/*  
    The account class encapsulates the functionality of a bank account. It has attributes that define it by the first name, last name etc..
    and class methods that are used on deposits, withdrawals, account deletion, etc. It contains the methods that send out emails on account
    creation and when a bank statement is requested. It has all the file reading and file writing functionality needed.
 */

namespace BankManagementSystem
{
    class Account
    {
        public String FirstName;
        public String LastName;
        public String Address;
        public int Phone;
        public String Email;
        public int AccountNo;
        public int Balance;

        public Account(String firstName, String lastName, String address, int phone, String email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
            Email = email;
        }

        public Account()
        {
            
        }

        public int CreateAccount()
        {
            int accountNo = GenerateRandom();

            AccountNo = accountNo;

            Balance = 200;

            string[] lines = {AccountNo.ToString(), Balance.ToString(), FirstName, LastName, Address, Phone.ToString(), Email };

            using StreamWriter file = new StreamWriter(accountNo + ".txt");

            foreach (string line in lines)
            {
                file.WriteLine(line);
            }

            file.Close();

            EmailDetails(accountNo);

            return accountNo;
        }

        private int GenerateRandom()
        {
            Random rd = new Random();
            int rand_num = rd.Next(100000, 999999); // 6 digits

            return rand_num;
        }

        public void EmailDetails(int accountNo)
        {
            //netdottest15@gmail.com
            //subject256

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential("netdottest15@gmail.com", "subject256"),
                EnableSsl = true,
            };

            try
            {
                smtpClient.Send("netdottest15@gmail.com", Email, "Your account number: " + accountNo,
                "Account no: " + accountNo + "\nBalance: $" + Balance + "\nFirst name: " + FirstName + "\nLast name: " + LastName + "\nAddress: " + Address + "\nPhone: "
                + Phone.ToString() + "\nEmail: " + Email);
            }
            catch (SmtpException e)
            {
                Console.WriteLine("Error: {0}", e.StatusCode);
            }

        }

        public void DeleteAccount(int accountNo)
        {
            File.Delete(accountNo + ".txt");
        }

        public String SearchAccount(ref int sCursorX, ref int sCursorY)
        {
            Console.SetCursorPosition(sCursorY, sCursorX);
            string saccount = Console.ReadLine();
            int account;
            bool success = int.TryParse(saccount, out account);

            while (!success || saccount.Length > 10)
            {
                Console.SetCursorPosition(sCursorY, sCursorX);
                Console.Write(new String(' ', saccount.Length));
                Console.SetCursorPosition(sCursorY, sCursorX);
                saccount = Console.ReadLine();
                success = int.TryParse(saccount, out account);
            }

            string file;

            try
            {
                file = File.ReadAllText(account + ".txt");

                readFile(account + ".txt");

                AccountNo = account;

                return "success";
            }
            catch (IOException e)
            {
                //Console.WriteLine("The file could not be read.");
                //Console.WriteLine(e.Message);
                Console.SetCursorPosition(sCursorY, sCursorX);
                Console.Write(new String(' ', saccount.Length));
                Console.SetCursorPosition(sCursorY, sCursorX);

                string stringError = "File not found";
                return stringError;
            }
        }

        public void DepositAccount(ref int CursorX, ref int CursorY)
        {
            Console.SetCursorPosition(CursorY, CursorX);
            int amount = Convert.ToInt32(Console.ReadLine());
            writeFile(amount);
        }

        public void WithdrawAccount(ref int CursorX, ref int CursorY)
        {
            Console.SetCursorPosition(CursorY, CursorX);
            int amount = Convert.ToInt32(Console.ReadLine());
            writeFile(-amount);
        }

        private void writeFile(int amount)
        {
            int newAmount = this.Balance + amount;
            string text = File.ReadAllText(this.AccountNo + ".txt");
            text = text.Replace(this.Balance.ToString(), newAmount.ToString());
            File.WriteAllText(this.AccountNo + ".txt", text);
        }

        public void readFile(string file)
        {
            int counter = 0;

            string fname = "";
            string lname = "";
            string address = "";
            string ph = "";
            string email = "";
            string accountNo = "";
            string balance = "";

            var lines = File.ReadLines(file);

            foreach(var line in lines)
            {
                switch (counter)
                {
                    case 0:
                        accountNo = line;
                        break;
                    case 1:
                        balance = line;
                        break;
                    case 2:
                        fname = line;
                        break;
                    case 3:
                        lname = line;
                        break;
                    case 4:
                        address = line;
                        break;
                    case 5:
                        ph = line;
                        break;
                    case 6:
                        email = line;
                        break;
                } 
                counter++;
            }
            FirstName = fname;
            LastName = lname;
            Address = address;
            Phone = int.Parse(ph);
            Email = email;
            AccountNo = Convert.ToInt32(accountNo);
            Balance = Convert.ToInt32(balance);
        }
    }
}
