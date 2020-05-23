using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi
{
    public class AppSettings
    {
        public string Secret { get; set; }      
        public string SqlServerHostName { get; set; }
        public string SqlServerPost { get; set; }
        public string SqlServerCatalog { get; set; }
        public string SqlServerUser { get; set; }
        public string SqlServerPassword { get; set; }
        public bool EnableSSL { get; set; }
        public string SmtpServer { get; set; }
        public string SmtpPort { get; set; }
        public string MailPassword { get; set; }
        public string FromMail { get; set; }
        public string AdminPassword { get; set; }
        public string SapServerIp { get; set; }
        public int SapDbServerType { get; set; }
        public string SapUserName { get; set; }
        public string SapPassword { get; set; }
        public string SapCompanyDb { get; set; }
    }
}
