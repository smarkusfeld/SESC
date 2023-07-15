namespace StudentPortal.Models
{
    public class LoginResponseModel
    {
        public string Username { get; set; }
        public string Token { get; set; }

        public  UserRoleIndex UserHome { get; set; }
        public enum UserRoleIndex
        {
            Student,
            Admin,
            Factulty,
            Staff
        }
    }
}
