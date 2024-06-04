using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Data.Entities.App
{
    public partial class AppHistory
    {
        public int IdHistory { get; set; }
        public int IdLog { get; set; }
        public int IdPerson { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Ipclient { get; set; }
        public string HostName { get; set; }
        public string Description { get; set; }

        public virtual AppLog IdLogNavigation { get; set; }
        public virtual AppPerson IdPersonNavigation { get; set; }
    }
}
