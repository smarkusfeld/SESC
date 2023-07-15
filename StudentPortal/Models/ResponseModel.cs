namespace StudentPortal.Models
{
    public class ResponseModel
    {
        /// <summary>
        /// Creates a <see cref=" ResponseModel"/> indicating a successful operation without result content
        /// </summary>
        public static ResponseModel Success => new ResponseModel { Succeeded = true };
        /// <summary>
        /// Creates a <see cref=" ResponseModel"/> indicating an failed operation without result content
        /// </summary>
        public static ResponseModel Failed => new ResponseModel { Succeeded = false };
        /// <summary>
        /// Flag indicating whether if the operation succeeded or not.
        /// </summary>
        /// <value>True if the operation succeeded, otherwise false.</value>
        public bool Succeeded { get; protected set; }
        
        public int ResponseCode { get; protected set; }

        /// <summary>
        /// Operation Result
        /// </summary>
        public string? ResultContent { get; protected set; }

        /// <summary>
        /// Creates a <see cref=" ResponseModel"/> indicating a successful operation.
        /// </summary>
        /// <returns>An <see cref=" ResponseModel"/> with the operation result</returns>
        public static ResponseModel SuccessResult(string content)
        {
            var result = new ResponseModel { Succeeded = true };
            if (content != null)
            {
                result.ResultContent = content;
            }
            return result;
        }

        /// <summary>
        /// Creates a <see cref=" ResponseModel"/> indicating a failed operation.
        /// </summary>
        /// <returns>An <see cref="ResponseModel"/> with the operation result</returns>
        public static ResponseModel FailedResult(int responseCode, string content)
        {
            var result = new ResponseModel { Succeeded = false, ResponseCode = responseCode };
            if (content != null)
            {
                result.ResultContent = content;
            }
            return result;
        }

    }
}
