

using MvcStockv2.Models.Entity;

namespace MvcStock.Models.ViewModel
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public int UserId { get; set; }
    }
}
