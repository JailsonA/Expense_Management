using DAL_ExpenseManagement.Data.Enum;

namespace API_ExpenseManagement.ModelsDTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
