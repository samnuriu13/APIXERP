using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STATIC
{
    public class GlobalEnums
    {
        [Flags]
        public enum enumSearchType
        {
            DynamicString = 1,
            StoredProcedured = 2
        }
    }
}
