﻿using System.Linq.Expressions;
using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Application.Interfaces;

namespace FinanceMicroservice.Application.Services
{
    public class InvoiceService<T> : IEntityService<T> where T : InvoiceDTO
    {
        public Task Add(T dto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T dto)
        {
            throw new NotImplementedException();
        }

        public bool Exists(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindWhere(string attribute, string value)
        {
            throw new NotImplementedException();
        }

        public Task Update(T dto)
        {
            throw new NotImplementedException();
        }
    }
}
