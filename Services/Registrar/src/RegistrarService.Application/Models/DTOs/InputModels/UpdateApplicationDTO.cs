using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Models.DTOs.InputModels
{
    public class UpdateApplicationDTO
    {
        public int ApplicationId { get; set; }
        public string Statement { get; set; }
        public string Status { get; set; }
    }
}
