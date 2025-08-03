using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop
{
    public class CarWorkshopDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? About { get; set; }

        // Kontakt
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
    }
}
