using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebCoreConstants
{
   public  class EnviuornmentValues
    {
        public EnviuornmentValues(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration["connection"].ToString();
        }

        public  IConfiguration Configuration { get; }

        public  string ConnectionString { get;  }
    }
}
