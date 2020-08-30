using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DocumentQuicker.Api.Interfaces;
using DocumentQuicker.Api.Models.Dto;
using DocumentQuicker.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentQuicker.Api.Controllers
{
    [Route("api/v1/Requisite")]
    [ApiController]
    public class RequisiteController : ControllerBase
    {
        private readonly IRequisiteService _requisiteService;
        private readonly IValidationDecorator _validationDecorator;
        private readonly IMapper _mapper;

        //todo append validator 
        public RequisiteController(IRequisiteService requisiteService,
                                   IValidationDecorator validationDecorator,
                                   IMapper mapper)
        {
            _requisiteService = requisiteService ?? throw new ArgumentNullException(nameof(_requisiteService));
            _validationDecorator = validationDecorator ?? throw new ArgumentNullException(nameof(_validationDecorator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(typeof(RequisiteDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RequisiteDto>> Create(ShortRequisiteDto requisiteDto)
        {
            try
            {
                var result = await _requisiteService.Create(name: requisiteDto.Name,
                                                            inn: requisiteDto.INN,
                                                            kpp: requisiteDto.KPP,
                                                            city: requisiteDto.City,
                                                            rawAddress: requisiteDto.City,
                                                            bankAccount: requisiteDto.BankAccount,
                                                            bankId: requisiteDto.BankId);
                
                return CreatedAtAction(nameof(Get), new {id = result.Id}, _mapper.Map<RequisiteDto>(result));
            }
            catch
            {
                return StatusCode(500);
            }
        }
        
        [HttpPut]
        [Produces("application/json")]
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(typeof(RequisiteDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RequisiteDto>> Update(Guid id, [FromBody]ShortRequisiteDto requisiteDto)
        {
            try
            {
                var result = await _requisiteService.Update(id,
                                                            requisiteDto.Name,
                                                            requisiteDto.INN,
                                                            requisiteDto.KPP,
                                                            requisiteDto.City,
                                                            requisiteDto.City,
                                                            requisiteDto.BankAccount,
                                                            requisiteDto.BankId);

                //todo change to CreatedAtAction
                return Ok(_mapper.Map<RequisiteDto>(result));
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
                await _requisiteService.Delete(id);
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
        [ProducesResponseType(typeof(RequisiteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RequisiteDto>> Get(Guid id)
        {
            try
            {
                return Ok(_mapper.Map<RequisiteDto>(await _requisiteService.Get(id)));
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
        [ProducesResponseType(typeof(IList<RequisiteDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<RequisiteDto>>> Get()
        {
            try
            {
                var result = await _requisiteService.Get();

                return Ok(result.Select(x => _mapper.Map<RequisiteDto>(x)).ToList());
            }
            catch
            {
                return StatusCode(500);
            }
        }
        
        [HttpGet("{count}")]
        [Produces("application/json")]
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(typeof(IList<RequisiteDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<RequisiteDto>>> Get(int count)
        {
            try
            {
                var result = await _requisiteService.Get(count);

                return Ok(result.Select(x => _mapper.Map<RequisiteDto>(x)).ToList());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{count}/{offset}")]
        [Produces("application/json")]
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(typeof(IList<RequisiteDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<RequisiteDto>>> Get(int count, int offset)
        {
            try
            {
                var result = await _requisiteService.Get(count: count, offset: offset);

                return Ok(result.Select(x => _mapper.Map<RequisiteDto>(x)).ToList());
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}