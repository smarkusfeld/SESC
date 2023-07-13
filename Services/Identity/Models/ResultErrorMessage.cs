namespace IdentityService.Models
{
    /// <summary>
    /// Class contains constant strings to represent various operation errors
    /// </summary>
    public class ResultErrorMessage
    {

        public const string UsernameUnavailable = "Could not create username";
        public const string DefaultError = "Operation failed.";
        public const string UserNotFound = "User {x} could not be found in the database";
        public const string DuplicateUsername = "User {x} already exists";
        public const string DuplicateEmail = "User already exists with email {x}";
        public const string InvalidEmailAddress = "Invalid or Missing email address";
        public const string AccountNotFound = "Account {x} could not be found in the database";
        public const string AccountAlreadyExists = "Account {x} already exists";
        public const string UserNotInRole = "User {x} not in role {y}";
        public const string UserAlreadyAssignedToRole = "User {x} already assigned to role {y}";
        public const string PasswordMismatch = "Password do not match";
        public const string InvalidUserName = "Username {x} invalid";
        public const string InvalidToken = "Invalid token";
        public const string InvalidRoleName = "Rolename {x} invalid";
        public const string DuplicateRoleName = "Duplicate role {x} ";
        public const string InvalidPassword = "Invalid password for user {x} ";
    }
}
