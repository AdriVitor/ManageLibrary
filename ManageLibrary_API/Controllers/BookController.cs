using ManageLibrary_Application.DTOs;
using ManageLibrary_Application.Interfaces;
using ManageLibrary_Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ManageLibrary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService) {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById([FromRoute] int id) {
            try {
                var customer = await _bookService.GetBookById(id);
                return Ok(customer);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostBook([FromBody] BookDTO bookDTO) {
            try {
                await _bookService.AddBook(bookDTO);
                return Ok();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutBook([FromBody] BookDTO bookDTO) {
            try {
                await _bookService.UpdateBook(bookDTO);
                return Ok();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook([FromRoute] int id) {
            try {
                await _bookService.DeleteBook(id);
                return Ok();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
