using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatleBug.Common.Enums
{
    public enum StatusEnum : int
    {
        [Description("All Bugs")]
        All = 0,
        [Description("To Do")]
        ToDo = 1,
        [Description("In Progress")]
        InProgress = 2,
        [Description("In Test")]
        Test = 3,
        [Description("Complete")]
        Done = 4
    }
}
