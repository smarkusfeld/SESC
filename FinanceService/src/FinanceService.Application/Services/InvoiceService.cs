using AutoMapper;
using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<bool> CreateInvoice(InvoiceDTO invoiceDTO)
        {
            // Validation logic
            var invoice = _mapper.Map<Invoice>(invoiceDTO);
            if (invoice != null)
            {
                await _unitOfWork.Invoices.Create(invoice);
                var result = _unitOfWork.Save();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteInvoice(int invoiceID)
        {
            var invoice = await _unitOfWork.Invoices.Find(invoiceID);
            if (invoice != null)
            {
                _unitOfWork.Invoices.Delete(invoice);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllInvoices()
        {
            var invoiceList = await _unitOfWork.Invoices.FindAll();
            var invoiceDTOList = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                invoiceDTOList.Add(_mapper.Map<InvoiceDTO>(invoice));
            }
            return invoiceDTOList.AsEnumerable();
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllInvoices(string studentID)
        {
            var invoiceList = await _unitOfWork.Invoices.FindAllWhere(x => x.Account.StudentID == studentID);
            var invoiceDTOList = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                invoiceDTOList.Add(_mapper.Map<InvoiceDTO>(invoice));
            }
            return invoiceDTOList.AsEnumerable();
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllInvoices(int accountID)
        {
            var invoiceList = await _unitOfWork.Invoices.FindAllWhere(x => x.Account.ID == accountID);
            var invoiceDTOList = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                invoiceDTOList.Add(_mapper.Map<InvoiceDTO>(invoice));
            }
            return invoiceDTOList.AsEnumerable();
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllOutstandingInvoices()
        {
            var invoiceList = await _unitOfWork.Invoices.FindAllWhere(x => x.InvoiceStatus == InvoiceStatus.Outstanding.ToString());
            var invoiceDTOList = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                invoiceDTOList.Add(_mapper.Map<InvoiceDTO>(invoice));
            }
            return invoiceDTOList.AsEnumerable();
        }
        public Task<IEnumerable<InvoiceDTO>> GetOutstandingInvoices(string studentID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InvoiceDTO>> GetOutstandingInvoices(int accountID)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<InvoiceDTO>> GetAllOverdueInvoices()
        {
            var invoiceList = await _unitOfWork.Invoices.FindAllWhere(x => x.DueDate < DateTime.Now);
            var invoiceDTOList = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                invoiceDTOList.Add(_mapper.Map<InvoiceDTO>(invoice));
            }
            return invoiceDTOList.AsEnumerable();
        }

        public Task<InvoiceDTO> GetInvoiceById(int invoiceID)
        {
            throw new NotImplementedException();
        }

        public async Task<InvoiceDTO> GetInvoiceByReference(string reference)
        {
            var invoiceDTO = await _unitOfWork.Invoices.FindWhere(x => x.Reference == reference);
            return _mapper.Map<InvoiceDTO>(invoiceDTO);
        }    

        public async Task<bool> UpdateInvoice(InvoiceDTO invoiceDTO)
        {
            var check = await _unitOfWork.Invoices.Find(invoiceDTO.ID);
            if (check != null)
            {
                var invoice = _mapper.Map<Invoice>(invoiceDTO);
                _unitOfWork.Invoices.Update(invoice);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
