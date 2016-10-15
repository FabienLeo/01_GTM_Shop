
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net.Mail;
using System.Configuration;

namespace GTM_Shop.Models
{
    public class EMail
    {
        private String strToAddress;  /* To Address */
        private String strToSmtpClient;  /* Smtp server name*/
        private bool BoolEnableSsl;  /* enable SSL */
        private String strPort;  /* Smtp port number */
        private string strUserId;  /* Mail User id*/
        private string strPasseword;  /* Mail User password */

        /*Initialisation of the variables*/
        private void InitMail()
        {

            strToSmtpClient = ConfigurationManager.AppSettings.Get("SmtpClient");
            BoolEnableSsl = (ConfigurationManager.AppSettings.Get("EnableSSL").ToUpper() == "YES") ? true : false;
            strPort = ConfigurationManager.AppSettings.Get("SMTPPort");
            strUserId = ConfigurationManager.AppSettings.Get("UserID");
            strPasseword = ConfigurationManager.AppSettings.Get("Password");
            strToAddress = System.Configuration.ConfigurationManager.AppSettings.Get("ToAddress");
        }

        public void SendMail(String FromAdresse, String Subject, String message, String name)
        {
            InitMail();
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(FromAdresse, name);
                msg.To.Add(strToAddress);
                msg.Subject = Subject + " " + FromAdresse;
                msg.Body = "yourmessagebody";
                msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("monhost.com");
                smtp.EnableSsl = BoolEnableSsl;
                smtp.Port = Convert.ToInt32(strPort);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(strUserId, strPasseword);
                smtp.Send(msg);
            }
            catch (SmtpFailedRecipientsException)
            {
                //the exeception will be caught in the controller
            }
        }
    }
}