using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ExpenseManagement.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }

        public User User { get; set; }
        public Category Category { get; set; }
    }
}
