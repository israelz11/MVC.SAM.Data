using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Data.Entities.App
{
    public partial class AppApplication
    {
        public AppApplication()
        {
            AppApplicationsPeople = new HashSet<AppApplicationsPerson>();
            AppModules = new HashSet<AppModule>();
            AppRules = new HashSet<AppRule>();
        }

        public int IdApplication { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumOrder { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public bool IsOnline { get; set; }
        public string OfflineMessage { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<AppApplicationsPerson> AppApplicationsPeople { get; set; }
        public virtual ICollection<AppModule> AppModules { get; set; }
        public virtual ICollection<AppRule> AppRules { get; set; }
    }
}
