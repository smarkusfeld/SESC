namespace StudentPortal.Models
{
    public class UserProfileModel
    {
        //idenity fields 
        public string Username { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public bool UsePermanentAddresAsTermAddress { get; set; } = true;
        public string TermAddressLineOne { get; set; } = string.Empty;
        public string? TermAddressLineTwo { get; set; } = string.Empty;
        public string? TermAddressLineThree { get; set; } = string.Empty;
        public string TermAddressTown_City { get; set; } = string.Empty;
        public string? TermAddressCounty_Region { get; set; } = string.Empty;
        public string TermAddressPostCode { get; set; } = string.Empty;

        public string TermAddressCountry { get; set; } = string.Empty;
         
        public string PermanentAddressLineOne { get; set; } = string.Empty;
        public string? PermanentAddressLineTwo { get; set; } = string.Empty;
        public string? PermanentAddressLineThree { get; set; } = string.Empty;
        public string PermanentAddressTown_City { get; set; } = string.Empty;
        public string? PermanentAddressCounty_Region { get; set; } = string.Empty;
        public string PermanentAddressPostCode { get; set; } = string.Empty;
        public string PermanentAddressCountry { get; set; } = string.Empty;
    }
}
