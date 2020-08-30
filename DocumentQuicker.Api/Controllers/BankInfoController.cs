using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DocumentQuicker.Api.Interfaces;
using DocumentQuicker.Api.Models;
using DocumentQuicker.Api.Models.Dto;
using DocumentQuicker.BusinessLayer.Interfaces;
using DocumentQuicker.BusinessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentQuicker.Api.Controllers
{
    [Route("api/v1/Bank")]
    [ApiController]
    public sealed class BankInfoController : ControllerBase
    {
        private readonly IBankService _bankInfoService;
        private readonly IValidationDecorator _validationDecorator;
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
        [ProducesResponseType(typeof(BankDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(IList<ValidationDetails>),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankDto>> Create(ShortBankDto bank)
        {
            try
            {
                var validationResult = await _validationDecorator.ValidateAsyncEx(bank);
                if (!validationResult.Result)
                {
                    return BadRequest(validationResult.Errors);
                }
                
                var result = await _bankInfoService.Create(description: bank.Description,
                                                           bic: bank.Bic,
                                                           corrAccount: bank.CorrAccount);
                return Ok(_mapper.Map<BankDto>(_mapper.Map<Bank>(result)));
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
        [ProducesResponseType(typeof(BankDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IList<ValidationDetails>),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankDto>> Update(Guid id,[FromBody] ShortBankDto bank)
        {
            try
            {
                var validationResult = await _validationDecorator.ValidateAsyncEx(bank);
                if (!validationResult.Result)
                {
                    return BadRequest(validationResult.Errors);
                }
                
                var result = await _bankInfoService.Update(id: id,
                                                           description: bank.Description,
                                                           bic: bank.Bic,
                                                           corrAccount: bank.CorrAccount);
                
                return Ok(_mapper.Map<BankDto>(result));
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
        [ProducesResponseType(typeof(BankDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankDto>> Get(Guid id)
        {
            try
            {
                return Ok(_mapper.Map<BankDto>(await _bankInfoService.Get(id)));
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
        [ProducesResponseType(typeof(IList<BankDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<BankDto>>> Get()
        {
            try
            {
                var result = await _bankInfoService.Get();

                return Ok(result.Select(x => _mapper.Map<BankDto>(x)).ToList());
            }
            catch
            {
                return StatusCode(500);
            }
        }
        
        [HttpGet("{count}")]
        [Produces("application/json")]
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(typeof(IList<BankDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<BankDto>>> Get(int count)
        {
            try
            {
                var result = await _bankInfoService.Get(count);

                return Ok(result.Select(x => _mapper.Map<BankDto>(x)).ToList());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{count}/{offset}")]
        [Produces("application/json")]
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(typeof(IList<BankDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<BankDto>>> Get(int count, int offset)
        {
            try
            {
                var result = await _bankInfoService.Get(count: count, offset: offset);

                return Ok(result.Select(x => _mapper.Map<BankDto>(x)).ToList());
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}