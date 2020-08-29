using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DocumentQuicker.Api.Extensions;
using DocumentQuicker.Api.Interfaces;
using DocumentQuicker.Api.Models;
using DocumentQuicker.BusinessLayer.Interfaces;
using DocumentQuicker.BusinessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentQuicker.Api.Controllers
{
    [Route("api/v1/BankInfo")]
    [ApiController]
    public sealed class BankInfoController : ControllerBase
    {
        private readonly IValidationDecorator _validationDecorator;
        private readonly IBankService _bankInfoService;
        private readonly IMapper _mapper;

        public BankInfoController(IBankService bankInfoService,
                                  IValidationDecorator validationDecorator,
                                  IMapper mapper)
        {
            _bankInfoService = bankInfoService ?? throw new ArgumentNullException(nameof(_bankInfoService));
            _validationDecorator = validationDecorator ?? throw new ArgumentNullException(nameof(_validationDecorator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }
        
        [HttpPost]
        [Produces("application/json")]
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(typeof(BankInfoDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(IList<ValidationDetails>),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankInfoDto>> Create(ShortBankInfoDto bankInfo)
        {
            var validation = await _validationDecorator.ValidateAsync(bankInfo);

            if (!validation.IsValid)
            {
                return BadRequest(validation.GetValidationDetails());
            }

            try
            {
                var result = await _bankInfoService.Create(_mapper.Map<Bank>(bankInfo));
                return Ok(_mapper.Map<BankInfoDto>(result));
            }
            //TODO append error handler middleware. Also append logging!
            catch 
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(typeof(BankInfoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IList<ValidationDetails>),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankInfoDto>> Update(Guid id,[FromBody] ShortBankInfoDto shortBankInfoDto)
        {
            var validation = await _validationDecorator.ValidateAsync(shortBankInfoDto);
            if (!validation.IsValid)
            {
                return BadRequest(validation.GetValidationDetails());
            }

            var bankInfo = new Bank(description: shortBankInfoDto.Description,
                                    bic: shortBankInfoDto.Bic,
                                    corrAccount: shortBankInfoDto.CorrAccount,
                                    id: id,
                                    creationDate: DateTime.MinValue,
                                    editDate: DateTime.MinValue,
                                    isActive: true);

            try
            {
                var result = await _bankInfoService.Update(bankInfo);
                return Ok(_mapper.Map<BankInfoDto>(result));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _bankInfoService.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        
        [HttpGet("{id}/info")] 
        [Produces("application/json")]
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(typeof(BankInfoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankInfoDto>> Get(Guid id)
        {
            try
            {
                return Ok(_mapper.Map<BankInfoDto>(await _bankInfoService.Get(id)));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        
        [HttpGet]
        [Produces("application/json")]
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(typeof(IList<BankInfoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<BankInfoDto>>> Get()
        {
            try
            {
                var result = await _bankInfoService.Get();

                return Ok(result.Select(x => _mapper.Map<BankInfoDto>(x)).ToList());
            }
            catch
            {
                return StatusCode(500);
            }
        }
        
        [HttpGet("{count}")]
        [Produces("application/json")]
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(typeof(IList<BankInfoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<BankInfoDto>>> Get(int count)
        {
            try
            {
                var result = await _bankInfoService.Get(count);

                return Ok(result.Select(x => _mapper.Map<BankInfoDto>(x)).ToList());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{count}/{offset}")]
        [Produces("application/json")]
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(typeof(IList<BankInfoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<BankInfoDto>>> Get(int count, int offset)
        {
            try
            {
                var result = await _bankInfoService.Get(count: count, offset: offset);

                return Ok(result.Select(x => _mapper.Map<BankInfoDto>(x)).ToList());
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}