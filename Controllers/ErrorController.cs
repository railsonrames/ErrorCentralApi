using System.Collections.Generic;
using AutoMapper;
using ErrorCentralApi.DTOs;
using ErrorCentralApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ErrorCentralApi.Models;
using System;
using Microsoft.AspNetCore.Authorization;

namespace ErrorCentralApi.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]  
    [ApiController]
    public class ErrorController : Controller
    {
        private readonly IErrorService _service;
        private readonly IMapper _mapper;

        public ErrorController(IErrorService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ErrorDTO>> GetAll()
        {
            var errors = _service.GetAll();
            if (errors == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(errors.
                    Select(e => _mapper.Map<ErrorDTO>(e)).
                    ToList());
            }
        }

        [HttpGet("{id:guid}")]
        public ActionResult<ErrorDTO> Get(Guid id)
        {
            try
            {
                var error = _service.FindById(id);
                if (error == null)
                {
                    return NotFound($"Log id:{id} não encontrado.");
                }
                var result = _mapper.Map<ErrorDTO>(error);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpGet("{environment}")]
        public ActionResult<IEnumerable<ErrorDTO>> GetErrorEnvironment(string environment)
        {
            Models.Environment enumEnvironment;
            if(Enum.TryParse<Models.Environment>(environment, true, out enumEnvironment))
            {
                var errors = _service.FindByEnvironment(enumEnvironment);
                var result = errors.Select(e => _mapper.Map<ErrorDTO>(e)).ToList();
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Error> Save([FromBody] ErrorDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var error = _mapper.Map<Error>(value);
            return Created(nameof(error.Id), _mapper.Map<ErrorDTO>(_service.Save(error)));
        }

        [HttpPut("{id:guid}/archive")]
        public ActionResult<string> Archieve(Guid id)
        {
            var error = _service.FindById(id);
            if(error == null)
            {
                return NotFound("ID não encontrado.");
            }
            return Ok(_service.Archive(error) ? $"Log id:{id} arquivado com sucesso." : $"Falha ao arquivar o Log id:{id}");
        }
        
        [HttpDelete("{id:guid}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var error = _service.FindById(id);
                if(error == null)
                {
                    return NotFound();
                }
                _service.Delete(error);
                return NoContent();      
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }

    }
}