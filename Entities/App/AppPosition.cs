using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Data.Entities.App
{
    public partial class AppPosition
    {
        public AppPosition()
        {
            AppPeople = new HashSet<AppPerson>();
        }

        public int IdPosition { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<AppPerson> AppPeople { get; set; }
    }
}
