using FinanceMicroservice.Application.DTOs;
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
    public interface IGenericService<T> where T : class
    {
        T GetById(int id);
        T GetByStudent(int studentid);
        ICollection<T> GetAll();
        ICollection<T> Index(string sortOrder);
        ICollection<T> Filter(Expression<Func<T, bool>> expression);
        bool Create(T dto);
        bool Upsert(T dto);
        bool Delete(T dto);
        bool Update(T dto);
        
    }
}
