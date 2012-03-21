using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace MessageServices.MailService
{
    public class MailHelper
    {
        /// <summary>
        /// Replacing Values
        /// </summary>
        /// <param name="TextValue"></param>
        /// <param name="objDt"></param>
        /// <returns></returns>
        public static string StringReplace(string TextValue,Dictionary<string,string> objDt )
        {
            if (string.IsNullOrEmpty(TextValue) || objDt != null)
                return TextValue;
            string TempBody = string.Empty;
            foreach (KeyValuePair<string, string> item in objDt)
            {
                TextValue = TextValue.Replace(item.Key, item.Value);
            }
            return TextValue;
        }

        /// <summary>
        /// Sends an mail message
        /// </summary>
        /// <param name="from">Sender address</param>
        /// <param name="to">Recepient address</param>
        /// <param name="bcc">Bcc recepient</param>
        /// <param name="cc">Cc recepient</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        public static void SendMailMessage(string from, string to, string bcc, string cc, string subject, string body)
        {
            // Instantiate a new instance of MailMessage
            MailMessage mMailMessage = new MailMessage();

            // Set the sender address of the mail message
            mMailMessage.From = new MailAddress(from);
            // Set the recepient address of the mail message
            mMailMessage.To.Add(new MailAddress(to));

            // Check if the bcc value is null or an empty string
            if ((bcc != null) && (bcc != string.Empty))
            {
                // Set the Bcc address of the mail message
                mMailMessage.Bcc.Add(new MailAddress(bcc));
            }      // Check if the cc value is null or an empty value
            if ((cc != null) && (cc != string.Empty))
            {
                // Set the CC address of the mail message
                mMailMessage.CC.Add(new MailAddress(cc));
            }       // Set the subject of the mail message

            mMailMessage.Subject = subject;
            // Set the body of the mail message
            mMailMessage.Body = body;

            // Set the format of the mail message body as HTML
            mMailMessage.IsBodyHtml = true;
            // Set the priority of the mail message to normal
            mMailMessage.Priority = MailPriority.Normal;

            // Instantiate a new instance of SmtpClient
            SmtpClient mSmtpClient = new SmtpClient();
            // Send the mail message

            mSmtpClient.Host = ConfigurationSettings.AppSettings["MailHost"];
            if (ConfigurationSettings.AppSettings["IsPort"].ToString() == "1")
                mSmtpClient.Port = int.Parse(ConfigurationSettings.AppSettings["Port"].ToString());

            mSmtpClient.UseDefaultCredentials = false;
            mSmtpClient.Credentials = new System.Net.NetworkCredential
            (ConfigurationSettings.AppSettings["MailAdminEmail"].ToString(), ConfigurationSettings.AppSettings["MailAdminPassword"]);
            mSmtpClient.EnableSsl = true;

            mSmtpClient.Send(mMailMessage);
        }


        /// <summary>
        /// Sends an mail message
        /// </summary>
        /// <param name="from">Sender address</param>
        /// <param name="to">Recepient address</param>
        /// <param name="bcc">Bcc recepient</param>
        /// <param name="cc">Cc recepient</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        public static void SendMailMessage(string from, string to, string bcc, string cc,
                string subject, string body, Dictionary<string, string> objBodyDic, Dictionary<string, string> objSubjDic)
        {
            // Instantiate a new instance of MailMessage
            MailMessage mMailMessage = new MailMessage();

            // Set the sender address of the mail message
            mMailMessage.From = new MailAddress(from);
            // Set the recepient address of the mail message
            mMailMessage.To.Add(new MailAddress(to));

            // Check if the bcc value is null or an empty string
            if ((bcc != null) && (bcc != string.Empty))
            {
                // Set the Bcc address of the mail message
                mMailMessage.Bcc.Add(new MailAddress(bcc));
            }      // Check if the cc value is null or an empty value
            if ((cc != null) && (cc != string.Empty))
            {
                // Set the CC address of the mail message
                mMailMessage.CC.Add(new MailAddress(cc));
            }       // Set the subject of the mail message

            subject = StringReplace(subject, objSubjDic);
            mMailMessage.Subject = subject;
            // Set the body of the mail message

            body = StringReplace(body, objBodyDic);

            mMailMessage.Body = body;

            // Set the format of the mail message body as HTML
            mMailMessage.IsBodyHtml = true;
            // Set the priority of the mail message to normal
            mMailMessage.Priority = MailPriority.Normal;

            // Instantiate a new instance of SmtpClient
            SmtpClient mSmtpClient = new SmtpClient();
            // Send the mail message

            mSmtpClient.Host = ConfigurationSettings.AppSettings["MailHost"];
            if (ConfigurationSettings.AppSettings["IsPort"].ToString() == "1")
                mSmtpClient.Port = int.Parse(ConfigurationSettings.AppSettings["Port"].ToString());

            mSmtpClient.UseDefaultCredentials = false;
            mSmtpClient.Credentials = new System.Net.NetworkCredential
            (ConfigurationSettings.AppSettings["MailAdminEmail"].ToString(), ConfigurationSettings.AppSettings["MailAdminPassword"]);
            mSmtpClient.EnableSsl = true;

            mSmtpClient.Send(mMailMessage);
        }

        /// <summary>
        /// Sends an mail message
        /// </summary>
        /// <param name="from">Sender address</param>
        /// <param name="to">Recepient address</param>
        /// <param name="bcc">Bcc recepient</param>
        /// <param name="cc">Cc recepient</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        public static void SendMailMessage(string from, string to,
                string subject, string body, Dictionary<string, string> objBodyDic, Dictionary<string, string> objSubjDic)
        {
            // Instantiate a new instance of MailMessage
            MailMessage mMailMessage = new MailMessage();

            // Set the sender address of the mail message
            mMailMessage.From = new MailAddress(from);
            // Set the recepient address of the mail message
            mMailMessage.To.Add(new MailAddress(to));

            subject = StringReplace(subject, objSubjDic);
            mMailMessage.Subject = subject;
            // Set the body of the mail message

            body = StringReplace(body, objBodyDic);

            mMailMessage.Body = body;

            // Set the format of the mail message body as HTML
            mMailMessage.IsBodyHtml = true;
            // Set the priority of the mail message to normal
            mMailMessage.Priority = MailPriority.Normal;

            // Instantiate a new instance of SmtpClient
            SmtpClient mSmtpClient = new SmtpClient();
            // Send the mail message

            mSmtpClient.Host = ConfigurationSettings.AppSettings["MailHost"];
            if (ConfigurationSettings.AppSettings["IsPort"].ToString() == "1")
                mSmtpClient.Port = int.Parse(ConfigurationSettings.AppSettings["Port"].ToString());

            mSmtpClient.UseDefaultCredentials = false;
            mSmtpClient.Credentials = new System.Net.NetworkCredential
            (ConfigurationSettings.AppSettings["MailAdminEmail"].ToString(), ConfigurationSettings.AppSettings["MailAdminPassword"]);
            mSmtpClient.EnableSsl = true;

            mSmtpClient.Send(mMailMessage);
        }

        /// <summary>
        /// Sends an mail message
        /// </summary>
        /// <param name="from">Sender address</param>
        /// <param name="to">Recepient address</param>
        /// <param name="bcc">Bcc recepient</param>
        /// <param name="cc">Cc recepient</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        public static void SendMailMessage(string from, string to,
                string subject, string body)
        {
            // Instantiate a new instance of MailMessage
            MailMessage mMailMessage = new MailMessage();

            // Set the sender address of the mail message
            mMailMessage.From = new MailAddress(from);
            // Set the recepient address of the mail message
            mMailMessage.To.Add(new MailAddress(to));

            mMailMessage.Subject = subject;
            // Set the body of the mail message

            mMailMessage.Body = body;

            // Set the format of the mail message body as HTML
            mMailMessage.IsBodyHtml = true;
            // Set the priority of the mail message to normal
            mMailMessage.Priority = MailPriority.Normal;

            // Instantiate a new instance of SmtpClient
            SmtpClient mSmtpClient = new SmtpClient();
            // Send the mail message

            mSmtpClient.Host = ConfigurationSettings.AppSettings["MailHost"];
            if (ConfigurationSettings.AppSettings["IsPort"].ToString() == "1")
                mSmtpClient.Port = int.Parse(ConfigurationSettings.AppSettings["Port"].ToString());

            mSmtpClient.UseDefaultCredentials = false;
            mSmtpClient.Credentials = new System.Net.NetworkCredential
            (ConfigurationSettings.AppSettings["MailAdminEmail"].ToString(), ConfigurationSettings.AppSettings["MailAdminPassword"]);
            mSmtpClient.EnableSsl = true;

            mSmtpClient.Send(mMailMessage);
        }
    }
}
