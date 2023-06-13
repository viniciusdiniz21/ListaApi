using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaApi.Ex2
{
    public class Country
    {
        public Name name { get; set; }
        public Dictionary<string, Currency> currencies { get; set; }
        public List<string> capital { get; set; }
    }

    public class Name
    {
        public string common { get; set; }
        public string official { get; set; }
        public NativeName nativeName { get; set; }
    }

    public class NativeName
    {
        public Dictionary<string, string> names { get; set; }
    }

    public class Por
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Currency
    {
        public string name { get; set; }
        public string symbol { get; set; }
    }
}
