using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IdentityService.Models
{
    /// <summary>
    /// Represents the result of an identity service operation
    /// Adapted from <seealso cref="IdentityResult"/>
    /// </summary>
    public class ResultDetail
    {
        private static readonly ResultDetail _success = new ResultDetail { Succeeded = true, Result = string.Empty };
        private static readonly ResultDetail _failure = new ResultDetail { Succeeded = false, Result = string.Empty };
        private readonly List<ResultError> _errors = new List<ResultError>();

        /// <summary>
        /// Flag indicating whether if the operation succeeded or not.
        /// </summary>
        /// <value>True if the operation succeeded, otherwise false.</value>
        public bool Succeeded { get; protected set; }

        /// <summary>
        /// Operation Result
        /// </summary>
        public object?  Result { get; protected set; }

        /// <summary>
        /// Creates a <see cref="ResultDetail"/> indicating an successful operation.
        /// </summary>
        /// <returns>An <see cref="ResultDetail"/> indicating a successful operation.</returns>
        public static ResultDetail Success => _success;

        /// <summary>
        /// Creates a <see cref="ResultDetail"/> indicating a successful operation.
        /// </summary>
        /// <returns>An <see cref="ResultDetail"/> indicating a successful operation.</returns>
        public static ResultDetail Failed => _failure;

        /// <summary>
        /// Creates a <see cref="ResultDetail"/> indicating a successful operation.
        /// </summary>
        /// <returns>An <see cref="ResultDetail"/> with the operation result</returns>
        public static ResultDetail SuccessResult(object resultObject) 
        {
            var result = new ResultDetail { Succeeded = true };
            if (resultObject != null)
            {
                result.Result = resultObject;
            }
            return result;
        }
        /// <summary>
        /// Creates a <see cref="ResultDetail"/> indicating a failed operation, with a list of <paramref name="errors"/> if applicable.
        /// </summary>
        /// <param name="errors">An optional array of <see cref="ResultError"/>s which caused the operation to fail.</param>
        /// <returns>An <see cref="ResultError"/> indicating a failed operation, with a list of <paramref name="errors"/> if applicable.</returns>
        public static ResultDetail FailedResult(params ResultError[] errors) => new ResultDetail { Succeeded = false, Result = errors };
        

        
    }

    
}
