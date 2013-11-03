//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel.Web;
using System.Web;

namespace DataServices
{
    public class NorthwindDataService : DataService<northwindEntities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            config.SetEntitySetAccessRule("Customers", EntitySetRights.All);
            config.SetEntitySetAccessRule("Order_Details", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Orders", EntitySetRights.AllRead);
            config.SetServiceOperationAccessRule("OrderedCustomers", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }

        [WebGet(UriTemplate = "OrderedCustomers")]
        public IQueryable<Customers> OrderedCustomers()
        {
            return this.CurrentDataSource.Set<Customers>().OrderBy(c => c.CompanyName);
        }

        [QueryInterceptor("Customers")]
        public Expression<Func<Customers, bool>> OnQueryCustomers()
        {
            return c => c.Country == "USA"; 
        }

        [ChangeInterceptor("Customers")]
        public void UpdateCustomer(Customers customer, UpdateOperations ops)
        {
            if (string.IsNullOrWhiteSpace(customer.CompanyName))
            {
                throw new DataServiceException("Company name is required");
            }
        }
    }
}
