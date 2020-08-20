using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentQuicker.BusinessLayer.Interfaces;
using DocumentQuicker.BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace DocumentQuicker.Api.Controllers
{
    [Route("api/v1/BankInfo")]
    public class BankInfoController : Controller
    {
        private readonly IBankInfoService _bankInfoService;

        public BankInfoController(IBankInfoService bankInfoService)
        {
            _bankInfoService = bankInfoService ?? throw new ArgumentNullException(nameof(_bankInfoService));
        }

        [HttpGet]
        public async Task<ActionResult<IList<BankInfo>>> Get()
        {
            return Ok(await _bankInfoService.Get());
        }
        
        [HttpGet("{count:int}")]
        public async Task<ActionResult<IList<BankInfo>>> Get(int count)
        {
            return Ok(await _bankInfoService.Get(count));
        }

        [HttpGet("{count:int}/{offset:int}")]
        public async Task<ActionResult<IList<BankInfo>>> Get(int count, int offset)
        {
            return Ok(await _bankInfoService.Get(count: count, offset: offset));
        }
        
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BankInfo>> Get(Guid id)
        {
            return Ok(await _bankInfoService.Get(id));
        }
        
        [HttpPost]
        public async Task<ActionResult<BankInfo>> Create(string description, string bic, string corrAccount)
        {
            return Ok(await _bankInfoService.Create(description: description,
                                                    bic: bic,
                                                    corrAccount: corrAccount));
        }
    }
}