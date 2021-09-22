using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Mail;

namespace BankManagementSystem
{
    class Account
    {
        private String FirstName;
        private String LastName;
        private String Address;
        private String Phone;
        private String Email;


        public Account(String firstName, String lastName, String address, String phone, String email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
            Email = email;
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

            smtpClient.Send("netdottest15@gmail.com", Email, "Your new account number: "+accountNo,
                "First name: " + FirstName + "\nLast name: " + LastName + "\nAddress: "+ Address + "\nPhone: "
                + Phone + "\nEmail: "+Email);
        }
    }
}
