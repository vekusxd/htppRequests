using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace htppRequests
{
    internal class PhoneInfo
    {
        public int? Phone { get; set; }

        public Oper? Oper { get; set; }
        public Region? Region { get; set; }

        public override string ToString()
        {
            return $"{Phone}, {Oper.Name}, {Region.Okrug}";
        }

    }

    internal class Region
    {
        public string? Name { get; set;}
        public string? Okrug { get; set;}
    }

    internal class Oper
    {
        public string? Name { get; set;}
        public string? Brand { get; set; }
        public string? Url { get; set; }
    }
}
