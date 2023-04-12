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
    public class ManufacturerController : ControllerBase
    {
        IManufacturerService _ManufacturerService;
        public ManufacturerController(IManufacturerService ManufacturerService)
        {
            _ManufacturerService = ManufacturerService;
        }
        /// <summary>
        /// Получение всех производителей
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ManufacturerService.GetAll());
        }
        /// <summary>
        /// Получение производителя по id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _ManufacturerService.GetById(id);
            var response = result.Adapt<GetManufacturerResponse>();
            return Ok(response);
        }
        /// <summary>
        /// Добавление производителя
        /// </summary>
        /// <param name="Manufacturer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateManufacturerRequest request)
        {
            var customerDto = request.Adapt<Manufacturer>();
            await _ManufacturerService.Create(customerDto);
            return Ok();
        }
        /// <summary>
        /// Обновление производителя
        /// </summary>
        /// <param name="Manufacturer"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateManufacturerRequest request)
        {
            var customerDto = request.Adapt<Manufacturer>();
            await _ManufacturerService.Update(customerDto);
            return Ok();
        }
        /// <summary>
        /// Удаление производителя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _ManufacturerService.Delete(id);
            return Ok();
        }
    }
}
