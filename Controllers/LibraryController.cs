using Microsoft.AspNetCore.Mvc;

namespace LibraryAPIRocketseatChallenge.Controllers;

[Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {

    private static List<Library> Books = new List<Library>
        {
            new Library { Id = 1, Title = "Amor I love you", Author = "Jose da Silva", Genre = "Romance", Price = 10, Quantity = 5 },
            new Library { Id = 2, Title = "A volta dos que nao foram", Author = "Ayrton Senna", Genre = "Velocidade", Price = 7, Quantity = 3 }
        };


    //GET ALL METHOD

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetAll()
        {
            return Ok(Books);
        }

    //GET BY ID METHOD

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById(int Id)
        {
            var book = Books.FirstOrDefault(x => x.Id == Id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

    // CREATE METHOD

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult Create(Library newBook)
        {
            newBook.Id = Books.Max(x => x.Id) +1;
            Books.Add(newBook);
            return CreatedAtAction(nameof(GetById), new { id = newBook.Id }, newBook);
        }

    //UPDATE METHOD

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult Update(int Id, Library updateBook)
        {

            var book = Books.FirstOrDefault(x =>x.Id == Id);
            if (book == null)
            {
                return NotFound();
            }

            book.Title = updateBook.Title;
            book.Author = updateBook.Author;
            book.Genre = updateBook.Genre;
            book.Price = updateBook.Price;
            book.Quantity = updateBook.Quantity;

            return NoContent();

        }

    //DELETE METHOD

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult Delete(int Id)
        {
            var book = Books.FirstOrDefault(x =>x.Id == Id);
            if(book == null)
            {  
                return NotFound(); 
            }

            Books.Remove(book);
            return NoContent();
        }
        
        

    }
