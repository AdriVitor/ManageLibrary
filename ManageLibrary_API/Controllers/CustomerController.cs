using ManageLibrary_Application.DTOs;
using ManageLibrary_Application.Interfaces;
using ManageLibrary_Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ManageLibrary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadCustomerDTO>> GetCustomerById([FromRoute] int id) {
            try {
                var customer = await _customerService.GetCustomerById(id);
                return Ok(customer);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostCustomer([FromBody] CustomerDTO customerDTO) {
            try {
                await _customerService.AddCustomer(customerDTO);
                return Ok();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutCustomer([FromBody] CustomerDTO customerDTO) {
            try {
                await _customerService.UpdateCustomer(customerDTO);
                return Ok();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer([FromRoute] int id) {
            try {
                await _customerService.DeleteCustomer(id);
                return Ok();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
