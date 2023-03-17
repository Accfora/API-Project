using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstSaturday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodFilterValueController : ControllerBase
    {
        IGoodFilterValueService _GoodFilterValueService;
        public GoodFilterValueController(IGoodFilterValueService GoodFilterValueService)
        {
            _GoodFilterValueService = GoodFilterValueService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _GoodFilterValueService.GetAll());
        }
        [HttpGet("{id_g}/{id_f}")]
        public async Task<IActionResult> GetById(int id_g, int id_f)
        {
            return Ok(await _GoodFilterValueService.GetById(id_g, id_f));
        }
        [HttpPost]
        public async Task<IActionResult> Add(GoodFilterValue GoodFilterValue)
        {
            await _GoodFilterValueService.Create(GoodFilterValue);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(GoodFilterValue GoodFilterValue)
        {
            await _GoodFilterValueService.Update(GoodFilterValue);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id_g, int id_f)
        {
            await _GoodFilterValueService.Delete(id_g, id_f);
            return Ok();
        }
    }
}
