using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Mail;

namespace BankManagementSystem
{
    class Account
    {
        public String FirstName;
        public String LastName;
        public String Address;
        public String Phone;
        public String Email;


        public Account(String firstName, String lastName, String address, String phone, String email)
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

        public void CreateAccount()
        {
            string[] lines = { FirstName, LastName, Address, Phone, Email };

            int accountNo = GenerateRandom();

            using StreamWriter file = new StreamWriter(accountNo + ".txt");

            foreach (string line in lines)
            {
                file.WriteLine(line);
            }

            file.Close();

            EmailDetails(accountNo);
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

            smtpClient.Send("netdottest15@gmail.com", Email, "Your new account number: " + accountNo,
                "First name: " + FirstName + "\nLast name: " + LastName + "\nAddress: " + Address + "\nPhone: "
                + Phone + "\nEmail: " + Email);
        }

        public String SearchAccount(ref int sCursorX, ref int sCursorY)
        {
            Console.SetCursorPosition(sCursorY, sCursorX);
            int account = Convert.ToInt32(Console.ReadLine());

            string file;

            try
            {
                file = File.ReadAllText(account + ".txt");

                readFile(account + ".txt");

                return "success";
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read.");
                //Console.WriteLine(e.Message);

                string stringError = "File not found";
                return stringError;
            }
        }

        public void readFile(string file)
        {
            int counter = 0;

            string fname = "";
            string lname = "";
            string address = "";
            string ph = "";
            string email = "";

            var lines = File.ReadLines(file);

            foreach(var line in lines)
            {
                switch (counter)
                {
                    case 0:
                        fname = line;
                        break;
                    case 1:
                        lname = line;
                        break;
                    case 2:
                        address = line;
                        break;
                    case 3:
                        ph = line;
                        break;
                    case 4:
                        email = line;
                        break;
                } 
                counter++;
            }

            FirstName = fname;
            LastName = lname;
            Address = address;
            Phone = ph;
            Email = email;
        }
    }
}
