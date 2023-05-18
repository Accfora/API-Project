using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaturdayAPI.Contracts.Filter;

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
        /// <summary>
        /// Получение всех фильтров
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _FilterService.GetAll());
        }
        /// <summary>
        /// Получение фильтра по id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _FilterService.GetById(id);
            var response = result.Adapt<GetFilterResponse>();
            return Ok(response);
        }
        /// <summary>
        /// Добавление фильтра
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Add(CreateFilterRequest request)
        {
            var customerDto = request.Adapt<Filter>();
            await _FilterService.Create(customerDto);
            return Ok();
        }
        /// <summary>
        /// Обновление фильтра
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(CreateFilterRequest request)
        {
            var customerDto = request.Adapt<Filter>();
            await _FilterService.Update(customerDto);
            return Ok();
        }
        /// <summary>
        /// Удаление фильтра
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _FilterService.Delete(id);
            return Ok();
        }
    }
}
