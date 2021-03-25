using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MFPE_CusumerModule.Models;
using MFPE_CusumerModule.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MFPE_CusumerModule.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private readonly IConsumerRepository repository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ConsumerController));
        public ConsumerController(IConsumerRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("CreateConsumerBussiness")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ObjectResult> CreateConsumerBusiness(Consumer consumer)
        {
            try {
                _log4net.Info(" Http GET in controller is accesed");
                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(ModelState);
                }
                var Result = await repository.CreateConsumerBussiness(consumer);

                _log4net.Info("method execution in controller completed");
                if (!Result)
                {
                    return new ObjectResult("Database error") { StatusCode = 500 };
                }
                return new CreatedResult("FindConsumerBussiness", new { id = consumer.id });
            }
            catch (Exception e)
            {
                _log4net.Error("Error in getting the consumerController with respective Id" + " As " + e.Message);
                return new ObjectResult("Database error") { StatusCode = 500 };
            }



        }

        //implemented

        [HttpPost("CreateBussinessProperty")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ObjectResult> CreateBussinessProperty(Property property)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            var Result = await repository.CreateBussinessProperty(property);

            if (!Result)
            {
                return new ObjectResult("Database error") { StatusCode = 500 };
            }
            return new CreatedResult("FindConsumerProperty", new { id = property.id });
        }




        [HttpPut("UpdateConsumerBussiness")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ObjectResult> UpdateConsumerBusiness(Consumer consumer)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            var Result = await repository.UpdateConsumerBussiness(consumer);

            if (!Result)
            {
                return new ObjectResult("Database error") { StatusCode = 500 };
            }
            return new CreatedResult("FindConsumerBussiness", new { id = consumer.id });
        }


        [HttpPut("UpdateBussinessProperty")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ObjectResult> UpdateBusinessProperty(Property property)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            var Result = await repository.UpdateBussinessProperty(property);

            if (!Result)
            {
                return new ObjectResult("Database error") { StatusCode = 500 };
            }
            return new CreatedResult("FindConsumerProperty", new { id = property });
        }

        [HttpGet("{id}", Name = "FindConsumerBussiness")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ObjectResult> ViewConsumerBussiness(int consumerid)
        {
            return Ok(await repository.ViewConsumerBussiness(consumerid));
        }


        [HttpGet("FindConsumerProperty", Name = "FindConsumerProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ObjectResult> ViewConsumerProperty(int consumerid, int propertyid)
        {
            return Ok(await repository.ViewConsumerProperty(consumerid,propertyid));
        }

        [HttpGet("FindAllConsumers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ObjectResult> ViewAllConsumerBussiness()
        {
            return Ok(await repository.ViewAllConsumerBussiness());
        }



        [HttpPost("CreateBussinessMaster")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ObjectResult> CreateBusinessMaster(BusinessMaster businessMaster)
        {
            try
            {
                _log4net.Info(" Http GET in controller is accesed");
                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(ModelState);
                }
                var Result = await repository.CreateBussinessMaster(businessMaster);

                _log4net.Info("method execution in controller completed");
                if (!Result)
                {
                    return new ObjectResult("Database error") { StatusCode = 500 };
                }
                return new CreatedResult("FindBussinessMasterById", new { id = businessMaster.id });
            }
            catch (Exception e)
            {
                _log4net.Error("Error in getting the consumerController with respective Id" + " As " + e.Message);
                return new ObjectResult("Database error") { StatusCode = 500 };
            }



        }

        //[Route("Consumers/FindBussinessMasterById/{id}")]
        [HttpGet("FindBussinessMasterById/{id}", Name = "FindBussinessMasterById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ObjectResult> ViewBussinessMasterById(int bussinessMasterid)
        {
            return Ok(await repository.ViewBussinessMasterById(bussinessMasterid));
        }

        [HttpGet("FindPropertyById/{id}", Name = "FindPropertyById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ObjectResult> ViewBussinessPropertyById(int propertyid)
        {
            return Ok(await repository.ViewBussinessProperty(propertyid));
        }



        [HttpGet("FindAllProperties")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ObjectResult> ViewAllBussinessProperties()
        {
            return Ok(await repository.ViewAllBussinessProperties());
        }
    }
}