﻿using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.Application.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T> GetById(int id);
        Task<T> GetByStudent(int studentid);
        IEnumerable<T> GetAll();
        IEnumerable<T> Index(string sortOrder);
        IEnumerable<T> Filter(Expression<Func<T, bool>> expression);
        Task<bool> Create(T dto);
        Task<bool> Upsert(T dto);
        Task<bool> Delete(T dto);
        Task<bool> Update(T dto);
        T getDTO (IEntity entity);
        List<T> getDTO(List<IEntity> entities);

    }
}
