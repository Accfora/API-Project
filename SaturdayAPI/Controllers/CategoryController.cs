using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _CategoryService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _CategoryService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(Category Category)
        {
            await _CategoryService.Create(Category);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Category Category)
        {
            await _CategoryService.Update(Category);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _CategoryService.Delete(id);
            return Ok();
        }
    }
}
