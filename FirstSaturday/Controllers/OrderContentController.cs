using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstSaturday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderContentController : ControllerBase
    {
        IOrderContentService _OrderContentService;
        public OrderContentController(IOrderContentService OrderContentService)
        {
            _OrderContentService = OrderContentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _OrderContentService.GetAll());
        }
        [HttpGet("{id_o}/{id_c}/{id_g}")]
        public async Task<IActionResult> GetById(int id_o, int id_c, int id_g)
        {
            return Ok(await _OrderContentService.GetById(id_o, id_c, id_g));
        }
        [HttpPost]
        public async Task<IActionResult> Add(OrderContent OrderContent)
        {
            await _OrderContentService.Create(OrderContent);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(OrderContent OrderContent)
        {
            await _OrderContentService.Update(OrderContent);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id_o, int id_c, int id_g)
        {
            await _OrderContentService.Delete(id_o, id_c, id_g);
            return Ok();
        }
    }
}
