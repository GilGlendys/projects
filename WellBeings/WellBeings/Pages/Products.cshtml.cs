using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WellBeings.Models;
using WellBeings.Services;

namespace WellBeings.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ILogger<ProductsModel> _logger;
        public JsonFileProductService ProductService { get; }
        public IEnumerable<Product> Products { get; private set; }

        public ProductsModel(ILogger<ProductsModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}
