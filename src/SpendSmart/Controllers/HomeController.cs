using System.Diagnostics;
using ExpenseModel.Core;
using Microsoft.AspNetCore.Mvc;
using SpendSmart.Models;

namespace SpendSmart.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ExpenseModelDbContext _context;

    public HomeController(ILogger<HomeController> logger, ExpenseModelDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Expenses()
    {
        var allExpenses = _context.Expenses.ToList();

        var totalExp = allExpenses.Sum(x => x.Value);

        ViewBag.Expenses = totalExp;

        return View(allExpenses);
    }

    public IActionResult CreateEditExpense(int? id)
    {  
        if(id != null)
        {
            var expenseIdDb = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
            return View(expenseIdDb);
        }
        return View();
    }

     public IActionResult DeleteExpense(int id)
    {
        var expenseIdDb = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
        _context.Expenses.Remove(expenseIdDb);
        _context.SaveChanges();

        return RedirectToAction("Expenses");
    }

    public IActionResult CreateEditExpenseForm(Expense model)
    {
        if(model.Id == 0)
        {
            //Create
            _context.Expenses.Add(model);

        } else
        {
            //Editing
            _context.Expenses.Update(model);
        }

        _context.SaveChanges();

        return RedirectToAction("Expenses");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
