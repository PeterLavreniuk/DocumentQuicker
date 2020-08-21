using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DocumentQuicker.Api.Models;
using DocumentQuicker.BusinessLayer.Interfaces;
using DocumentQuicker.BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace DocumentQuicker.Api.Controllers
{
    [Route("api/v1/BankInfo")]
    [ApiController]
    public class BankInfoController : ControllerBase
    {
        private readonly IBankInfoService _bankInfoService;
        private readonly IMapper _mapper;

        public BankInfoController(IBankInfoService bankInfoService,
                                  IMapper mapper)
        {
            _bankInfoService = bankInfoService ?? throw new ArgumentNullException(nameof(_bankInfoService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }
        
        [HttpPost]
        public async Task<ActionResult<BankInfoDto>> Create(ShortBankInfoDto bankInfo)
        {
            var result = await _bankInfoService.Create(_mapper.Map<BankInfo>(bankInfo));
            return Ok(_mapper.Map<BankInfoDto>(result));
        }

        [HttpGet]
        public async Task<ActionResult<IList<BankInfoDto>>> Get()
        {
            var result = await _bankInfoService.Get();
            
            return Ok(result.Select(x => _mapper.Map<BankInfoDto>(x)).ToList());
        }
        
        [HttpGet("{count}")]
        public async Task<ActionResult<IList<BankInfoDto>>> Get(int count)
        {
            return Ok(await _bankInfoService.Get(count));
        }

        [HttpGet("{count}/{offset}")]
        public async Task<ActionResult<IList<BankInfoDto>>> Get(int count, int offset)
        {
            return Ok(await _bankInfoService.Get(count: count, offset: offset));
        }
        
        [HttpGet("{id}/info")] 
        public async Task<ActionResult<BankInfoDto>> Get(Guid id)
        {
            return Ok(await _bankInfoService.Get(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BankInfoDto>> Update(Guid id,[FromBody] ShortBankInfoDto shortBankInfoDto)
        {
            var bankInfo = new BankInfo(description: shortBankInfoDto.Description,
                                        bic: shortBankInfoDto.Bic,
                                        corrAccount: shortBankInfoDto.CorrAccount,
                                        id: id,
                                        creationDate: DateTime.MinValue,
                                        editDate: DateTime.MinValue,
                                        isActive: true);
            var result = await _bankInfoService.Update(bankInfo);

            return Ok(_mapper.Map<BankInfoDto>(result));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _bankInfoService.Delete(id);

            return Ok();
        }
    }
}