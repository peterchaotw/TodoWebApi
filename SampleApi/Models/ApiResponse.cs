using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApi.Models
{
    public class ApiResponse<T>
        where T : class
    {
        /// <summary>
        /// response info
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Is success
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Result 
        /// </summary>
        public IEnumerable<T> Data { get; set; }
    }
}