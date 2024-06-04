using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Data.Entities.App
{
    public partial class AppPerson
    {
        public AppPerson()
        {
            AppApplicationsPeople = new HashSet<AppApplicationsPerson>();
            AppHistories = new HashSet<AppHistory>();
            AppResetAccounts = new HashSet<AppResetAccount>();
            AppRulesPeople = new HashSet<AppRulesPerson>();
        }

        public int IdPerson { get; set; }
        public int IdDependency { get; set; }
        public int IdDepartment { get; set; }
        public int IdPosition { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Telephone { get; set; }
        public string Celphone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PwdTemp { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }

        public virtual AppDepartment IdDepartmentNavigation { get; set; }
        public virtual AppPosition IdPositionNavigation { get; set; }
        public virtual ICollection<AppApplicationsPerson> AppApplicationsPeople { get; set; }
        public virtual ICollection<AppHistory> AppHistories { get; set; }
        public virtual ICollection<AppResetAccount> AppResetAccounts { get; set; }
        public virtual ICollection<AppRulesPerson> AppRulesPeople { get; set; }
    }
}
