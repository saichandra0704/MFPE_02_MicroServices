using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolicyAdmin.ConsumerMS.API.Interface;
using PolicyAdmin.ConsumerMS.API.Models;
using PolicyAdmin.ConsumerMS.API.Models.DAO;
using PolicyAdmin.ConsumerMS.API.Models.Response;
using PolicyAdmin.ConsumerMS.API.Repository;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PolicyAdmin.ConsumerMS.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class ConsumerController : ControllerBase
    {
        private readonly IConsumerRepository _repository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger("RollingFile");

        public ConsumerController(IConsumerRepository repository)
        {
            _repository = repository;
        }



        // POST api/<ConsumerController>
        [HttpPost]
        public async Task<ActionResult<Status>> CreateConsumerBusiness([FromBody] Consumer consumer)
        {
   
            try
            {
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = StatusCodes.Status400BadRequest;
                    return new Status { Success= false, Message="Incorrect Value"};
                }
                var Result = await _repository.CreateConsumerBusiness(consumer);
                if (!Result.Success)
                {
                    Response.StatusCode = StatusCodes.Status500InternalServerError;
                    return Result;
                }
                Response.StatusCode = StatusCodes.Status200OK;
                return Result;
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                _log4net.Error(e.Message);
                return new Status { Success = false, Message = "Database Error"};
            }
        }

        // POST api/<ConsumerController>
        [HttpPut]
        public async Task<Status> updateConsumerBusiness([FromBody] Consumer consumer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = StatusCodes.Status400BadRequest;
                    return new Status { Success = false, Message = "Incorrect Value" };
                }
                Status Result = await _repository.UpdateConsumerBusiness(consumer);
                if (!Result.Success)
                {
                    Response.StatusCode = StatusCodes.Status500InternalServerError;
                    return Result;
                }
                Response.StatusCode = StatusCodes.Status200OK;
                return Result;
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                _log4net.Error(e.Message);
                return new Status { Success = false, Message = "Database Error" };
            }
        }


        // POST api/<ConsumerController>
        [HttpPost]
        public async Task<Status> createBusinessProperty([FromBody] Property property)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = StatusCodes.Status400BadRequest;
                    return new Status { Success = false, Message = "Incorrect Value" };
                

                }
                Status Result = await _repository.CreateBusinessProperty(property);
                if (!Result.Success)
                {
                    Response.StatusCode = StatusCodes.Status400BadRequest;
                    return Result;
                }
                Response.StatusCode = StatusCodes.Status200OK;
                return Result;
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                _log4net.Error(e.Message);
                return new Status { Success = false, Message = "Database Error" };
            }
        }



        



        // POST api/<ConsumerController>
        [HttpPut]
        public async Task<Status> updateBusinessProperty([FromBody] Property property)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = StatusCodes.Status400BadRequest;
                    return new Status { Success = false, Message = "Incorrect Value" };

                }
                Status Result = await _repository.UpdateBusinessProperty(property);
                if (!Result.Success)
                {
                    Response.StatusCode = StatusCodes.Status500InternalServerError;
                    return Result;
                }
                Response.StatusCode = StatusCodes.Status200OK;
                return Result;
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                _log4net.Error(e.Message);
                return new Status { Success = false, Message = "Database Error" };
            }
        }


        [HttpGet]
        public async Task<ObjectResult> ViewConsumerBusiness(int id)
        {
            try
            {
                return Ok(await _repository.ViewConsumerBusiness(id));
            }
            catch (Exception e)
            {
                _log4net.Error(e.Message);
                return new ObjectResult("Database error") { StatusCode = 500 };
            }
        }


        [HttpGet]
        public async Task<ObjectResult> ViewBusinessProperty(int id)
        {
            try
            {
                return Ok(await _repository.ViewBusinessProperty(id));
            }
            catch (Exception e)
            {
                _log4net.Error(e.Message);
                return new ObjectResult("Database error") { StatusCode = 500 };
            }
        }

    }
}
