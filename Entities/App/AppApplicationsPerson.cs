using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Data.Entities.App
{
    public partial class AppApplicationsPerson
    {
        public int IdApplication { get; set; }
        public int IdPerson { get; set; }

        public virtual AppApplication IdApplicationNavigation { get; set; }
        public virtual AppPerson IdPersonNavigation { get; set; }
    }
}
