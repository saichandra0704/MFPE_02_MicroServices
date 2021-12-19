using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolicyAdmin.QuotesMS.API.Interface;
using PolicyAdmin.QuotesMS.API.Models;
using PolicyAdmin.QuotesMS.API.Models.Enum;
using PolicyAdmin.QuotesMS.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.QuotesMS.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class QuotesController : Controller
    {
        private readonly IQuoteRepository _repository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger("RollingFile");
        public QuotesController(IQuoteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<QuoteMaster>> getQuotesForPolicy(PropertyType propertyType, int propertyValue, int businessValue)
        {
            _log4net.Info("Received Request for Quote");
            IEnumerable<QuoteMaster> quotes = await _repository.GetQuotes( propertyType,  propertyValue,  businessValue);
            return quotes;
        }

        [HttpGet]
        public async Task<IEnumerable<QuoteMaster>> getAllQuotes()
        {
            IEnumerable<QuoteMaster> quotes = await _repository.GetAllQuotes();
            return quotes;
        }
    }
}
