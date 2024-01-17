using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ExpenseManagement.Models
{
    public class Saving
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Goal { get; set; }

        public User User { get; set; }
    }
}
