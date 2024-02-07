using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fribergs_CarRental_RP.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Car Car { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        
    }
}
