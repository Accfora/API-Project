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
    public class GoodFilterValueController : ControllerBase
    {
        IGoodFilterValueService _GoodFilterValueService;
        public GoodFilterValueController(IGoodFilterValueService GoodFilterValueService)
        {
            _GoodFilterValueService = GoodFilterValueService;
        }
        /// <summary>
        /// Получение всхе значений товаров по фильтрам
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _GoodFilterValueService.GetAll());
        }
        /// <summary>
        /// Получение значения по фильтру по id
        /// </summary>
        [HttpGet("{id_g}/{id_f}")]
        public async Task<IActionResult> GetById(int id_g, int id_f)
        {
            var result = await _GoodFilterValueService.GetById(id_g, id_f);
            var response = result.Adapt<GetGoodFilterValueResponse>();
            return Ok(response);
        }
        /// <summary>
        /// Добавление значения по фильтру
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Add(CreateGoodFilterValueRequest request)
        {
            var customerDto = request.Adapt<GoodFilterValue>();
            await _GoodFilterValueService.Create(customerDto);
            return Ok();
        }
        /// <summary>
        /// Обновление значения по фильтру
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(CreateGoodFilterValueRequest request)
        {
            var customerDto = request.Adapt<GoodFilterValue>();
            await _GoodFilterValueService.Update(customerDto);
            return Ok();
        }
        /// <summary>
        /// Удаление значение по фильтру
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id_g, int id_f)
        {
            await _GoodFilterValueService.Delete(id_g, id_f);
            return Ok();
        }
    }
}
