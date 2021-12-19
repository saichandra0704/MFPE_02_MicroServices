﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolicyAdmin.PolicyMS.API.Interface;
using PolicyAdmin.PolicyMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PolicyAdmin.PolicyMS.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyRepository _policyrepo;
        private readonly IAuthenticationManager _auth;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger("RollingFile");

        public PolicyController(IPolicyRepository policyrepo, IAuthenticationManager auth)
        {
            _policyrepo = policyrepo;
            _auth = auth;
        }

        [HttpGet]
        public async Task<object> GetPolicyMaster( int ConsumerId, int PropertyId)
        {
            _auth.AuthToken = Request.Headers["Authorization"];
            object responseObject = await _policyrepo.GetPolicyMaster(ConsumerId, PropertyId);
            return responseObject;
        }


        // GET: api/<PolicyController>
        [HttpGet]
        public async Task<List<QuoteMaster>> GetQuotes(int businessValue, int propertyValue)
        {
            _auth.AuthToken = Request.Headers["Authorization"];
            List<QuoteMaster>  quotes = await _policyrepo.GetQuotes(businessValue, propertyValue);
            return quotes;
        }// GET: api/<PolicyController>
        
        [HttpPost]
        public async Task<ResponseObject> CreatePolicy(InputCreatePolicy input)
        {
            _auth.AuthToken = Request.Headers["Authorization"];
            ResponseObject responseObject;
            if (!ModelState.IsValid)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                responseObject = new ResponseObject { Success = false};
                responseObject.Message = (List<string>)ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return responseObject;
            }
            
            try
            {
                responseObject = await _policyrepo.CreatePolicy(input.consumerId, input.propertyId, input.amount, input.agentId, input.policyMasterId);
                
            }catch(Exception e)
            {
                responseObject = new ResponseObject { Success = false, Message = { "Something Went Wrong"} };
                _log4net.Error(e.Message);
                return responseObject;
            }
            return responseObject;
        }
        [HttpPost]
        public async Task<ResponseObject> IssuePolicy(InputIssuePolicy input)
        {
            _auth.AuthToken = Request.Headers["Authorization"];
            ResponseObject responseObject;
            if (!ModelState.IsValid)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                responseObject = new ResponseObject { Success = false };
                responseObject.Message = (List<string>)ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return responseObject;
            }

            try
            {

                responseObject = await _policyrepo.IssuePolicy(input.PolicyId,input.ConsuemrId, input.BusinessId, input.PaymentDetails);
            }
            catch (Exception e)
            {
                responseObject = new ResponseObject { Success = false, Message = { "Something Went Wrong" } };
                _log4net.Error(e.Message);
                return responseObject;
            }
            return responseObject;
        }


        [HttpGet]
        public async Task<object> GetPolicy(int PolicyId, int ConsumerId)
        {
            _auth.AuthToken = Request.Headers["Authorization"];
            var resaponse = await _policyrepo.GetPolicy(PolicyId, ConsumerId);
            return resaponse;
        }
    }
}
