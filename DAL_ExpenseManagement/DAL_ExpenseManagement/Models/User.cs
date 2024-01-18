using DAL_ExpenseManagement.Data.Enum;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ExpenseManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool status { get; set; }
        public RolEnum Role { get; set; }

        public List<Income> Incomes { get; set; }
        public List<Expense> Expenses { get; set; }
        public Saving Savings { get; set; }
    }
}
