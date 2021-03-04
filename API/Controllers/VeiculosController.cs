using LIBs.Domain;
using LIBs.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {


        private readonly IServiceVeiculo _serviceVeiculo;

        public VeiculosController(IServiceVeiculo serviceVeiculo)
        {
            _serviceVeiculo = serviceVeiculo;
        }

        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_serviceVeiculo.GetAll().ToList());
        }


        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(_serviceVeiculo.GetById(id));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(Veiculo))]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async void PostASync(Veiculo veiculo)
        {
            _serviceVeiculo.AddAsync(veiculo);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(Veiculo))]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public void Put(Veiculo veiculo)
        {
                _serviceVeiculo.DetachLocal(p => p.Codigo == veiculo.Codigo);
                _serviceVeiculo.Update(veiculo);
        }
    }
}