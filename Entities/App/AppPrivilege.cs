using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Data.Entities.App
{
    public partial class AppPrivilege
    {
        public AppPrivilege()
        {
            AppPrivilegesRules = new HashSet<AppPrivilegesRule>();
        }

        public int IdPrivilege { get; set; }
        public int IdModule { get; set; }
        public int NumOrder { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Divider { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public string Rules { get; set; }
        public bool Status { get; set; }

        public virtual AppModule IdModuleNavigation { get; set; }
        public virtual ICollection<AppPrivilegesRule> AppPrivilegesRules { get; set; }
    }
}
