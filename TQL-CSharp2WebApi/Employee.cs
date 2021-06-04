using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TQL_CSharp2WebApi {
    class Employee {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool IsManager { get; set; }

        public Employee() { }
    }
}
