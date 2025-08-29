using FerPROJ.Design.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public static class CEmailManager {
        public static async Task CreateEmailAndSendAsync(EmailDTO email) {
            if (email == null) {
                CDialogManager.Warning("Email is empty.", "Email Empty");
                return;
            }
            await SendEmailAsync(email);
        }
        private static async Task SendEmailAsync(EmailDTO email) {
            try {
                var middleWareEmail = new MiddlewareEmailDTO();
                var senderEmail = CEncryptionManager.DecryptText(middleWareEmail.EncryptedEmail);
                var senderPassword = CEncryptionManager.DecryptText(middleWareEmail.EncryptedPassword);
                //
                using (SmtpClient smtpClient = new SmtpClient(middleWareEmail.Host, middleWareEmail.Port)) {
                    //
                    smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    smtpClient.EnableSsl = true;
                    //
                    using (MailMessage mail = new MailMessage()) {
                        //
                        mail.From = new MailAddress(senderEmail, middleWareEmail.SenderName);
                        mail.To.Add(email.ReceiverEmail);
                        mail.Subject = email.Subject;
                        mail.IsBodyHtml = true;
                        mail.Body = GenerateBody(email.Header, email.ReceiverName, email.Description, email.Signature);
                        //
                        await smtpClient.SendMailAsync(mail);
                        // 
                        smtpClient.SendCompleted += (sender, e) => {
                            CDialogManager.Info("The email has been sent successfully.", "Sent Successfully");
                        };
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
        private static string GenerateBody(string header, string name, string description, string signature) {

            string formattedDescription = "<p>" + System.Net.WebUtility.HtmlEncode(description)
                                        .Replace("\\p", "</p><p>") // Paragraph break
                                        .Replace("\\n", "<br>")    // Line break
                                        + "</p>";
            return $@"
            <html>
                <style>
                    body {{
                        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                        background-color: #f0f0f0;
                    }}
                    .email-container {{
                        width: 793px; /* Bond paper width */
                        height: 1122px; /* Bond paper height */
                        background: #ffffff;
                        border-radius: 8px;
                        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                    }}
                    .content {{
                        font-size: 14px;
                        color: #333;
                        line-height: 1.6;
                    }}
                    .header {{
                        font-size: 18px;
                        font-weight: bold;
                    }}
                    .footer {{
                        font-size: 14px;
                        color: #888;
                    }}
                </style>
                <body>
                    <div class='email-container'>
                        <div class='content'>
                            <div class='header'>{WebUtility.HtmlEncode(header)}</div>
                            <p><strong>Dear {WebUtility.HtmlEncode(name)},</strong></p>
                            {formattedDescription}
                            <div class='footer'>
                                Thanks, <br>
                                {WebUtility.HtmlEncode(signature)}
                            </div>
                        </div>
                    </div>
                </body>
            </html>";
        }
    }
    public class EmailDTO {
        public string ReceiverName { get; set; }    
        public string ReceiverEmail { get; set; }
        public string Subject { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string Signature { get; set; }
    }
    public class MiddlewareEmailDTO {
        public string SenderName { get; set; } = "Blancia College Foundation";
        public string EncryptedEmail => "nNLr4u9051gEqbyLND0N5QvlNrRvHt2eHcDdHq6goqKGmkHQRe/a0dyHOckS8mGY";
        public string EncryptedPassword => "h7Du6M91YI5d8KJy+m1k5qbqrfEgNX3Lq5KSGAXAoxQ=";
        public string Host => "smtp.gmail.com";
        public int Port => 587;
    }
}
