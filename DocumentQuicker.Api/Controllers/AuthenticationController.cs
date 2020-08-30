using System;
using System.Threading.Tasks;
using DocumentQuicker.Api.Models;
using DocumentQuicker.Api.Models.Requests;
using DocumentQuicker.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DocumentQuicker.Api.Controllers
{
    [Route("api/v1/Auth")]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        public Task<ActionResult<AuthenticateResponse>> Auth(AuthenticateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}