using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Dtos.Emails
{
    public class EmailSettings
    {
        public RegisterVarificationEmail RegisterVarificationEmail { get; set; }
    }

    public class RegisterVarificationEmail
    {
        public string NoReplyEmail { get; set; }
        public string ServerName { get; set; }
        public int ServerPort { get; set; }
        public string EmailUser { get; set; }
        public string EmailPassword { get; set; }

    }


}
