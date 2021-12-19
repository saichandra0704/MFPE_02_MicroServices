using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PolicyAdmin.QuotesMS.API.Data;
using PolicyAdmin.QuotesMS.API.Models;
using PolicyAdmin.QuotesMS.API.Models.Enum;

namespace PolicyAdmin.QuotesMS.API.DataLayer
{
    public class DataGenerator
    {
        public DataGenerator( ) { }
        public static void Initialize(QuotesContext context)
        {
            List<QuoteMaster> quotes = getQuotes();
            for (int i = 0; i < quotes.Count; i++)
            {
                context.QuotesMaster.Add(quotes[i]);
            }
            context.SaveChanges();
                
            
        }
            private static List<QuoteMaster> getQuotes()
        {
            return new List<QuoteMaster>() {
                new QuoteMaster { Id=100001,PropertyValueRangeFrom=0, PropertyValueRangeTo=2, BusinessValueRangeFrom=0, BusinessValueRangeTo=2, PropertyType=PropertyType.Building, Quote=30300 },
                new QuoteMaster { Id=100002,PropertyValueRangeFrom=0, PropertyValueRangeTo=2, BusinessValueRangeFrom=3, BusinessValueRangeTo=5, PropertyType=PropertyType.Building, Quote=73900 },
                new QuoteMaster { Id=100003,PropertyValueRangeFrom=0, PropertyValueRangeTo=2, BusinessValueRangeFrom=6, BusinessValueRangeTo=8, PropertyType=PropertyType.Building, Quote=91500 },
                new QuoteMaster { Id=100004,PropertyValueRangeFrom=0, PropertyValueRangeTo=2, BusinessValueRangeFrom=9, BusinessValueRangeTo=10, PropertyType=PropertyType.Building, Quote=85300 },
                new QuoteMaster { Id=100005,PropertyValueRangeFrom=3, PropertyValueRangeTo=5, BusinessValueRangeFrom=0, BusinessValueRangeTo=2, PropertyType=PropertyType.Building, Quote=99300 },
                new QuoteMaster { Id=100006,PropertyValueRangeFrom=3, PropertyValueRangeTo=5, BusinessValueRangeFrom=3, BusinessValueRangeTo=5, PropertyType=PropertyType.Building, Quote=40000 },
                new QuoteMaster { Id=100007,PropertyValueRangeFrom=3, PropertyValueRangeTo=5, BusinessValueRangeFrom=6, BusinessValueRangeTo=8, PropertyType=PropertyType.Building, Quote=89100 },
                new QuoteMaster { Id=100008,PropertyValueRangeFrom=3, PropertyValueRangeTo=5, BusinessValueRangeFrom=9, BusinessValueRangeTo=10, PropertyType=PropertyType.Building, Quote=22400 },
                new QuoteMaster { Id=100009,PropertyValueRangeFrom=6, PropertyValueRangeTo=8, BusinessValueRangeFrom=0, BusinessValueRangeTo=2, PropertyType=PropertyType.Building, Quote=14700 },
                new QuoteMaster { Id=100010,PropertyValueRangeFrom=6, PropertyValueRangeTo=8, BusinessValueRangeFrom=3, BusinessValueRangeTo=5, PropertyType=PropertyType.Building, Quote=83700 },
                new QuoteMaster { Id=100011,PropertyValueRangeFrom=6, PropertyValueRangeTo=8, BusinessValueRangeFrom=6, BusinessValueRangeTo=8, PropertyType=PropertyType.Building, Quote=21800 },
                new QuoteMaster { Id=100012,PropertyValueRangeFrom=6, PropertyValueRangeTo=8, BusinessValueRangeFrom=9, BusinessValueRangeTo=10, PropertyType=PropertyType.Building, Quote=98700 },
                new QuoteMaster { Id=100013,PropertyValueRangeFrom=9, PropertyValueRangeTo=10, BusinessValueRangeFrom=0, BusinessValueRangeTo=2, PropertyType=PropertyType.Building, Quote=56200 },
                new QuoteMaster { Id=100014,PropertyValueRangeFrom=9, PropertyValueRangeTo=10, BusinessValueRangeFrom=3, BusinessValueRangeTo=5, PropertyType=PropertyType.Building, Quote=77100 },
                new QuoteMaster { Id=100015,PropertyValueRangeFrom=9, PropertyValueRangeTo=10, BusinessValueRangeFrom=6, BusinessValueRangeTo=8, PropertyType=PropertyType.Building, Quote=46800 },
                new QuoteMaster { Id=100016,PropertyValueRangeFrom=9, PropertyValueRangeTo=10, BusinessValueRangeFrom=9, BusinessValueRangeTo=10, PropertyType=PropertyType.Building, Quote=78200 },
            };
        }
    }

}