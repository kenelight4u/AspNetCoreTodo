using AspNetCoreTodoData.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodoData.Data
{
    public class TodoItemContext : DbContext
    {
        public TodoItemContext(DbContextOptions<TodoItemContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> Items { get; set; }
    }
}