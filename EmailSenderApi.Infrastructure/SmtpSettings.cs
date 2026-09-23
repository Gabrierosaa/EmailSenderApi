using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSenderApi.Infrastructure
{
    public class SmtpSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool UseSsl { get; set; }
        public string FromName { get; set; }
    }
}
