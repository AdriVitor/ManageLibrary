﻿using AutoMapper;
using ManageLibrary_Application.DTOs;
using ManageLibrary_Application.Interfaces;
using ManageLibrary_Domain.Entities;
using ManageLibrary_Infra.Interfaces;

namespace ManageLibrary_Application.Services
{
    public class BookService : IBookService {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task AddBook(BookDTO bookDTO) {
            var book = _mapper.Map<Book>(bookDTO);
            await _bookRepository.AddBook(book);
        }

        public async Task DeleteBook(int id) {
            await _bookRepository.DeleteBook(id);
        }

        public async Task<Book> GetBookById(int id) {
            return await _bookRepository.GetBookById(id);
        }

        public async Task UpdateBook(BookDTO bookDTO) {
            var book = _mapper.Map<Book>(bookDTO);
            await _bookRepository.UpdateBook(book);
        }
    }
}
