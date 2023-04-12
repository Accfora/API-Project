using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;
using SaturdayAPI.Contracts.Customer;
using Mapster;

namespace FirstSaturday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerService.GetAll());
        }
        /// <summary>
        /// Получение пользователя по id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _customerService.GetById(id);
            var response = result.Adapt<GetCustomerResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// <code>
        ///     POST /Todo<br/>
        ///     {<br/>
        ///         "login" : "A4Tech Bloody B188",<br/>
        ///         "password" : "!Pa$$word123@",<br/>
        ///         "firstname" : "Иван",<br/>
        ///         "lastname" : "Иванов",<br/>
        ///         "middlename" : "Иванович"<br/>
        ///     }<br/>
        /// </code>
        /// 
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateCustomerRequest request)
        {
            var customerDto = request.Adapt<Customer>();
            await _customerService.Create(customerDto);
            return Ok();
        }
        /// <summary>
        /// Обновление пользователя
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(CreateCustomerRequest request)
        {
            var customerDto = request.Adapt<Customer>();
            await _customerService.Update(customerDto);
            return Ok();
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.Delete(id);
            return Ok();
        }
    }
}
