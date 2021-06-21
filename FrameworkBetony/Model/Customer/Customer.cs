using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkBetony.Model
{
    class Customer
    {
        public string nip { get; set; }
        internal string companyName { get; set; }
        internal string shortCompanyName { get; set; }
        internal string city { get; set; }
        internal string address { get; set; }
        internal string postalCode { get; set; }
        internal string number { get; set; }
        internal string merchantLimit { get; set; }
        public Person PersonType { get; set; }
        internal string UniqueShortcut { get; set; }
    }
}