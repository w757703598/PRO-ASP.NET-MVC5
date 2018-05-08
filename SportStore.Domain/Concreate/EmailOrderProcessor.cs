using SportStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportStore.Domain.Entities;
using System.Net.Mail;
using System.Net;

namespace SportStore.Domain.Concreate
{
    public class EmailSettings
    {
        public string MailToAddress = "orders@example.com";
        public string MailFromAddress = "sportsstore@example.com";
        public bool UserSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"d:\sports_store_emails";
    }
    public class EmailOrderProcessor : IOrderProcessor
    {
        public EmailSettings emailSettings;
        public EmailOrderProcessor( EmailSettings settings )
        {
            emailSettings = settings;
        }
        public void ProcessOrder( Cart cart, ShippingDetails shippingDetails )
        {
            using (var smtpClient=new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UserSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);
                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }
                StringBuilder body = new StringBuilder().AppendLine("A new order has been submitted").AppendLine("---").AppendLine("Items:");
                foreach (var line in cart.Line)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0}x{1}(subtotal:{2:c}", line.Quantity, line.Product.Name, subtotal);

                }
                body.AppendFormat("Total order value:{0:c}", cart.ComputeTotalValue()).AppendLine("---").AppendLine("Ship to:").AppendLine(shippingDetails.Name).AppendLine(shippingDetails.line1 ?? "").AppendLine(shippingDetails.line2 ?? "").AppendLine(shippingDetails.line3 ?? "").AppendLine(shippingDetails.City).AppendLine(shippingDetails.State ?? "").AppendLine(shippingDetails.Country).AppendLine(shippingDetails.Zip).AppendLine("---").AppendFormat("Gift wrap:{0}", shippingDetails.GiftWrap ? "Yes" : "No");
                MailMessage mailmessage = new MailMessage(emailSettings.MailFromAddress, emailSettings.MailToAddress, "new order submitted!", body.ToString());
                if (emailSettings.WriteAsFile)
                {
                    mailmessage.BodyEncoding = Encoding.ASCII;
                }
                smtpClient.Send(mailmessage);
            }
        }
    }
}
