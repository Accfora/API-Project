using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstSaturday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodController : ControllerBase
    {
        IGoodService _goodService;
        public GoodController(IGoodService GoodService)
        {
            _goodService = GoodService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _goodService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _goodService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(Good Good)
        {
            await _goodService.Create(Good);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Good Good)
        {
            await _goodService.Update(Good);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _goodService.Delete(id);
            return Ok();
        }
    }
}
