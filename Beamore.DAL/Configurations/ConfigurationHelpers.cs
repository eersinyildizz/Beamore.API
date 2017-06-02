using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Configurations
{
    public static class ConfigurationHelpers
    {
        public static string CONNECTION_STRING
        {
            get { return ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString; }
        }
    }
}
