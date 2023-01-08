using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using DDDSample1.Domain.Armazens;
using DDDSample1.Domain.Armazens.DTO;
using DDDSample1.Domain.Shared;
using Microsoft.AspNetCore.Authorization;

namespace DDDSample1.Controllers {
    [Route("/api/armazem")]
    [ApiController]
    public class RegistarArmazemController : ControllerBase {
        private readonly RegistarArmazemService service;

        public RegistarArmazemController(RegistarArmazemService service) {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArmazemDTO>>> GetAll()
        {
            return await service.GetAllAsync();
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<ArmazemDTO>> GetById(String Id) {
            var response = await service.GetByIdAsync(Id);

            if (response == null)
                return NotFound();
            
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<ArmazemDTO>> Create(JObject armazemJSON) {
            try {
                var response = await service.RegistarArmazem(armazemJSON.ToObject<ArmazemDTO>());

                return CreatedAtAction(nameof(GetById), new {Id = response.identificador}, response);
            } catch (BusinessRuleValidationException exception) {
                return BadRequest(new {exception.Message});
            }
        }

        [HttpDelete("{ID}")]
        //[Authorize]
        public async Task<ActionResult<JObject>> HardDelete(String Id)
        {
            try
            {
                var response = await service.DeleteAsync(Id);

                if (response == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }

        [HttpPut("desativar/{ID}")]
        //[Authorize]
        public async Task<ActionResult<JObject>> AtivarDesativarArmazem(String Id)
        {
            try
            {
                var response = await service.AtivarDesativarArmazem(Id);

                if (response == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }
    }
}