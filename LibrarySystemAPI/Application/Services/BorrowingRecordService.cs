using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BorrowingRecordService : IBorrowingRecordService
    {
        private readonly IBorrowingRecordRepository _borrowingRecordRepository;
        private readonly IMapper _mapper;

        public BorrowingRecordService(IBorrowingRecordRepository borrowingRecordRepository, IMapper mapper)
        {
            _borrowingRecordRepository = borrowingRecordRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BorrowingRecord>> GetAllAsync()
        {
            return await _borrowingRecordRepository.GetAllAsync();
        }

        public async Task<BorrowingRecord> GetByIdAsync(int id)
        {
            return await _borrowingRecordRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(BorrowingRecord record)
        {
            await _borrowingRecordRepository.AddAsync(record);
        }

        public async Task UpdateAsync(BorrowingRecord record)
        {
            await _borrowingRecordRepository.UpdateAsync(record);
        }

        public async Task DeleteAsync(int id)
        {
            await _borrowingRecordRepository.DeleteAsync(id);
        }
    }
}
