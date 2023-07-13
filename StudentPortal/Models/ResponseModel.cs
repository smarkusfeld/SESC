namespace StudentPortal.Models
{
    public class ResponseModel
    {

       
        /// <summary>
        /// Flag indicating whether if the operation succeeded or not.
        /// </summary>
        /// <value>True if the operation succeeded, otherwise false.</value>
        public bool Succeeded { get; protected set; }
        
        public int ResponseCode { get; protected set; }

        /// <summary>
        /// Operation Result
        /// </summary>
        public string ResultContent { get; protected set; }

        /// <summary>
        /// Creates a <see cref=" ResponseModel"/> indicating a successful operation.
        /// </summary>
        /// <returns>An <see cref=" ResponseModel"/> with the operation result</returns>
        public static ResponseModel Success(string content)
        {
            var result = new ResponseModel { Succeeded = true };
            if (content != null)
            {
                result.ResultContent = content;
            }
            return result;
        }

        /// <summary>
        /// Creates a <see cref=" ResponseModel"/> indicating a successful operation.
        /// </summary>
        /// <returns>An <see cref="ResponseModel"/> with the operation result</returns>
        public static ResponseModel Failed(int responseCode, string content)
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
