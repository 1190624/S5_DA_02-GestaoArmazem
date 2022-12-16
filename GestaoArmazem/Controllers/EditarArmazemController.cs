using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using DDDSample1.Domain.Armazens;
using DDDSample1.Domain.Common;
using DDDSample1.Domain.Armazens.DTO;
using DDDSample1.Domain.Shared;
using System;

namespace DDDSample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditarArmazemController : ControllerBase
    {
        private readonly EditarArmazemService _service;

        public EditarArmazemController(EditarArmazemService service)
        {
            _service = service;
        }

        // PUT: api/EditarArmazém/id
       [HttpPut("{Id}")]
        public async Task<ActionResult<JObject>> EditarArmazem(String Id, JObject novoArmazemJSON)
        {
            
            if (Id.ToString() != novoArmazemJSON.ToObject<ArmazemDTO>().GetIdentificador)
            {
                return BadRequest();
            }

            try
            {
                var armazemDTO = await _service.EditarArmazemAsync(novoArmazemJSON.ToObject<ArmazemDTO>());
                var response = JObject.FromObject(armazemDTO);
                
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