using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using DDDSample1.Domain.Armazens;
using DDDSample1.Domain.Armazens.DTO;

namespace DDDSample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListarArmazensController : ControllerBase
    {
        private readonly ListarArmazensService _service;

        public ListarArmazensController(ListarArmazensService service)
        {
            _service = service;
        }
        
        // GET: api/Armazéns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JObject>>> GetAll()
        {
            var listaArmazemDTO = await _service.GetAllAsync();

            List<JObject> listaArmazemJSON = new List<JObject>();

            foreach(ArmazemDTO armazemDTO in listaArmazemDTO)
                listaArmazemJSON.Add(JObject.FromObject(armazemDTO));
            return listaArmazemJSON;
        }
    }
}
