using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatleBug.Common.Enums
{
    public enum SeverityEnum : int
    {
        [Description("Unclassified")]
        None = 0,
        [Description("Low Priority")]
        Low = 1,
        [Description("Medium Priority")]
        Medium = 2,
        [Description("High Priority")]
        High = 3
    }
}
