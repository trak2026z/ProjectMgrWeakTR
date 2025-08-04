using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop
{
    public class CarWorkshopDto
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Please insert description")]
        public string? Description { get; set; }
        public string? About { get; set; }

        [StringLength(12, MinimumLength = 8)]
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
    }
}
