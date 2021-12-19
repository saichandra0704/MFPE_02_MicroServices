using Microsoft.Extensions.Configuration;
using PolicyAdmin.QuotesMS.API.Data;
using PolicyAdmin.QuotesMS.API.DataLayer;
using PolicyAdmin.QuotesMS.API.Interface;
using PolicyAdmin.QuotesMS.API.Models;
using PolicyAdmin.QuotesMS.API.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.QuotesMS.API.Services
{
    public class QuotesDBService : IQuotesDBService
    {
        QuotesContext _context;
        public QuotesDBService(QuotesContext context)
        {
            _context = context;
          
        }

        public IEnumerable<QuoteMaster> GetAllQuotes()
        {
            var quotes = _context.QuotesMaster.Where(quote=> true);
            return quotes;
        }

        public IEnumerable<QuoteMaster> GetQuotes(PropertyType propertyType, int propertyValue, int businessValue)
        {
            var quotes =  _context.QuotesMaster.Where(quote => 
                                        quote.PropertyType == propertyType &&
                                        quote.PropertyValueRangeFrom <=propertyValue &&
                                        propertyValue <= quote.PropertyValueRangeTo &&
                                        quote.BusinessValueRangeFrom <= businessValue &&
                                        businessValue <=quote.BusinessValueRangeTo
                                        );
            return quotes;
        }
    }
}

