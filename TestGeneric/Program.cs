using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.DataLayer;
using Accounting.DataLayer.Services;

namespace TestGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            Accounting_DBEntities db = new Accounting_DBEntities();
            GenericRepository<Customers> customerRepository = new GenericRepository<Customers>(db);

            var Result = customerRepository.GetById(18);
            var result2 = customerRepository.Get(c => c.FullName.Contains("محمد امین نوروزی"));
        }
    }
}
