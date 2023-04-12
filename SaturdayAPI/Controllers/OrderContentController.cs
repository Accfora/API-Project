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
    public class OrderContentController : ControllerBase
    {
        IOrderContentService _OrderContentService;
        public OrderContentController(IOrderContentService OrderContentService)
        {
            _OrderContentService = OrderContentService;
        }
        /// <summary>
        /// Получение всех содержимых корзин
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _OrderContentService.GetAll());
        }
        /// <summary>
        /// Получение содержимого корзины по id
        /// </summary>
        /// <param name="id_o"></param>
        /// <param name="id_c"></param>
        /// <param name="id_g"></param>
        /// <returns></returns>
        [HttpGet("{id_o}/{id_c}/{id_g}")]
        public async Task<IActionResult> GetById(int id_o, int id_c, int id_g)
        {
            var result = await _OrderContentService.GetById(id_o, id_c, id_g);
            var response = result.Adapt<GetOrderContentResponse>();
            return Ok(response);
        }
        /// <summary>
        /// Добавление содержимого корзины
        /// </summary>
        /// <param name="OrderContent"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateOrderContentRequest request)
        {
            var customerDto = request.Adapt<OrderContent>();
            await _OrderContentService.Create(customerDto);
            return Ok();
        }
        /// <summary>
        /// Изменение элемента содержимого корзины
        /// </summary>
        /// <param name="OrderContent"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateOrderContentRequest request)
        {
            var customerDto = request.Adapt<OrderContent>();
            await _OrderContentService.Update(customerDto);
            return Ok();
        }
        /// <summary>
        /// Удаление элемента содержимого корзины
        /// </summary>
        /// <param name="id_o"></param>
        /// <param name="id_c"></param>
        /// <param name="id_g"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id_o, int id_c, int id_g)
        {
            await _OrderContentService.Delete(id_o, id_c, id_g);
            return Ok();
        }
    }
}
