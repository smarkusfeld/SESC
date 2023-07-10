using AutoMapper;
using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Application.Mapper;
using FinanceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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




        public async Task<string> CreateInvoice(NewInvoiceDTO invoiceDTO)
        {
            var invoice = await ProcessNewInvoice(invoiceDTO);
            if (invoice != null)
            {
                var result = _unitOfWork.Save();
                if (result > 0)
                {
                    return invoice.Reference;
                }
                return null;
            }
            return null;
        }
        public async Task<string> CreateLibraryInvoice(NewInvoiceDTO invoiceDTO)
        {
            var invoice = await ProcessNewInvoice(invoiceDTO, InvoiceType.Library);
            if (invoice != null)
            {

                var result = _unitOfWork.Save();
                if (result > 0)
                {
                    return invoice.Reference;
                }
                return null;
            }
            return null;
        }
        public async Task<string> CreateTutitionInvoice(NewInvoiceDTO invoiceDTO)
        {
            var invoice = await ProcessNewInvoice(invoiceDTO, InvoiceType.Tutition);
            if (invoice != null)
            {

                var result = _unitOfWork.Save();
                if (result > 0)
                {
                    return invoice.Reference;
                }
                return null;
            }
            return null;
        }
        private string CreateReference(NewInvoiceDTO invoiceDTO, string type)
        {
            string dateString = DateTime.Now.ToString("yyyyMMddHmmss");
            string sourceRef = type + "-" + invoiceDTO.Reference;
            string[] array = { sourceRef, invoiceDTO.StudentId, dateString };
            return string.Join("-", array);

        }
        private async Task<Invoice> ProcessNewInvoice(NewInvoiceDTO invoiceDTO, InvoiceType invoiceType = InvoiceType.Fee)
        {
            var account = _unitOfWork.Accounts.GetAllWhereAsync(x => x.StudentID == invoiceDTO.StudentId);
            var type = Enum.GetName(invoiceType) ?? "invoice";
            if (account != null)
            {
                string reference = CreateReference(invoiceDTO, type);
                var invoice = new InvoiceDTO
                {
                    AccountID = account.Id,
                    Reference = reference,
                    DueDate = invoiceDTO.DueDate,
                    InvoiceDate = DateTime.Now,
                    Total = invoiceDTO.Total,
                    Type = invoiceType,
                    Status = InvoiceStatus.Outstanding,
                    Balance = 0,
                };
                var add = _mapper.Map<Invoice>(invoice);
                var result = await _unitOfWork.Invoices.AddAsync(add);
                return result;
            }
            return null;
        }


        public async Task<bool> DeleteInvoice(int invoiceID)
        {
            var invoice = await _unitOfWork.Invoices.GetAsync(invoiceID);
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
            var invoiceList = await _unitOfWork.Invoices.GetAllAsync();
            var invoiceDTOList = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                invoiceDTOList.Add(_mapper.Map<InvoiceDTO>(invoice));
            }
            return invoiceDTOList.AsEnumerable();
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllInvoices(string studentID)
        {
            var invoiceList = await _unitOfWork.Invoices.GetAllWhereAsync(x => x.Account.StudentID == studentID);
            var invoiceDTOList = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                InvoiceDTO dto = _mapper.Map<InvoiceDTO>(invoice);
                dto.Balance = await TotalPaid(dto.ID);
                dto = UpdateStatus(dto);
                invoiceDTOList.Add(dto);
            }
            return invoiceDTOList.AsEnumerable();
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllInvoices(int accountID)
        {
            var invoiceList = await _unitOfWork.Invoices.GetAllWhereAsync(x => x.Account.ID == accountID);
            var invoiceDTOList = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                InvoiceDTO dto = _mapper.Map<InvoiceDTO>(invoice);
                dto.Balance = await TotalPaid(dto.ID);
                dto = UpdateStatus(dto);
                invoiceDTOList.Add(dto);
            }
            return invoiceDTOList.AsEnumerable();
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllOutstandingInvoices()
        {
            var invoiceList = await _unitOfWork.Invoices.GetAllWhereAsync(x => x.Status == InvoiceStatus.Outstanding);
            var invoiceDTOList = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                invoiceDTOList.Add(_mapper.Map<InvoiceDTO>(invoice));
            }
            return invoiceDTOList.AsEnumerable();
        }
        public async Task<IEnumerable<InvoiceDTO>> GetOutstandingInvoices(string studentID)
        {
            var invoiceList = await _unitOfWork.Invoices.GetAllWhereAsync(x => x.Account.StudentID == studentID);
            var invoiceDTOList = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                InvoiceDTO dto = _mapper.Map<InvoiceDTO>(invoice);
                dto.Balance = await TotalPaid(dto.ID);
                dto = UpdateStatus(dto);
                if (dto.Status == InvoiceStatus.Outstanding)
                {
                    invoiceDTOList.Add(dto);
                }

            }
            return invoiceDTOList.AsEnumerable();
        }

        public async Task<bool> HasOutstandingBalance(string studentId)
        {
            var all = await GetOutstandingInvoices(studentId);
            return (all == null || all.Count() == 0);
        }
        public async Task<IEnumerable<InvoiceDTO>> GetOutstandingInvoices(int accountID)
        {
            var invoiceList = await _unitOfWork.Invoices.GetAllWhereAsync(x => x.AccountID == accountID);
            var invoiceDTOList = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                InvoiceDTO dto = _mapper.Map<InvoiceDTO>(invoice);
                dto.Balance = await TotalPaid(dto.ID);
                dto = UpdateStatus(dto);
                if (dto.Status == InvoiceStatus.Outstanding)
                {
                    invoiceDTOList.Add(dto);
                }

            }
            return invoiceDTOList.AsEnumerable();
        }
        public async Task<IEnumerable<InvoiceDTO>> GetAllOverdueInvoices()
        {
            var invoiceList = await _unitOfWork.Invoices.GetAllWhereAsync(x => x.DueDate < DateTime.Now);
            var invoiceDTOList = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                InvoiceDTO dto = _mapper.Map<InvoiceDTO>(invoice);
                dto.Balance = await TotalPaid(dto.ID);
                dto = UpdateStatus(dto);
                if(dto.Status == InvoiceStatus.Outstanding)
                {
                    invoiceDTOList.Add(dto);
                }
                
            }
            return invoiceDTOList.AsEnumerable();
        }

        public async Task<InvoiceDTO> GetInvoiceById(int invoiceID)
        {
            var invoice = await _unitOfWork.Invoices.GetAsync(invoiceID);
            InvoiceDTO dto = _mapper.Map<InvoiceDTO>(invoice);
            dto.Balance = await TotalPaid(dto.ID);
            dto = UpdateStatus(dto);
            return dto;
        }

        public async Task<InvoiceDTO> GetInvoiceByReference(string reference)
        {
            var invoice = await _unitOfWork.Invoices.GetByAsync(x => x.Reference == reference);
            InvoiceDTO dto = _mapper.Map<InvoiceDTO>(invoice);
            decimal payments = await TotalPaid(dto.ID);
            dto.Balance = dto.Total-payments;
            dto = UpdateStatus(dto);
            return dto;
        }

        public async Task<bool> CancelInvoice(string reference)
        {
            var invoice = await _unitOfWork.Invoices.GetByAsync(x => x.Reference == reference);
            if (invoice != null)
            {
                invoice.Status = InvoiceStatus.Cancelled;
                _unitOfWork.Invoices.Update(invoice);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public async Task<bool> ReferenceCheck(string reference)
        {
            var invoice = await _unitOfWork.Invoices.GetAllWhereAsync(x => x.Reference == reference);
            return invoice == null ? true : false;
        }
       

        private async Task<int> GetAccountID(string studentid)
        {
            var account= await _unitOfWork.Accounts.GetByAsync(x => x.StudentID == studentid);
            return account == null ? 0 : account.ID;
        }
        private InvoiceDTO UpdateStatus(InvoiceDTO dto)
        {
            if (dto.Balance == 0 && dto.Status != InvoiceStatus.Cancelled)
            {
                dto.Status = InvoiceStatus.Paid;
            }
            return dto;
        }

        private async Task<decimal> TotalPaid(int id)
        {
            try
            {
                var payments = await _unitOfWork.Payments.GetAllWhereAsync(x => x.InvoiceID == id
                                                                       && x.Status != PaymentStatus.Declined
                                                                       && x.Status != PaymentStatus.Cancelled);
                return payments.Select(x => x.Amount).Sum();
            }
            catch
            {
                return 0;
            }

        }



    }

}
