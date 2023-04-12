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
    public class CategoryController : ControllerBase
    {
        ICategoryService _CategoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }
        /// <summary>
        /// Получение всех категорий
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _CategoryService.GetAll());
        }
        /// <summary>
        /// Получение категории по id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _CategoryService.GetById(id);
            var response = result.Adapt<GetCategoryResponse>();
            return Ok(response);
        }
        /// <summary>
        /// Создание новой категории
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryRequest request)
        {
            var dto = request.Adapt<Category>();
            await _CategoryService.Create(dto);
            return Ok();
        }
        /// <summary>
        /// Обновление категории
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(CreateCategoryRequest request)
        {
            var dto = request.Adapt<Category>();
            await _CategoryService.Update(dto);
            return Ok();
        }
        /// <summary>
        /// Удаление категории
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _CategoryService.Delete(id);
            return Ok();
        }
    }
}
