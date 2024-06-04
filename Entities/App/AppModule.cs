using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Data.Entities.App
{
    public partial class AppModule
    {
        public AppModule()
        {
            AppPrivileges = new HashSet<AppPrivilege>();
        }

        public int IdModule { get; set; }
        public int IdApplication { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int NumOrder { get; set; }
        public bool Status { get; set; }

        public virtual AppApplication IdApplicationNavigation { get; set; }
        public virtual ICollection<AppPrivilege> AppPrivileges { get; set; }
    }
}
