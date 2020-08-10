using System.Collections.Generic;
using AutoMapper;
using ErrorCentralApi.DTOs;
using ErrorCentralApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ErrorCentralApi.Models;

namespace ErrorCentralApi.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    public class ErrorController: ControllerBase
    {
        private readonly IErrorService _service;
        private readonly IMapper _mapper;

        public ErrorController(IErrorService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ErrorDTO>> GetErrors()
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

        [HttpPost]
        public ActionResult<Error> SaveError([FromBody] ErrorDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var error = _mapper.Map<Error>(value);
            return Ok(_mapper.Map<ErrorDTO>(_service.Save(error)));
        }


    }
}