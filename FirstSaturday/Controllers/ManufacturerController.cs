using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstSaturday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        IManufacturerService _ManufacturerService;
        public ManufacturerController(IManufacturerService ManufacturerService)
        {
            _ManufacturerService = ManufacturerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ManufacturerService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _ManufacturerService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(Manufacturer Manufacturer)
        {
            await _ManufacturerService.Create(Manufacturer);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Manufacturer Manufacturer)
        {
            await _ManufacturerService.Update(Manufacturer);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _ManufacturerService.Delete(id);
            return Ok();
        }
    }
}
