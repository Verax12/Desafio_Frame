using LIBs.Domain;
using LIBs.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IServiceVenda _serviceVenda;

        public VendasController(IServiceVenda serviceVenda)
        {
            _serviceVenda = serviceVenda;
        }
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(_serviceVenda.GetAll().ToList());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]  
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(_serviceVenda.GetById(id));
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(Venda))]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public void PostASync(Venda venda)
        {
            _serviceVenda.PreparaVenda(ref venda);
            _serviceVenda.AddAsync(venda);
        }
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(Venda))]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPut]
        public void Put(Venda venda)
        {
            if (_serviceVenda.ValidaStatusVenda(venda))
            {
                _serviceVenda.DetachLocal(p => p.Codigo == venda.Codigo);
                _serviceVenda.Update(venda);
            }
        }
    }
}