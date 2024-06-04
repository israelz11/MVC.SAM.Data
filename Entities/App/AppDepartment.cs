using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Data.Entities.App
{
    public partial class AppDepartment
    {
        public AppDepartment()
        {
            AppPeople = new HashSet<AppPerson>();
        }

        public int IdDepartment { get; set; }
        public int IdDependency { get; set; }
        public int IdResposiblePerson { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<AppPerson> AppPeople { get; set; }
    }
}
