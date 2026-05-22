using AspNetWeek2.BookStore.Mvc.Models;
using AspNetWeek2.BookStore.Mvc.ViewModels;

namespace AspNetWeek2.BookStore.Mvc.Services;

public class BookService
{
    private readonly List<Book> _books = new()
    {
        new Book
        {
            Id = 1,
            Isbn = "BK-001",
            Title = "Clean Code",
            Category = "Programming",
            Author = "Robert C. Martin",
            Price = 350000,
            Quantity = 10,
            MinStock = 3,
            LastUpdatedAt = DateTime.Now
        },

        new Book
        {
            Id = 2,
            Isbn = "BK-002",
            Title = "Atomic Habits",
            Category = "Self Help",
            Author = "James Clear",
            Price = 280000,
            Quantity = 2,
            MinStock = 5,
            LastUpdatedAt = DateTime.Now
        },

        new Book
        {
            Id = 3,
            Isbn = "BK-003",
            Title = "The Pragmatic Programmer",
            Category = "Programming",
            Author = "Andrew Hunt",
            Price = 420000,
            Quantity = 0,
            MinStock = 2,
            LastUpdatedAt = DateTime.Now
        }
    };

    public List<Book> GetAll()
    {
        return _books;
    }

    public Book? GetById(int id)
    {
        return _books.FirstOrDefault(x => x.Id == id);
    }

    public BookStatsViewModel GetStats()
    {
        return new BookStatsViewModel
        {
            TotalBooks = _books.Count,
            TotalQuantity = _books.Sum(x => x.Quantity),
            TotalInventoryValue = _books.Sum(x => x.Price * x.Quantity),
            OutOfStockCount = _books.Count(x => x.Quantity <= 0)
        };
    }
}