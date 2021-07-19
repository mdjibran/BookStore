using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IRepository _repository;

        public BooksController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<BooksController>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var books = _repository.GetAll();
            return Ok(books);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _repository.GetById(id);
            return Ok(book);
        }

        // POST api/<BooksController>
        [HttpPost]
        public ActionResult Post([FromBody] Book obj)
        {
            if (ModelState.IsValid && obj.Id != 0)
            {

                _repository.Save(obj);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book obj)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(id, obj);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id != 0)
            {
                _repository.Delete(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
