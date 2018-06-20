namespace Ejyle.DevAccelerate.Core.Mail
{
    public class SmtpServerInfo
    {
        public string Host { get; set; }

        public string UserId { get; set; }

        public string Password { get; set; }

        public int? Port { get; set; }

        public string ApiKey { get; set; }

        public bool UseSsl { get; set; }
    }
}
