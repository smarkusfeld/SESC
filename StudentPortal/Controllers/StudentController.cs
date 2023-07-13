
using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        //enrol in course

        //view enrolments

        //View/Update Student Profile

        //graduation eligibility 
    }
}
