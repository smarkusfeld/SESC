using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LibraryService.Application.Models
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public List<string> Details { get; set; } = new List<string>();

        public string? Message;
        public string? Source { get; set; }

        public string? SupportMessage { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
