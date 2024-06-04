using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Data.Entities.App
{
    public partial class AppPrivilegesRule
    {
        public int IdRule { get; set; }
        public int IdPrivilege { get; set; }

        public virtual AppPrivilege IdPrivilegeNavigation { get; set; }
        public virtual AppRule IdRuleNavigation { get; set; }
    }
}
