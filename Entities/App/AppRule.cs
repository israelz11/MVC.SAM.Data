using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Data.Entities.App
{
    public partial class AppRule
    {
        public AppRule()
        {
            AppPrivilegesRules = new HashSet<AppPrivilegesRule>();
            AppRulesPeople = new HashSet<AppRulesPerson>();
        }

        public int IdRule { get; set; }
        public int IdApplication { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public virtual AppApplication IdApplicationNavigation { get; set; }
        public virtual ICollection<AppPrivilegesRule> AppPrivilegesRules { get; set; }
        public virtual ICollection<AppRulesPerson> AppRulesPeople { get; set; }
    }
}
