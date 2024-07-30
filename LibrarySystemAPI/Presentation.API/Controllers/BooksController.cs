using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{

    public class BooksController : BasAPIController
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
                return NotFound();

            return Ok(_mapper.Map<BookDto>(book));
        }

        [HttpPost]
        public async Task<ActionResult> Add(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookService.AddAsync(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, bookDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            book.Id = id;
            await _bookService.UpdateAsync(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }
    }
}
