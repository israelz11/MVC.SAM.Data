using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Data.Entities.App
{
    public partial class AppRulesPerson
    {
        public int IdRule { get; set; }
        public int IdPerson { get; set; }

        public virtual AppPerson IdPersonNavigation { get; set; }
        public virtual AppRule IdRuleNavigation { get; set; }
    }
}
