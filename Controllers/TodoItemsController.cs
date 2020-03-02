using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Todo.Api.Models;
using Todo.Api.Services;
using System;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("api/todos")]
    public class TodoItemsControllers : ControllerBase
    {
        private ITodoRepository repository;
        public TodoItemsControllers(ITodoRepository todoRepository)
        {
            repository = todoRepository ??
                throw new ArgumentNullException(nameof(todoRepository));
        }

        [HttpGet]
        public IActionResult GetTodos()
        {
            var result = repository.GetAllTodoItems();
            if (result == null){
                return NotFound();
            }
            return Ok(result);
        }
    }
}