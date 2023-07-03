using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Models.DTOs
{
    public class InitalRegistrationConfirmationDTO
    {
        StudentDTO StudentAccount { get; }
        
        EnrolmentConfirmationDTO Enrolment { get; }

        public InitalRegistrationConfirmationDTO(StudentDTO  student, EnrolmentConfirmationDTO entrolment)
        {
            StudentAccount = student;
            Enrolment = entrolment;
        }

        
    }
}
