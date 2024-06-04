using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Data.Entities.App
{
    public partial class AppLog
    {
        public AppLog()
        {
            AppHistories = new HashSet<AppHistory>();
        }

        public int IdLog { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AppHistory> AppHistories { get; set; }
    }
}
