using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Models.DTOs.ReponseModels
{
    public class EnrolmentConfirmationDTO
    {
        public EnrolmentConfirmationDTO(TuitionInvoiceDTO invoice, EnrolmentDTO enrolment)
        {
            EnrolmentDetail = enrolment;
            TutionInvoice = invoice;
        }

        public EnrolmentDTO EnrolmentDetail { get; private set; }
        public TuitionInvoiceDTO TutionInvoice { get; private set; }

    }
}
