using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoBikeShop.Models
{
    public class EmailCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdEmail { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string? Name { get; set; }

        public string? Note { get; set; }
    }
}
