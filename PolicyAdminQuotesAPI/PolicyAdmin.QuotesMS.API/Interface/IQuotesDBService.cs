using PolicyAdmin.QuotesMS.API.Models;
using PolicyAdmin.QuotesMS.API.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.QuotesMS.API.Interface

{
    public interface IQuotesDBService
    {
        IEnumerable<QuoteMaster> GetQuotes(PropertyType propertyType, int propertyValue, int businessValue);
        IEnumerable<QuoteMaster> GetAllQuotes();

      
    }
}
