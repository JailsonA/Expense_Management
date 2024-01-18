using DAL_ExpenseManagement.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ExpenseManagement.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryEnum Type { get; set; } // Income or Expense

        public List<Expense> Expenses { get; set; }
    }
}
