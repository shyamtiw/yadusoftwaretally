using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Business
{
    public sealed class Global
    {
        public static infofix_Vikrant_Transport Context
        {
            get
            {
                string ocKey = "is_" + HttpContext.Current.GetHashCode().ToString("x");
                if (!HttpContext.Current.Items.Contains(ocKey))
                    HttpContext.Current.Items.Add(ocKey, new infofix_Vikrant_Transport());
                return HttpContext.Current.Items[ocKey] as infofix_Vikrant_Transport;
            }
        }
    }
}
