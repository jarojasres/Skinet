using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skinet.API.Errors;
using Skinet.Infrastructure.Data;

namespace Skinet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _storeContext;

        public BuggyController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetSecretText()
        {
            return "secret stuff";
        }

        [HttpGet("notFound")]
        public IActionResult GetNotFoundRequest()
        {
            var thing = _storeContext.Products.Find(232);

            if (thing == null)
            {
                return NotFound(new ApiResponse(StatusCodes.Status400BadRequest));
            }

            return Ok();
        }

        [HttpGet("serverError")]
        public IActionResult GetServerError()
        {
            var thing = _storeContext.Products.Find(232);
            var thingToReturn = thing.ToString();

            return Ok();
        }

        [HttpGet("badRequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(StatusCodes.Status400BadRequest));
        }

        [HttpGet("badRequest/{id}")]
        public IActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }

    }
}