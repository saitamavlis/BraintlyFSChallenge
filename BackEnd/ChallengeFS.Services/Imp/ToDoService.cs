using ChallengeFS.DataAccess.Data;
using ChallengeFS.Models;
using ChallengeFS.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeFS.Services.Imp
{
    public class ToDoService : IToDoService
    {
        private readonly AppDbContext _dbcontext;
        public ToDoService(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<ToDo>>? GetAll()
        {
            await UpdateTodoStatus();
            return await _dbcontext.ToDos.ToListAsync();
        }
        public async Task<ToDo>? GetById(int Id)
        {
            return await _dbcontext.ToDos.FindAsync(Id);
        }
        public async Task<ToDo> Create(ToDo todo)
        {
            await _dbcontext.AddAsync(todo);
            await _dbcontext.SaveChangesAsync();
            return todo;
        }
        public async Task Delete(int Id)
        {
            var existingTodo =  await _dbcontext.ToDos.FindAsync(Id);
            if (existingTodo != null)
            {
                _dbcontext.ToDos.Remove(existingTodo);
                await _dbcontext.SaveChangesAsync();
            }     
        }

        public async Task Update(ToDo todo, int Id)
        {
            var existingTodo = await _dbcontext.ToDos.FindAsync(Id);
            if (existingTodo != null)
            {
                existingTodo.Description = todo.Description;
                existingTodo.Expires = todo.Expires;
                existingTodo.Status = todo.Status;                
                await _dbcontext.SaveChangesAsync();                
            }
        }

        private async Task UpdateTodoStatus()
        {
            List<int> todosIdList = await _dbcontext.ToDos.Select(t => t.Id).ToListAsync();
            foreach(int id in todosIdList)
            {
                var todo = await _dbcontext.ToDos.FindAsync(id);
                if(todo is not null && todo.Expires < DateTime.Now)
                {
                    todo.Status = Status.Expired;
                    await _dbcontext.SaveChangesAsync();
                }
            }
        
        }

    }
}