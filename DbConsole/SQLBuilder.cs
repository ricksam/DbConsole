using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbConsole
{
    public class SQLBuilder
    {
        public List<SQLFilter> Filters { get; set; }
    }

    public class SQLFilter {
        public string Table { get; set; }
        public SQLField Field { get; set; }
        public string Filter { get; set; }
        public string Value { get; set; }
    }

    public class SQLField 
    {
        public string Name { get; set; }
        public lib.Database.Drivers.enmFieldType Type { get; set; }
    }
}
