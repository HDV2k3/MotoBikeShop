using System.Net.Mail;
using System.Net;

namespace MotoBikeShop.Helpers
{
    public class SendMail
    {
        public static bool Send(string toEmail, string subject, string body)
        {
            try
            {
                string fromEmail = "dacviethuynh@gmail.com"; // Địa chỉ email của người gửi
                string password = "Viethuynh@#!2003"; // Mật khẩu email của người gửi

                SmtpClient smtpClient = new SmtpClient("smtp.example.com", 587); // Địa chỉ và cổng SMTP của nhà cung cấp email
                smtpClient.EnableSsl = true; // Sử dụng SSL để bảo mật kết nối
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromEmail, password);

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(fromEmail);
                mailMessage.To.Add(toEmail);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true; // Thiết lập kiểu nội dung HTML

                smtpClient.Send(mailMessage);

                return true; // Gửi email thành công
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ khi gửi email thất bại
                // Tùy theo yêu cầu của bạn, bạn có thể ghi log lỗi, hiển thị thông báo cho người dùng, hoặc xử lý theo cách khác.
                // Trong trường hợp này, chúng ta chỉ đơn giản trả về false để cho biết gửi email không thành công.
                return false;
            }
          
        }
    }
}
