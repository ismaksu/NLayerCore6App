using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _services;

        public ProductsController(IProductService services, IMapper mapper)
        {
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _services.GetProductsWithCategory();
            return View(products);
        }
    }
}
