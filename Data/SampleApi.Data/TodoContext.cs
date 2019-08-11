using SampleApi.Data.Model;
using System.Data.Entity;

namespace SampleApi.Data
{
    public class TodoContext : DbContext
    {
        private const string __ConnectionName__ = "DefaultConnection";
        public TodoContext() : this(__ConnectionName__)
        {
        }
        public TodoContext(string connectionName) : base("name=" + connectionName)
        {
        }

        /// <summary>
        /// Todos
        /// </summary>
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
