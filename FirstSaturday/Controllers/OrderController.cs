using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstSaturday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _OrderService;
        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _OrderService.GetAll());
        }
        [HttpGet("{id_o}/{id_c}")]
        public async Task<IActionResult> GetById(int id_o, int id_c)
        {
            return Ok(await _OrderService.GetById(id_o, id_c));
        }
        [HttpPost]
        public async Task<IActionResult> Add(Order Order)
        {
            await _OrderService.Create(Order);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Order Order)
        {
            await _OrderService.Update(Order);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id_o, int id_c)
        {
            await _OrderService.Delete(id_o, id_c);
            return Ok();
        }
    }
}
