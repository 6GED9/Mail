using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace NetConsoleApp
{
    public class Registr
    {
        int code;
        string mail;
        public void Reg()
        {
            Console.Write("Введите логин: ");
            mail = Console.ReadLine();
            Console.Write("Введите пароль: ");
            Console.ReadLine();
            Send();
            CheckCode();
        }
        private void Send()
        {
            Random random = new Random();
            MailAddress from = new MailAddress("vlad.rez2022@gmail.com", "Register " + DateTime.Now);
            MailAddress to = new MailAddress(mail);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Autorization";
            code = random.Next(100000, 999999);
            m.Body = code.ToString();
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("vlad.rez2022@gmail.com", "qzurxivvxjsepcmz");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        private void CheckCode()
        {
            while (true)
            {
                Console.Write("Введите код: ");
                if (Console.ReadLine() == code.ToString())
                {
                    Console.WriteLine("Авторизация успешна");
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный код");
                    Send();
                }
            }
            Console.Read();
        }
    }
}
