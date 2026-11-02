using System;
using Microsoft.EntityFrameworkCore;
using SpendSmart.Models;

namespace ExpenseModel.Core;

public class ExpenseModelDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }
    
    public ExpenseModelDbContext(DbContextOptions<ExpenseModelDbContext> options)
        : base(options)
    {
        
    }
}
