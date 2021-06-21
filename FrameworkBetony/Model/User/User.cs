using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkBetony.Model
{
    class User
    {
        internal string nameField { get; set; }
        internal string FirstNameField { get; set; }
        internal string secondNameField { get; set; }
        internal string email { get; set; }
        internal string number { get; set; }
        // internal string Node { get; set; }
        internal string password { get; set; }
        internal string rePassword { get; set; }
        public Node NodeType { get; set; }
        public Role RoleType { get; set; }
        internal string delQuery { get; set; }



    }
}