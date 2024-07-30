using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Patron, PatronDto>().ReverseMap();
            CreateMap<BorrowingRecord, BorrowingRecordDto>().ReverseMap();
        }
    }
}
