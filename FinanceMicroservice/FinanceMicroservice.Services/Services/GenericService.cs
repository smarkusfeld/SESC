using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.Application.Services
{
    public abstract class GenericService<T,U> : IGenericService<T> where T : class where U : IEntity
    {
        private readonly IBaseRepository<U> _repository;
        private IUnitOfWork unitOfWork;

        public GenericService(IBaseRepository<U> repository)
        {
            _repository = repository;
        }

        protected GenericService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public abstract T GetByStudent(int studentid);
        public abstract T Create(T dto); 
        public abstract bool Delete(T dto);
        public abstract ICollection<T> GetAll();
        public abstract ICollection<T> Index(string sortOrder);
        public abstract ICollection<T> Filter(Expression<Func<T, bool>> expression);
        public abstract T GetById(int id);
        public abstract T GetByStudentId(int id);
        public abstract bool Update(T dto);
        public abstract bool Upsert(T dto);
        protected abstract T DTO(U enity);
        protected abstract U Model(T dto);

        bool IGenericService<T>.Create(T dto)
        {
            throw new NotImplementedException();
        }
    }
}
