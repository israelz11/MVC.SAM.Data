using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Data.Entities.App
{
    public partial class VtPerson
    {
        public int IdPerson { get; set; }
        public int IdDependency { get; set; }
        public string ClvDependency { get; set; }
        public string DependencyName { get; set; }
        public int IdDepartment { get; set; }
        public string DepartmentName { get; set; }
        public int IdPosition { get; set; }
        public string PositionName { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Telephone { get; set; }
        public string Celphone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
    }
}
