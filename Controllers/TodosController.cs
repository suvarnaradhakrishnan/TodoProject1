using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;
using System;
using TodoProject.Data;
using TodoProject.Models;

namespace TodoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodoDbContext _todoDbContext;
        public TodosController(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var todos = await _todoDbContext.todos.ToListAsync();
            return Ok(todos);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodos(Todos todo)
        {
            todo.id= Guid.NewGuid();
            _todoDbContext.todos.Add(todo);
            await _todoDbContext.SaveChangesAsync();
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            var todo = await _todoDbContext.todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            _todoDbContext.todos.Remove(todo);
            await _todoDbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
