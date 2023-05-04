using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SaturdayAPI.Contracts.Customer;

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
        /// <summary>
        /// Получение всех товаров
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _goodService.GetAll());
        }
        /// <summary>
        /// Получение товара по id
        /// </summary>
        [HttpGet("byid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _goodService.GetById(id);
            var response = result.Adapt<GetGoodResponse>();
            return Ok(response);
        }
        /// <summary>
        /// Получение товаров по id_C
        /// </summary>
        
        //[HttpGet("byc/{categoty_id}")]
        //public async Task<IActionResult> GetByCategory(int categoty_id)
        //{
        //    var result = await _goodService.GetByCategory(categoty_id);
        //    var response = result.Adapt<GetGoodResponse>();
        //    return Ok(response);
        //}

        /// <summary>
        /// Добавление товара
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Add(CreateGoodRequest request)
        {
            var customerDto = request.Adapt<Good>();
            await _goodService.Create(customerDto);
            return Ok();
        }
        /// <summary>
        /// Обновление товара
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(CreateGoodRequest request)
        {
            var customerDto = request.Adapt<Good>();
            await _goodService.Update(customerDto);
            return Ok();
        }
        /// <summary>
        /// Удаление товара
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _goodService.Delete(id);
            return Ok();
        }
    }
}
