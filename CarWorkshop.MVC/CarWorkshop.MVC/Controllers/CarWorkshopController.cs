using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.Services;
using CarWorkshop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly ICarWorkshopService _carWorkshopService;

        public CarWorkshopController(ICarWorkshopService carWorkshopService)
        {
            _carWorkshopService = carWorkshopService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarWorkshopDto dto)
        {
            await _carWorkshopService.Create(dto);
            return RedirectToAction(nameof(Create));
        }
    }
}
