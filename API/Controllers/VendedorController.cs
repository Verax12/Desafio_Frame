using LIBs.Domain;
using LIBs.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IServiceVendedor _serviceVendedor;

        public VendedorController(IServiceVendedor serviceVendedor)
        {
            _serviceVendedor = serviceVendedor;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_serviceVendedor.GetAll().ToList());
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(_serviceVendedor.GetById(id));
        }

        [HttpPost]
        public async void PostASync(Vendedor vendedor)
        {
            _serviceVendedor.AddAsync(vendedor);
        }

        [HttpPut]
        public void Put(Vendedor vendedor)
        {
            _serviceVendedor.Update(vendedor);
        }
    }
}