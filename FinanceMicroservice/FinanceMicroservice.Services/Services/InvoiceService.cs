using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Domain.Enums;
using FinanceMicroservice.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.Application.Services
{
     public class InvoiceService : IGenericService<InvoiceDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private static InvoiceDTO InvoiceDTO(Invoice invoice)
        {
            return new InvoiceDTO
            {
                ID = invoice.ID,
                //add other fields 

            };
        }
        public InvoiceDTO getDTO(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<InvoiceDTO> getDTO(List<IEntity> entities)
        {
            throw new NotImplementedException();
        }
        private static PaymentDTO PaymentDTO(Payment payment)
        {
            return new PaymentDTO
            {
                ID = payment.ID,
                //add other fields 

            };
        }
        //get invoice by id
        public async Task<InvoiceDTO> GetById(int id)
        {
            var getInvoice = await _unitOfWork.Invoices.Find(id);
            return InvoiceDTO(getInvoice);

        }
        public async Task<List<InvoiceDTO>?> GetByStudent(int studentid)
        {
            var account = await _unitOfWork.Accounts.FindWhere(x => x.StudentID.Equals(studentid));
            if (account == null) { return null; }
            var invoices = await _unitOfWork.Invoices.FindAllWhere(x => x.Account.ID == account.ID);
            var all = new List<InvoiceDTO>();
            foreach (var invoice in invoices)
            {
                all.Add(InvoiceDTO(invoice));
            }
            return all;

        }
        //getall invoices
        public async Task<IEnumerable<InvoiceDTO>> GetAll()
        {
            var invoices = await _unitOfWork.Invoices.FindAll();
            var all = new List<InvoiceDTO>();
            foreach (var invoice in invoices)
            {
                all.Add(InvoiceDTO(invoice));
            }
            return all;
        }

        //create invoice
        public async Task<bool> Create(InvoiceDTO invoice)
        {
            //validate invoice
            var account = await _unitOfWork.Accounts.Find(invoice.AccountID);
            //get account
            if (account != null)
            {

                var newInvoice = new Invoice
                {
                    ID = invoice.ID,
                    InvoiceDate = invoice.InvoiceDate,
                    Type = invoice.Type.Name,
                    Status = invoice.Status.Name,
                    total = invoice.total,
                    Account = account

                };
                await _unitOfWork.Invoices.Create(newInvoice);
                var result =  _unitOfWork.Save();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        //cancel invoice
        public async Task<bool> CancelInvoice(InvoiceDTO invoicedto)
        {
            var invoice = await _unitOfWork.Invoices.Find(invoicedto.ID);
            if (invoice != null)
                
            {
                invoice.Status = InvoiceStatus.Cancelled.Name;
                _unitOfWork.Invoices.Update(invoice);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }

            return false;

        }

        

        public IEnumerable<InvoiceDTO> Index(string sortOrder)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InvoiceDTO> Filter(Expression<Func<InvoiceDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Upsert(InvoiceDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(InvoiceDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(InvoiceDTO dto)
        {
            throw new NotImplementedException();
        }

        
        //pay invoice



    }
}
