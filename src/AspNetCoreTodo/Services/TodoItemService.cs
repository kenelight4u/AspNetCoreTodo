﻿using AspNetCoreTodoData.Data;
using AspNetCoreTodoData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService( ApplicationDbContext context )
        {
            _context = context;
        }

        public async Task<bool> AddItemAsync(TodoItem newItem, ApplicationUser user)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.UserId = user.Id;
            //Have implemented the date picker
            //newItem.DueAt = DateTimeOffset.Now.AddDays(3);

            _context.Items.Add(newItem);

            var saveResult = await _context.SaveChangesAsync();

            //one is equivalent to true, our method is returning true or false
            return saveResult == 1;
        }

        public async Task<TodoItem[]> GetIncompleteItemAsync(ApplicationUser user)
        {
            return await _context.Items.Where(x => x.IsDone == false && x.UserId == user.Id).ToArrayAsync();
        }

        public async Task<bool> MarkDoneAsync(Guid id, ApplicationUser user)
        {
            var item = await _context.Items.Where(x => x.Id == id && x.UserId == user.Id).SingleOrDefaultAsync();

            if (item == null) return false;

            //actually, the item is not deleted in the datebase, just assign true ie cannot be shown to the user
            item.IsDone = true;

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1; //one entity should have been updated
        }
    }
}
