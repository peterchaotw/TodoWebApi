using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApi.Data.Model
{
    public class TodoItem
    {
        /// <summary>
        /// Key
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Is Done
        /// </summary>
        public bool IsComplete { get; set; }
    }
}
