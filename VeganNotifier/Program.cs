using MimeKit;
using VeganNotifier;

using MailKit.Net.Smtp;
using MailKit;

DateTime now = DateTime.Now;
now = now + TimeSpan.FromDays(1);

int[] r1 = LunarDateService.convertSolar2Lunar(now.Day, now.Month, now.Year, 7.0);

if (r1[0] == 1 || r1[0] == 15)
{
    var email = new MimeMessage();
    email.From.Add(new MailboxAddress("Ăn Chay Notification", "anh195001@gmail.com"));
    email.To.Add(new MailboxAddress("Quan Nguyen", "nguyenquan263@gmail.com"));
    email.To.Add(new MailboxAddress("Anh Nguyen", "anhng148@gmail.com"));

    email.Subject = "ĂN CHAY ĐÊ.";

    email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
    {
        Text = $"<b>Ngày mai {now.Day}/{now.Month}/{now.Year} tức {r1[0]}/{r1[1]}/{r1[2]} âm lịch, nhớ ăn chay!!!</b>"
    };

    using (var smtp = new SmtpClient())
    {
        smtp.Connect("smtp.gmail.com", 587, false);

        // Note: only needed if the SMTP server requires authentication

        smtp.Send(email);
        smtp.Disconnect(true);
    }
}