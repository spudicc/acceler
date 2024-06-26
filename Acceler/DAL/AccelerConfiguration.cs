﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

namespace Acceler.DAL
{
    public class AccelerConfiguration : DbConfiguration
    {
        public AccelerConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            DbInterception.Add(new AccelerInterceptorTransientErrors());
            DbInterception.Add(new AccelerInterceptorLogging());
        }
    }
}