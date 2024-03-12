using Accounting.DataLayer;
using Accounting.DataLayer.Context;
using Accounting.DataLayer.Repositories;
using Accounting.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Accounting.Api.Controllers
{
    public class WebController : ApiController
    {
        UnitOfWork db = new UnitOfWork();

        // GET: api/PersonApi
        public IEnumerable<Customers> GetAll()
        {
            return db.customerRepository.GetAllCustomers();
        }
    }
}
