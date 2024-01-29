using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;
namespace dotnetapp.Controllers;
public class DealerController : Controller
{
    private readonly ApplicationDbContext _context;

    public DealerController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Dealer
    public IActionResult Index()
    {
        var dealers = _context.Dealers.ToList();
        return View(dealers);
    }

    // GET: Dealer/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dealer = _context.Dealers
            .FirstOrDefault(e => e.ID == id);

        if (dealer == null)
        {
            return NotFound();
        }

        return View(dealer);
    }

    // GET: Dealer/Create
    public IActionResult Create()
    {
        ViewBag.Dealers = _context.Dealers.ToList();
        return View();
    }

    // POST: Dealer/Create
 [HttpPost]
public IActionResult Create(Dealer dealer)
{
    try
    {
            _context.Dealers.Add(dealer);
            _context.SaveChanges();
            return RedirectToAction("Index");
    }
    catch (Exception ex)
    {
        // Log the exception for debugging purposes
        Console.WriteLine(ex.Message);
        return View(dealer); // You can also redirect to an error page
    }
}

    // GET: Dealer/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dealer = _context.Dealers.Find(id);

        if (dealer == null)
        {
            return NotFound();
        }

        ViewBag.Dealers = _context.Dealers.ToList();
        return View(dealer);
    }

    // POST: Dealer/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Dealer dealer)
    {
        if (id != dealer.ID)
        {
            return NotFound();
        }

       // if (ModelState.IsValid)
        {
            _context.Dealers.Update(dealer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Dealers = _context.Dealers.ToList();
        return View(dealer);
    }

    // GET: Dealer/Delete/5
    // [HttpPost, ActionName("Delete")]
    // public IActionResult Delete(int? id)
    // {
    //     if (id == null)
    //     {
    //         return NotFound();
    //     }

    //     var dealer = _context.Dealers
    //         .FirstOrDefault(e => e.ID == id);

    //     if (dealer == null)
    //     {
    //         return NotFound();
    //     }

    //     return View(dealer);
    // }

    [HttpPost, ActionName("Delete")]

    public IActionResult Delete(int id)
    {
        var Dealer = _context.Dealers.Find(id);

        if (Dealer == null)
        {
            return NotFound();
        }

        _context.Dealers.Remove(Dealer);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }


}
