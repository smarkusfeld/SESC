namespace IdentityService.Models
{
    /// <summary>
    /// Encapsulates an error from the service subsystem.
    /// </summary>
    public class ResultError
    {
        /// <summary>
        /// Gets or sets error code
        /// </summary>
        /// <value>
        /// The code for this error.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets error description for this error.
        /// </summary>
        /// <value>
        /// The description for this error.
        /// </value>
        public string Description { get; set; }

        public static ResultError DefaultError()
        {
            return new ResultError
            {
                Code = nameof(DefaultError),
                Description = ResultErrorMessage.DefaultError
            };
        }

        public static ResultError DuplicateUserName(string userName)
        {
            return new ResultError
            {
                Code = nameof(DuplicateUserName),
                Description = string.Format(ResultErrorMessage.DuplicateUsername, userName)
            };
        }

        public static ResultError UserNotFound(string userName)
        {
            return new ResultError
            {
                Code = nameof(UserNotFound),
                Description = string.Format(ResultErrorMessage.UserNotFound, userName)
            };
        }
        public static ResultError UserAlreadyExists(string email)
        {
            return new ResultError
            {
                Code = nameof(UserAlreadyExists),
                Description = string.Format(ResultErrorMessage.DuplicateEmail, email)
            };
        }
        public static ResultError InvalidEmail()
        {
            return new ResultError
            {
                Code = nameof(InvalidEmail),
                Description = ResultErrorMessage.InvalidEmailAddress
            };
        }

        public static ResultError InvalidPassword(string userName)
        {
            return new ResultError
            {
                Code = nameof(InvalidPassword),
                Description = string.Format(ResultErrorMessage.InvalidPassword, userName)
            };
        }


        public static ResultError UsernameUnavailable()
        {
            return new ResultError
            {
                Code = nameof(UsernameUnavailable),
                Description = ResultErrorMessage.UsernameUnavailable
            };
        }
    }
}
