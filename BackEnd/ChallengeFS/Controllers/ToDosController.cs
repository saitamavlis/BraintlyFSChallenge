using AutoMapper;
using ChallengeFS.Models;
using ChallengeFS.Models.DTOs;
using ChallengeFS.Services.Imp;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChallengeFS.API.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly ToDoService _service;
        private readonly IMapper _mapper;

        public ToDosController(ToDoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: api/<ToDosController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _service.GetAll();
            return Ok(todos);
        }

        // GET api/<ToDosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _service.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        // POST api/<ToDosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoCreateDto todoDto)
        {
            var todo = _mapper.Map<ToDo>(todoDto);
            await _service.Create(todo);
            return Ok();
            
        }

        // PUT api/<ToDosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ToDoUpdateDto todoDto)
        {
            var existingTodo = await _service.GetById(id);
            if(existingTodo is not null)
            {
                var todo = _mapper.Map<ToDo>(todoDto);
                await _service.Update(todo, id);
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<ToDosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingTodo = await _service.GetById(id);
            if (existingTodo is not null)
            {
                await _service.Delete(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
