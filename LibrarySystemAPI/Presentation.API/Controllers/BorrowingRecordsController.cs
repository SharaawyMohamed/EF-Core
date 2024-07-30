using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{

    public class BorrowingRecordsController : BasAPIController
    {
        private readonly IBorrowingRecordService _borrowingRecordService;
        private readonly IMapper _mapper;

        public BorrowingRecordsController(IBorrowingRecordService borrowingRecordService, IMapper mapper)
        {
            _borrowingRecordService = borrowingRecordService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowingRecordDto>>> GetAll()
        {
            var records = await _borrowingRecordService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<BorrowingRecordDto>>(records));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowingRecordDto>> GetById(int id)
        {
            var record = await _borrowingRecordService.GetByIdAsync(id);
            if (record == null)
                return NotFound();

            return Ok(_mapper.Map<BorrowingRecordDto>(record));
        }

        [HttpPost]
        [Route("borrow/{bookId}/patron/{patronId}")]
        public async Task<ActionResult> BorrowBook(int bookId, int patronId)
        {
            var record = new BorrowingRecord
            {
                BookId = bookId,
                PatronId = patronId,
                BorrowDate = DateTime.UtcNow
            };

            await _borrowingRecordService.AddAsync(record);
            return NoContent();
        }

        [HttpPut]
        [Route("return/{bookId}/patron/{patronId}")]
        public async Task<ActionResult> ReturnBook(int bookId, int patronId)
        {
            var record = await _borrowingRecordService.GetByIdAsync(bookId);
            if (record == null || record.PatronId != patronId)
                return NotFound();

            record.ReturnDate = DateTime.UtcNow;
            await _borrowingRecordService.UpdateAsync(record);
            return NoContent();
        }
    }
}
