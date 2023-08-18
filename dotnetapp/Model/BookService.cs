using System;  
using System.Collections;
using System.Collections.Generic;  
using System.Linq;  
using System.Web;  
namespace dotnetapp.Models  
{
    public interface IBookService
    {
        public List<Book> GetBooks();
        public Book SaveBook(Book product);
        //public bool DeleteProduct(int Id);
    }
    public class BookService :IBookService
{
    private readonly BookRepository repository;

    public BookService(BookRepository repository)
    {
        this.repository = repository;
    }

    public Book SaveBook(Book product)
    {
        return repository.AddBook(product);
    }

    public List<Book> GetBooks()
    {
        return repository.GetAllBooks();
    }

    /*public Product GetProductById(int id)
    {
        return repository.FindById(id);
    }

    public string DeleteProduct(int id)
    {
        repository.Delete(id);
        return "Product removed !! " + id;
    }

    public Product UpdateProduct(Product product)
    {
        return repository.Update(product);
    }*/
}
}