using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Data.Entities.App
{
    public partial class VtDependency
    {
        public int Id { get; set; }
        public string ClvUniadm { get; set; }
        public string ClvDependencia { get; set; }
        public string Dependencia { get; set; }
        public string Funcionario { get; set; }
        public string Cargo { get; set; }
        public bool? Status { get; set; }
    }
}
