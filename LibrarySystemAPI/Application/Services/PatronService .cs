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
    public class PatronService : IPatronService
    {
        private readonly IPatronRepository _patronRepository;
        private readonly IMapper _mapper;

        public PatronService(IPatronRepository patronRepository, IMapper mapper)
        {
            _patronRepository = patronRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Patron>> GetAllAsync()
        {
            return await _patronRepository.GetAllAsync();
        }

        public async Task<Patron> GetByIdAsync(int id)
        {
            return await _patronRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Patron patron)
        {
            await _patronRepository.AddAsync(patron);
        }

        public async Task UpdateAsync(Patron patron)
        {
            await _patronRepository.UpdateAsync(patron);
        }

        public async Task DeleteAsync(int id)
        {
            await _patronRepository.DeleteAsync(id);
        }
    }
}
