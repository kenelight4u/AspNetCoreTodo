using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreTodoData.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public bool IsDone { get; set; }

        [Required]
        public string Title { get; set; }

        //? marks the DueAt property as nullable
        public DateTimeOffset? DueAt { get; set; }  
    }
}