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

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? DueAt { get; set; }  
    }
}