using AspNetWeek2.BookStore.Mvc.Services;
using AspNetWeek2.BookStore.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetWeek2.BookStore.Mvc.Controllers;

public class BooksController : Controller
{
    private readonly BookService _bookService;

    public BooksController(BookService bookService)
    {
        _bookService = bookService;
    }

    public IActionResult Index()
    {
        var books = _bookService.GetAll()
            .Select(x => new BookListItemViewModel
            {
                Id = x.Id,
                Isbn = x.Isbn,
                Title = x.Title,
                Category = x.Category,
                Price = x.Price,
                Quantity = x.Quantity,
                MinStock = x.MinStock
            })
            .ToList();

        return View(books);
    }

    public IActionResult Detail(int id)
    {
        var book = _bookService.GetById(id);

        if (book == null)
        {
            return NotFound();
        }

        var vm = new BookDetailViewModel
        {
            Id = book.Id,
            Isbn = book.Isbn,
            Title = book.Title,
            Category = book.Category,
            Author = book.Author,
            Price = book.Price,
            Quantity = book.Quantity,
            MinStock = book.MinStock,
            LastUpdatedAt = book.LastUpdatedAt
        };

        return View(vm);
    }

    public IActionResult Stats()
    {
        return View(_bookService.GetStats());
    }

    public IActionResult Welcome()
    {
        return Content("Welcome to Book Store MVC");
    }

    public IActionResult BookJson()
    {
        return Json(_bookService.GetAll());
    }

    public IActionResult GoToList()
    {
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Force404()
    {
        return NotFound("Book not found");
    }
}