﻿namespace Promact.Oauth.Server.Models
{
    public class AppSettings
    {
        public string From { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Host { get; set; }

        public string Port { get; set; }

        public bool SslOnConnect { get; set; }

        public string SendGridApi { get; set; }
    }
}
