using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Fribergs_CarRental_RP.Data
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int PricePerDay { get; set; }
        public string? CarImageUrl { get; set; }
        [Required]
        public bool Available { get; set; }
    }
}
