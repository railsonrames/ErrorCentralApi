using System.Collections.Generic;
using AutoMapper;
using ErrorCentralApi.DTOs;
using ErrorCentralApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ErrorCentralApi.Models;

namespace ErrorCentralApi.Controllers
{
    [Route("api/v1/[controller]")]    
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
        public ActionResult<IEnumerable<ErrorDTO>> Get()
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
        public ActionResult<Error> Save([FromBody] ErrorDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var error = _mapper.Map<Error>(value);
            return Ok(_mapper.Map<ErrorDTO>(_service.Save(error)));
        }
        
        // [HttpDelete]
        // public ActionResult<string> Delete(string id)
        // {

        // }

    }
}