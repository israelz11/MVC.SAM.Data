using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Data.Entities.App
{
    public partial class VtPrivilegesPerson
    {
        public int IdPrivilege { get; set; }
        public int IdModule { get; set; }
        public string ModuleName { get; set; }
        public string ImageModule { get; set; }
        public int NomOrderModule { get; set; }
        public bool StatusModule { get; set; }
        public int IdRule { get; set; }
        public string RuleName { get; set; }
        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Email { get; set; }
        public int NumOrder { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Divider { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public string Rules { get; set; }
        public int IdApplication { get; set; }
        public string ApplicationName { get; set; }
        public bool Status { get; set; }
    }
}
