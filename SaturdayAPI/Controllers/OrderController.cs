using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaturdayAPI.Contracts.Customer;

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
        /// <summary>
        /// Получение всех заказов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _OrderService.GetAll());
        }
        /// <summary>
        /// Получение заказа по id
        /// </summary>
        /// <param name="id_o"></param>
        /// <param name="id_c"></param>
        /// <returns></returns>
        [HttpGet("{id_o}/{id_c}")]
        public async Task<IActionResult> GetById(int id_o, int id_c)
        {
            var result = await _OrderService.GetById(id_o, id_c);
            var response = result.Adapt<GetOrderResponse>();
            return Ok(response);
        }
        /// <summary>
        /// Добавление заказа
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateOrderRequest request)
        {
            var customerDto = request.Adapt<Order>();
            await _OrderService.Create(customerDto);
            return Ok();
        }
        /// <summary>
        /// Обновление заказа
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateOrderRequest request)
        {
            var customerDto = request.Adapt<Order>();
            await _OrderService.Update(customerDto);
            return Ok();
        }
        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="id_o"></param>
        /// <param name="id_c"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id_o, int id_c)
        {
            await _OrderService.Delete(id_o, id_c);
            return Ok();
        }
    }
}
