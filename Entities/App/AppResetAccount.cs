using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Data.Entities.App
{
    public partial class AppResetAccount
    {
        public int IdResetAccount { get; set; }
        public int IdPerson { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? ResetDate { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public bool Status { get; set; }

        public virtual AppPerson IdPersonNavigation { get; set; }
    }
}
