namespace IdentityService.Models
{
    public class ConactModel
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string SchoolEmail { get; set; }
        public string PhoneNumber { get; set; }

        public string TermAddressLineOne { get; set; }
        public string? TermAddressLineTwo { get; set; }
        public string? TermAddressLineThree { get; set; }
        public string TermAddressTown_City { get; set; }
        public string? TermAddressCounty_Region { get; set; }
        public string TermAddressPostCode { get; set; }

        public string TermAddressCountry { get; set; }

        public string PermanentAddressLineOne { get; set; }
        public string? PermanentAddressLineTwo { get; set; }
        public string? PermanentAddressLineThree { get; set; }
        public string PermanentAddressTown_City { get; set; }
        public string? PermanentAddressCounty_Region { get; set; }
        public string PermanentAddressPostCode { get; set; }
        public string PermanentAddressCountry { get; set; }
    }
}
