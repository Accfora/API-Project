using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstSaturday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        IFilterService _FilterService;
        public FilterController(IFilterService FilterService)
        {
            _FilterService = FilterService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _FilterService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _FilterService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(Filter Filter)
        {
            await _FilterService.Create(Filter);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Filter Filter)
        {
            await _FilterService.Update(Filter);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _FilterService.Delete(id);
            return Ok();
        }
    }
}
