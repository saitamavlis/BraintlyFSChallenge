using ChallengeFS.Models;
using ChallengeFS.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFS.Services
{
    public interface IToDoService
    {
        public Task<IEnumerable<ToDo>>? GetAll();
        public Task<ToDo>? GetById(int Id);
        public Task<ToDo> Create(ToDo todo);
        public Task Delete(int Id);
        public Task Update(ToDo todo, int Id);
    }
}
