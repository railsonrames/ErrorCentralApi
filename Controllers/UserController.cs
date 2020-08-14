using System;
using AutoMapper;
using ErrorCentralApi.DTOs;
using ErrorCentralApi.Models;
using ErrorCentralApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErrorCentralApi.Controllers
{
    [Route("/api/v1/[controller]")]
    // [Authorize]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public UserController(IUserService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        public ActionResult<UserDTO> GetById(Guid id)
        {
            var user = _service.FindById(id);
            if (user == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<UserDTO>(user);
            return Ok(result);
        }

        [HttpGet("{email}")]
        public ActionResult<UserDTO> GetByEmail(string email)
        {
            var user = _service.FindByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<UserDTO>(user);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<string> Create([FromBody] UserDTO value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User user = _mapper.Map<User>(value);
            _service.Save(user);
            return Ok($"Usuário id: {user.Id} criado.");
        }

        [HttpDelete("{id:guid}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var user = _service.FindById(id);
                if (user == null)
                {
                    return NotFound();
                }
                _service.Delete(user);
                return NoContent();    
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }

    }
}